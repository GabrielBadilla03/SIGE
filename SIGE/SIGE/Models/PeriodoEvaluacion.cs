using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class PeriodoEvaluacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodPeriodoEvaluacion { get; set; }


        [Required(ErrorMessage = "La evaluacion es obligatorio")]
        public int Evaluaciones { get; set; }

        [ForeignKey(nameof(Evaluaciones))]
        public required Evaluaciones EvaluacionesFK { get; set; }


        [Required(ErrorMessage = "El periodo es obligatorio")]
        public int Periodo { get; set; }

        [ForeignKey(nameof(Periodo))]
        public required Periodo PeriodoFK { get; set; }
    }
}
