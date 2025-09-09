using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class DiaHorario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodDiaHorario { get; set; }


        [Required(ErrorMessage = "Se requiere seleccionar un turno escolar")]
        [StringLength(20, ErrorMessage = "El nombre no puede tener más de 20 caracteres")]
        public required string TurnoEscolar { get; set; }


        [Required(ErrorMessage = "La hora de inicio es obligatoria")]
        [Column(TypeName = "time")]
        public required TimeSpan HoraInicio { get; set; }


        [Required(ErrorMessage = "La hora fin es obligatoria")]
        [Column(TypeName = "time")]
        public required TimeSpan HoraFin { get; set; }


        [Required(ErrorMessage = "El dia de la semana es obligatorio")]
        public int DiaSemana { get; set; }

        [ForeignKey(nameof(DiaSemana))]
        public required DiaSemana DiaSemanaFK { get; set; }


        [Required(ErrorMessage = "El grupo es obligatorio")]
        public int Grupo { get; set; }

        [ForeignKey(nameof(Grupo))]
        public required Grupo GrupoFk { get; set; }


    }
}
