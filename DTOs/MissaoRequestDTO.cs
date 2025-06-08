using System.ComponentModel.DataAnnotations;

namespace GSDrones.DTOs
{
    public class MissaoRequestDTO
    {
        [Required(ErrorMessage = "A descrição da missão é obrigatória.")]
        [StringLength(100, ErrorMessage = "A descrição da missão deve ter no máximo 100 caracteres.")]
        public required string Descricao { get; set; }
        [Required(ErrorMessage = "O ID do drone é obrigatório.")]
        public required long DroneId { get; set; }
        [Required]
        public required List<SuprimentoMissaoRequestDTO> Suprimentos { get; set; }
    }
}