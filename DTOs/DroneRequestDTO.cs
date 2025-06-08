using System.ComponentModel.DataAnnotations;
using GSDrones.Models.Enums;

namespace GSDrones.DTOs
{
    public class DroneRequestDTO
    {
        [Required(ErrorMessage = "O nome do drone é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do drone deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }
        private TipoDrone _type { get; set; }
        public required string Tipo
        {
            get => _type.ToString();
            set
            {
                if (Enum.TryParse<TipoDrone>(value, true, out var tipo))
                {
                    _type = tipo;
                }
                else
                {
                    throw new ArgumentException($"Tipo do drone inválido. Valores aceitos: {string.Join(", ", Enum.GetNames(typeof(TipoDrone)))}");
                }
            }
        }
        
        [Required(ErrorMessage = "A capacidade do drone em kg é obrigatória.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "A capacidade do drone deve ser maior que 0 kg.")]
        public required double CapacidadeKg { get; set; }
    }
}