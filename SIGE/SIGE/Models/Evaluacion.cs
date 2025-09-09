using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class Evaluacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodEvaluacion { get; set; }


        [Required(ErrorMessage = "Es olbigatorio el nombre de la asignacion")]
        [StringLength(20, ErrorMessage = "El periodo no puede tener más de 20 caracteres")]
        public required string Nombre { get; set; }


        [Required(ErrorMessage = "El valor de la evaluacion es obligatorio")]
        [Range(1, 100, ErrorMessage = "El valor de la evaluacion debe estar entre 1 y 100")]
        public int Valor { get; set; }
    }
}
