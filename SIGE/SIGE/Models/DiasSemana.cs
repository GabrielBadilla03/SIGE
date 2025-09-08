using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class DiaSemana
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodDiaSemana { get; set; }


        [Required(ErrorMessage = "El nombre del dia de la semana es obligatorio")]
        [StringLength(15, ErrorMessage = "El nombre del dia de la semana no puede tener más de 15 caracteres")]
        public required string Nombre { get; set; }


        [Required(ErrorMessage = "La nomenclatura es obligatoria")]
        [StringLength(5, ErrorMessage = "La nomenclatura no puede tener más de 5 caracteres")]
        public required string Nomenclatura { get; set; }
    }
}
