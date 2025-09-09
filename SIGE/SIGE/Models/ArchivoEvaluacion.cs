using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGE.Models
{
    public class ArchivoEvaluacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodArchivosEvaluacion { get; set; }


        [Required(ErrorMessage = "El código del profesor es obligatorio")]
        [MaxLength(450)]
        public required string Profesor { get; set; }

        [ForeignKey(nameof(Profesor))]
        public required ApplicationUser ProfesorFK { get; set; }


        [Required(ErrorMessage = "La evaluacion es obligatorio")]
        public int Evaluacion { get; set; }

        [ForeignKey(nameof(Evaluacion))]
        public required Evaluacion EvaluacionFK { get; set; }


        [Required(ErrorMessage = "El grado es obligatorio")]
        [StringLength(20, ErrorMessage = "El grado no puede tener más de 20 caracteres")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\s\-]+$",
        ErrorMessage = "El grado solo puede contener letras, guiones y espacios")]
        public required string Grado { get; set; }


        // ===== Campos del archivo (en wwwroot/archivos) =====

        // ej. "archivos/evaluaciones/2025/09/87c1a...f9.pdf"
        [Required, StringLength(500)]
        public required string RutaRelativa { get; set; }

        [Required, StringLength(255)]
        public required string NombreOriginal { get; set; }

        [Required, StringLength(128)]
        public required string ContentType { get; set; }

        public long TamanoBytes { get; set; }
    }
}
