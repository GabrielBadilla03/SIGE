using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class AsistenciaMateria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodAsistenciaMateria { get; set; }


        [Required(ErrorMessage = "El materia es obligatorio")]
        public int MatPorDiaHorario { get; set; }

        [ForeignKey(nameof(MatPorDiaHorario))]
        public required MatPorDiaHorario MatPorDiaHorarioFK { get; set; }


        [Required(ErrorMessage = "La asistencia es obligatorio")]
        public int AsistenciaEstudiante { get; set; }

        [ForeignKey(nameof(AsistenciaEstudiante))]
        public required AsistenciaEstudiante AsistenciaEstudianteFk { get; set; }


        [Column(TypeName = "bit")]
        [Required(ErrorMessage = "Debe seleccionar la asistencia")]
        public required bool Asistio { get; set; }
    }
}
