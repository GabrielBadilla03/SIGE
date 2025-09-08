using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class Grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodGrupo { get; set; }


        [Required(ErrorMessage = "La sección es obligatoria")]
        [StringLength(5)]
        public required string Seccion { get; set; }


        [Required(ErrorMessage = "El grado es obligatorio")]
        [StringLength(20, ErrorMessage = "El grado no puede tener más de 20 caracteres")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\s\-]+$",
        ErrorMessage = "El grado solo puede contener letras, guiones y espacios")]
        public required string Grado { get; set; }


        [Required(ErrorMessage = "La capacidad máxima es obligatoria")]
        [Range(1, 60, ErrorMessage = "La capacidad máxima debe estar entre 1 y 60")]
        public int CapacidadMaxima { get; set; }


        [Required(ErrorMessage = "El año lectivo es obligatorio")]
        [Range(2000, 9000, ErrorMessage = "El año lectivo debe estar entre 2000 y 9000")]
        public int AñoLectivo { get; set; }


        [Column(TypeName = "bit")]
        [Required(ErrorMessage = "Debe seleccionar el estado")]
        public required bool Estado { get; set; }


        [Required(ErrorMessage = "El código del aula es obligatorio")]
        public int Aula { get; set; }

        [ForeignKey(nameof(Aula))]
        public required Aula AulaFK { get; set; }


        [Required(ErrorMessage = "El código del profesor es obligatorio")]
        [MaxLength(450)]
        public required string Profesor { get; set; }

        [ForeignKey(nameof(Profesor))]
        public required ApplicationUser ProfesorFK { get; set; } 
    }
}
