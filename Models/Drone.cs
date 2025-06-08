using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GSDrones.Models.Enums;

namespace GSDrones.Models
{
    public class Drone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("nm_drone", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Required]
        [Column("tp_drone")]
        public TipoDrone Tipo { get; set; }

        [Required]
        [Column("nr_capacidade_kg")]
        public double CapacidadeKg { get; set; }

        public List<Missao> Missoes { get; set; } = [];
        
        public Drone()
        {
        }
    }
}
