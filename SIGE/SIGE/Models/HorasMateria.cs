using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class HorasMateria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodHorasMateria { get; set; }


        [Required(ErrorMessage = "La hora de inicio es obligatoria")]
        [Column(TypeName = "time")]
        public required TimeSpan HoraInicio { get; set; }


        [Required(ErrorMessage = "La hora fin es obligatoria")]
        [Column(TypeName = "time")]
        public required TimeSpan HoraFin { get; set; }
    }
}
