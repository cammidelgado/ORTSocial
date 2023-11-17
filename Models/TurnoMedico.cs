using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ORTSocial.Models
{
    public class TurnoMedico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTurno { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        public virtual Medico Medico { get; set; }

        [ForeignKey("Socio")]
        public int IdSocio { get; set; }
        public virtual Socio Socio { get; set; }
    }
}
