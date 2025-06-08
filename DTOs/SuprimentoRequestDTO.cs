using System.ComponentModel.DataAnnotations;

namespace GSDrones.DTOs
{
    public class SuprimentoRequestDTO
    {
        [Required(ErrorMessage = "O nome do suprimento é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O peso é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O peso deve ser maior que 0.")]
        public required double PesoKg { get; set; }
    }
}