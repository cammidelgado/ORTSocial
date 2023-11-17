using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ORTSocial.Models
{
    public class Familiar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFamiliar { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [ForeignKey("GrupoFamiliar")]
        public int IdGrupoFamiliar { get; set; }
        public virtual GrupoFamiliar GrupoFamiliar { get; set; }
    }
}