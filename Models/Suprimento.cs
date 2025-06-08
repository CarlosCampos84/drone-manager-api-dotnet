using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSDrones.Models
{
    public class Suprimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("nm_suprimento", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Required]
        [Column("ds_suprimento", TypeName = "VARCHAR(500)")]
        public string Descricao { get; set; }

        [Required]
        [Column("peso_kg")]
        public double PesoKg { get; set; }

        public List<SuprimentoMissao> Missoes { get; set; } = [];

        public Suprimento()
        {
        }
    }
}
