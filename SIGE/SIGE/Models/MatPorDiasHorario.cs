using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class MatPorDiasHorario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodMatPorDiasHorario { get; set; }


        [Required(ErrorMessage = "La materia y profesor es obligatorio")]
        public int MateriasProfesor { get; set; }

        [ForeignKey(nameof(MateriasProfesor))]
        public required MateriasProfesor MateriasProfesorFK { get; set; }


        [Required(ErrorMessage = "El dia del horario es obligatorio")]
        public int DiasHorario { get; set; }

        [ForeignKey(nameof(DiasHorario))]
        public required DiasHorario DiasHorarioFK { get; set; }


        [Required(ErrorMessage = "La hora de la materia es obligatorio")]
        public int HorasMateria { get; set; }

        [ForeignKey(nameof(HorasMateria))]
        public required HorasMateria HorasMateriaFK { get; set; }


        [Required(ErrorMessage = "El código del aula es obligatorio")]
        public int Aula { get; set; }

        [ForeignKey(nameof(Aula))]
        public required Aula AulaFK { get; set; }
    }
}
