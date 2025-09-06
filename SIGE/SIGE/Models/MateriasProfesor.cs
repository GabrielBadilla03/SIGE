using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class MateriasProfesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodMateriaProfesor { get; set; }

        [Required(ErrorMessage = "Es necesario seleccionar una materia")]
        public int Materia { get; set; }
        [ForeignKey(nameof(Materia))]  
        public Materia MateriaFK { get; set; } = default!;


        [Required(ErrorMessage = "Es necesario seleccionar un profesor@")]
        [MaxLength(450)]
        public string Profesor { get; set; } = default!;

        [ForeignKey(nameof(Profesor))]
        public ApplicationUser ProfesorFK { get; set; } = default!;
    }
}
