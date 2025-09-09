using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class HorarioTiempoLibre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodHorarioTiempoLibre { get; set; }


        [Required(ErrorMessage = "El dia del horario es obligatorio")]
        public int DiaHorario { get; set; }

        [ForeignKey(nameof(DiaHorario))]
        public required DiaHorario DiaHorarioFK { get; set; }


        [Required(ErrorMessage = "El tiempo libre es obligatorio")]
        public int TiempoLibre { get; set; }

        [ForeignKey(nameof(TiempoLibre))]
        public required TiempoLibre TiempoLibreFK { get; set; }
    }
}
