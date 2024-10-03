using Catedra.Models;
using Catedra.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("/user")]
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
        [Route("/user")]
        public async Task<IActionResult> ObtenerTodosLosUsuarios()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut]
        [Route("/user/{RUT}")]
        public async Task<IActionResult> EditarUnUsuario()
        {

            return Ok();
        }
        [HttpDelete]
        [Route("/user/{RUT}")]
        public async Task<IActionResult> EliminarUnUsuario()
        {
            return Ok();
        }
    }
}