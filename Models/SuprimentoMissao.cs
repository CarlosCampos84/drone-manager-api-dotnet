using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSDrones.Models
{
    public class SuprimentoMissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey("MissaoId")]
        public Missao Missao { get; set; }

        public long MissaoId { get; set; }

        [Required]
        [ForeignKey("SuprimentoId")]
        public Suprimento Suprimento { get; set; }

        public long SuprimentoId { get; set; }

        [Required]
        [Column("qt_suprimento")]
        public int Quantidade { get; set; }

        public SuprimentoMissao()
        {
        }
    }
}
