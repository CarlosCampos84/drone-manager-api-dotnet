using GSDrones.Models;
using GSDrones.Models.Enums;

namespace GSDrones.DTOs
{
    public class MissaoResponseDTO
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public StatusMissao Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DroneResponseDTO Drone { get; set; }
        public List<SuprimentoMissaoResponseDTO> Suprimentos { get; set; }
        public double PesoTotal { get; set; }

        public static MissaoResponseDTO mapper(Missao missao)
        {
            return new MissaoResponseDTO
            {
                Id = missao.Id,
                Descricao = missao.Descricao,
                Status = missao.Status,
                DataInicio = missao.DataInicio,
                DataFim = missao.DataFim,
                Drone = DroneResponseDTO.mapper(missao.Drone),
                PesoTotal = missao.PesoTotal,
                Suprimentos = missao.Suprimentos.Select(sm =>
                    new SuprimentoMissaoResponseDTO(
                        SuprimentoResponseDTO.Mapper(sm.Suprimento),
                        sm.Quantidade
                    )).ToList()
            };
        }
    }
}