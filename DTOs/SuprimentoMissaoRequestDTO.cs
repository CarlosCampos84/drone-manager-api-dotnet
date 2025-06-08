using System.ComponentModel.DataAnnotations;

namespace GSDrones.DTOs
{
    public class SuprimentoMissaoRequestDTO
    {
        [Required(ErrorMessage = "O id do suprimento é obrigatório.")]
        public required long SuprimentoId { get; set; }

        [Required(ErrorMessage = "O quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public required int Quantidade { get; set; }
    }
}