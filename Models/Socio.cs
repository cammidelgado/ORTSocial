using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ORTSocial.Models
{
    public class Socio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSocio { get; set; }
        public int Dni { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public int Telefono { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public ICollection<TurnoMedico>? TurnosMedicos { get; set; }

        [ForeignKey("Plan")]
        public int IdPlan { get; set; }
        public virtual Plan Plan { get; set; }

        [ForeignKey("GrupoFamiliar")]
        public int IdGrupoFamiliar { get; set; }
        public virtual GrupoFamiliar GrupoFamiliar { get; set; }
    }
}
