using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class TiempoLibre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodTiempoLibre { get; set; }


        [Required(ErrorMessage = "La nombre del tiempo libre")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public required string Nombre { get; set; }


        [Required(ErrorMessage = "La hora de inicio es obligatoria")]
        [Column(TypeName = "time")]
        public required TimeSpan HoraInicio { get; set; }


        [Required(ErrorMessage = "La hora fin es obligatoria")]
        [Column(TypeName = "time")]
        public required TimeSpan HoraFin { get; set; }
    }
}
