using Catedra.Models;
using Catedra.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Catedra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context=context;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUnUsuario(UserDto dto)
        {
            if(dto.RUT==null|dto.Nombre==null|dto.Correo==null|dto.Genero==null|dto.FechaNacimiento==null)
            {
                return BadRequest();
            }
            if(await _context.Users.FindAsync(dto.RUT)!=null)
            {
                return Conflict();
            }
            var usuario = new User
            {
                RUT=dto.RUT,
                Nombre=dto.Nombre,
                Correo=dto.Correo,
                Genero=dto.Genero,
                FechaNacimiento=dto.FechaNacimiento
            };
            _context.Users.Add(usuario);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosUsuarios()
        {

            return Ok();
        }
    }
}