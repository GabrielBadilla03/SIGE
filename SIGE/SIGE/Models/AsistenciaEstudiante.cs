using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class AsistenciaEstudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodAsistenciaEstudiante { get; set; }


        [Required(ErrorMessage = "El grupo es obligatorio")]
        public int Asistencia { get; set; }

        [ForeignKey(nameof(Asistencia))]
        public required Asistencia AsistenciaFk { get; set; }


        [Required(ErrorMessage = "El estudiante es obligatorio")]
        public int Estudiante { get; set; }

        [ForeignKey(nameof(Estudiante))]
        public required Estudiante EstudianteFk { get; set; }


        [Column(TypeName = "bit")]
        [Required(ErrorMessage = "Debe seleccionar la asistencia")]
        public required bool Asistio { get; set; }
    }
}
