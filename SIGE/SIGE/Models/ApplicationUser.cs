using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SIGE.Models
{
    public class ApplicationUser : IdentityUser
    {
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

        [Required(ErrorMessage = "El Aula es obligatoria")]
        [StringLength(10, ErrorMessage = "El aula no puede tener más de 10 caracteres")]
        public required string Aula { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede tener más de 200 caracteres")]
        public string? Direccion { get; set; }
    }
}
