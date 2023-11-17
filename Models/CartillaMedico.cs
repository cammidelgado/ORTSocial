using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ORTSocial.Models
{
    public class CartillaMedico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCartillaMedico { get; set; }

        [ForeignKey("Cartilla")]
        public int IdCartilla { get; set; }
        public virtual Cartilla Cartilla { get; set; }
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        public virtual Medico Medico { get; set; }
    }
}