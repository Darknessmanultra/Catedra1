using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra.DTOs
{
    public class UserDto
    {
        public string RUT {get;set;}       
        public string Nombre {get; set;}  
        public string Correo {get; set;}
        public string Genero {get; set;}
        public DateOnly FechaNacimiento {get; set;}
    }
}