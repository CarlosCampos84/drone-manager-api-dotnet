using GSDrones.DTOs;
using GSDrones.Models;
using GSDrones.Repositories;

namespace GSDrones.Services
{
    public class SuprimentoService
    {
        private readonly SuprimentoRepository _repository;

        public SuprimentoService(SuprimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuprimentoResponseDTO>> GetAllAsync()
        {
            List<Suprimento> suprimentos = await _repository.GetAllAsync();
            return suprimentos.Select(SuprimentoResponseDTO.Mapper).ToList();
        }

        public async Task<SuprimentoResponseDTO?> GetByIdAsync(long id)
        {
            Suprimento? s = await _repository.GetByIdAsync(id);
            return s == null ? null : SuprimentoResponseDTO.Mapper(s);
        }

        public async Task<List<Suprimento>> GetSuprimentosByIdsAsync(List<long> ids)
        {
            return await _repository.GetSuprimentosByIdsAsync(ids);
        }

        public async Task<SuprimentoResponseDTO> CreateAsync(SuprimentoRequestDTO dto)
        {
            Suprimento suprimento = new Suprimento
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                PesoKg = dto.PesoKg
            };
            await _repository.AddAsync(suprimento);
            return SuprimentoResponseDTO.Mapper(suprimento);
        }

        public async Task<bool> UpdateAsync(long id, SuprimentoRequestDTO dto)
        {
            Suprimento? suprimento = await _repository.GetByIdAsync(id);
            if (suprimento == null) return false;
            suprimento.Nome = dto.Nome;
            suprimento.Descricao = dto.Descricao;
            suprimento.PesoKg = dto.PesoKg;
            await _repository.UpdateAsync(suprimento);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            Suprimento? suprimento = await _repository.GetByIdAsync(id);
            if (suprimento == null) return false;
            await _repository.DeleteAsync(suprimento);
            return true;
        }
    }
}