using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class HorariosTiempoLibre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodHorariosTiempoLibre { get; set; }


        [Required(ErrorMessage = "El dia del horario es obligatorio")]
        public int DiasHorario { get; set; }

        [ForeignKey(nameof(DiasHorario))]
        public required DiasHorario DiasHorarioFK { get; set; }


        [Required(ErrorMessage = "El tiempo libre es obligatorio")]
        public int TiempoLibre { get; set; }

        [ForeignKey(nameof(TiempoLibre))]
        public required TiempoLibre TiempoLibreFK { get; set; }
    }
}
