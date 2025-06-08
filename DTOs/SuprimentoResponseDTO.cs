using GSDrones.Models;

namespace GSDrones.DTOs
{
    public class SuprimentoResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PesoKg { get; set; }

        public static SuprimentoResponseDTO Mapper(Suprimento suprimento)
        {
            return new SuprimentoResponseDTO
            {
                Id = suprimento.Id,
                Nome = suprimento.Nome,
                Descricao = suprimento.Descricao,
                PesoKg = suprimento.PesoKg
            };
        }
    }
}