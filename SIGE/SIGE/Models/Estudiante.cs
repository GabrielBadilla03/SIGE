using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodEstudiante { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(25, ErrorMessage = "El nombre no puede tener más de 25 caracteres")]
        public required string Nombre { get; set; }


        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [StringLength(25, ErrorMessage = "El apellido no puede tener más de 25 caracteres")]
        public required string Apellido1 { get; set; }


        [StringLength(25, ErrorMessage = "El segundo apellido no puede tener más de 25 caracteres")]
        public string? Apellido2 { get; set; }


        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(25, ErrorMessage = "La cédula no puede tener más de 25 caracteres")]
        public required string Cedula { get; set; }


        [Required(ErrorMessage = "El grado es obligatorio")]
        [StringLength(20, ErrorMessage = "El grado no puede tener más de 20 caracteres")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\s\-]+$",
        ErrorMessage = "El grado solo puede contener letras, guiones y espacios")]
        public required string Grado { get; set; }



        [Required(ErrorMessage = "El grupo es obligatorio")]
        public int Grupo { get; set; }

        [ForeignKey(nameof(Grupo))]
        public required Grupo GrupoFk { get; set; }
    }
}
