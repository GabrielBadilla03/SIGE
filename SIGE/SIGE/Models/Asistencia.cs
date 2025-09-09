using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class Asistencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodAsistencia { get; set; }


        [Required(ErrorMessage = "El grupo es obligatorio")]
        public int Grupo { get; set; }

        [ForeignKey(nameof(Grupo))]
        public required Grupo GrupoFk { get; set; }


        [Required(ErrorMessage = "La fecha de asistencia es obligatoria")]
        [Column(TypeName = "date")]
        public DateTime FechaAsistencia { get; set; }


        [Required(ErrorMessage = "El dia de la semana es obligatorio")]
        public int DiaSemana { get; set; }

        [ForeignKey(nameof(DiaSemana))]
        public required DiaSemana DiaSemanaFK { get; set; }
    }
}
