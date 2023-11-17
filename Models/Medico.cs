using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ORTSocial.Models
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public ICollection<TurnoMedico>? TurnosMedicos { get; set; }
        [EnumDataType(typeof(Especialidad))]
        public Especialidad Especialidad { get; set; }
    }
}