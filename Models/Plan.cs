using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ORTSocial.Models
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlan { get; set; }
        public string Nombre { get; set; }
        public float Costo { get; set; }
        public int CantFamiliares { get; set; }
        [ForeignKey("Cartilla")]
        public int IdCartilla { get; set; }
        public virtual Cartilla Cartilla { get; set; }
    }
}