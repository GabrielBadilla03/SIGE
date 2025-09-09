using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class MateriaProfesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodMateriaProfesor { get; set; }


        [Required(ErrorMessage = "Es necesario seleccionar una materia")]
        public required int Materia { get; set; }

        [ForeignKey(nameof(Materia))]  
        public required Materia MateriaFK { get; set; }


        [Required(ErrorMessage = "Es necesario seleccionar un profesor@")]
        [MaxLength(450)]
        public string Profesor { get; set; } = default!;

        [ForeignKey(nameof(Profesor))]
        public required ApplicationUser ProfesorFK { get; set; }


        public int? Aula { get; set; }

        [ForeignKey(nameof(Aula))]
        public Aula? AulaFK { get; set; }
    }
}
