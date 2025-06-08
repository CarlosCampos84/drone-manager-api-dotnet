using GSDrones.DTOs;
using GSDrones.Models;
using GSDrones.Models.Enums;
using GSDrones.Repositories;

namespace GSDrones.Services
{
    public class MissaoService
    {
        private readonly MissaoRepository _repository;
        private readonly DroneService _droneService;
        private readonly SuprimentoService _suprimentoService;

        public MissaoService(MissaoRepository repository, DroneService droneService, SuprimentoService suprimentoService)
        {
            _repository = repository;
            _droneService = droneService;
            _suprimentoService = suprimentoService;
        }

        public async Task<List<MissaoResponseDTO>> GetAllAsync()
        {
            List<Missao> missoes = await _repository.GetAllAsync();
            return missoes.Select(MissaoResponseDTO.mapper).ToList();
        }

        public async Task<MissaoResponseDTO?> GetByIdAsync(long id)
        {
            Missao? missao = await _repository.GetByIdAsync(id);
            return missao == null ? null : MissaoResponseDTO.mapper(missao);
        }

        public async Task<(MissaoResponseDTO? response, string? error)> CreateAsync(MissaoRequestDTO dto)
        {
            Drone? drone = await _droneService.GetByIdAsync(dto.DroneId);
            if (drone == null)
                return (null, "Drone não encontrado.");

            if (drone.Missoes.Find(m => m.Status == StatusMissao.EM_ANDAMENTO) != null)
                return (null, "Drone já está em uma missão em andamento.");

            List<long> suprimentoIds = dto.Suprimentos.Select(s => s.SuprimentoId).ToList();
            List<Suprimento> suprimentos = await _suprimentoService.GetSuprimentosByIdsAsync(suprimentoIds);

            if (suprimentos.Count != suprimentoIds.Count)
                return (null, "Um ou mais suprimentos não encontrados.");

            double pesoTotal = 0;
            foreach (SuprimentoMissaoRequestDTO item in dto.Suprimentos)
            {
                Suprimento suprimento = suprimentos.First(s => s.Id == item.SuprimentoId);
                pesoTotal += suprimento.PesoKg * item.Quantidade;
            }

            if (pesoTotal > drone.CapacidadeKg)
                return (null, "Peso total dos suprimentos excede a capacidade do drone.");

            Missao missao = new Missao
            {
                Descricao = dto.Descricao,
                DroneId = dto.DroneId,
                PesoTotal = pesoTotal,
                Suprimentos = dto.Suprimentos.Select(s => new SuprimentoMissao
                {
                    SuprimentoId = s.SuprimentoId,
                    Quantidade = s.Quantidade
                }).ToList()
            };

            await _repository.AddAsync(missao);

            return (MissaoResponseDTO.mapper(missao), null);
        }

        public async Task<bool> PatchConcluirAsync(long id)
        {
            Missao? missao = await _repository.GetByIdAsync(id);
            if (missao == null) return false;
            missao.Status = StatusMissao.CONCLUIDO;
            missao.DataFim = DateTime.Now;
            await _repository.UpdateAsync(missao);
            return true;
        }

        public async Task<bool> DeleteCancelarAsync(long id)
        {
            Missao? missao = await _repository.GetByIdAsync(id);
            if (missao == null) return false;
            missao.Status = StatusMissao.CANCELADO;
            missao.DataFim = DateTime.Now;
            await _repository.UpdateAsync(missao);
            return true;
        }
    }
}