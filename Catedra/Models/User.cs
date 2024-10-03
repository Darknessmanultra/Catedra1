using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Catedra.Models
{
    public class User
    {
        [Key]
        public string RUT {get;set;}
        [Required]
        [StringLength(100)]
        public string Nombre {get; set;}
        [Required]
        [EmailAddress]
        public string Correo {get; set;}
        [Required]
        public string Genero {get; set;}
        [Required]
        public DateOnly FechaNacimiento {get; set;}
    }
}