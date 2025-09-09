using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class Asignacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodAsignacion { get; set; }


        [Required(ErrorMessage = "El perido y evaluacion es obligatorio")]
        public int PeriodoEvaluacion { get; set; }

        [ForeignKey(nameof(PeriodoEvaluacion))]
        public required PeriodoEvaluacion PerdioEvaluacionFK { get; set; }


        [Required(ErrorMessage = "Es necesario seleccionar una materia")]
        public required int Materia { get; set; }

        [ForeignKey(nameof(Materia))]
        public required Materia MateriaFK { get; set; }


        [Required(ErrorMessage = "El grupo es obligatorio")]
        public int Grupo { get; set; }

        [ForeignKey(nameof(Grupo))]
        public required Grupo GrupoFk { get; set; }


        public int? ArchivoEvaluacion { get; set; }

        [ForeignKey(nameof(ArchivoEvaluacion))]
        public ArchivoEvaluacion? ArchivosEvaluacionFk { get; set; }


        [Required(ErrorMessage = "El numero de evaluacion es obligatorio")]
        [Range(0, 10, ErrorMessage = "El numero de evaluacion debe estar entre 0 y 10")]
        public int NumeroEvaluacion { get; set; }


        [Required(ErrorMessage = "La fecha de asignacion es obligatoria")]
        [Column(TypeName = "date")]
        public DateTime FechaAsignacion { get; set; }


        [Required(ErrorMessage = "La fecha conclusion es obligatoria")]
        [Column(TypeName = "date")]
        public DateTime FechaConclusion { get; set; }
    }
}
