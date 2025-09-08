using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class Periodo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodPeriodo { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar un periodo escolar")]
        [StringLength(20, ErrorMessage = "El periodo no puede tener más de 20 caracteres")]
        public required string Nombre { get; set; }


        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }


        [Required(ErrorMessage = "La fecha fin es obligatoria")]
        [Column(TypeName = "date")]
        public DateTime FechaFin { get; set; }
    }
}
