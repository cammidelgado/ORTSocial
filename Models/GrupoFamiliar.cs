using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ORTSocial.Models
{
    public class GrupoFamiliar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupoFamiliar { get; set; }
        public string Nombre { get; set; }

        public int Cantidad { get; set; }
        public virtual ICollection<Familiar>? Familiares { get; set; }
    }
}