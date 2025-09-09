using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class Calificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodCalificacion { get; set; }


        [Required(ErrorMessage = "La Asignacion es obligatorio")]
        public int Asignacion { get; set; }

        [ForeignKey(nameof(Asignacion))]
        public required Asignacion AsignacionFk { get; set; }


        [Required(ErrorMessage = "El estudiante es obligatorio")]
        public int Estudiante { get; set; }

        [ForeignKey(nameof(Estudiante))]
        public required Estudiante EstudianteFk { get; set; }


        [Required(ErrorMessage = "La nota de la evaluacion es obligatorio")]
        [Range(1, 100, ErrorMessage = "La nota de la evaluacion debe estar entre 1 y 100")]
        public int Nota { get; set; }


        [Required(ErrorMessage = "La fecha de calificacion es obligatoria")]
        [Column(TypeName = "date")]
        public DateTime FechaCalificacion { get; set; }


        [StringLength(250, ErrorMessage = "Las observaciones no puede tener más de 250 caracteres")]
        public string? Observaciones { get; set; }
    }
}
