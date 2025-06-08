using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GSDrones.Models.Enums;

namespace GSDrones.Models
{
    public class Missao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("ds_missao", TypeName = "VARCHAR(500)")]
        public string Descricao { get; set; }

        [Required]
        [Column("dt_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("dt_fim")]
        public DateTime? DataFim { get; set; }

        [Required]
        [Column("st_missao")]
        public StatusMissao Status { get; set; }

        [Required]
        [Column("nr_peso_total")]
        public double PesoTotal { get; set; }

        [ForeignKey("DroneId")]
        public Drone Drone { get; set; }

        public long DroneId { get; set; }

        public List<SuprimentoMissao> Suprimentos { get; set; } = [];

        public Missao()
        {
            DataInicio = DateTime.Now;
            Status = StatusMissao.EM_ANDAMENTO;
        }
    }
}
