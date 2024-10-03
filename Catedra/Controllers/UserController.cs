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
        private readonly string[] Generos = {"masculino","femenino","otro","prefiero no decirlo"};

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
            if(!Generos.Contains(dto.Genero))
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
        public async Task<IActionResult> ObtenerTodosLosUsuarios(string? sort, string? gender)
        {
            var egg= await _context.Users.ToListAsync();
            if(sort!=null)
            {
                if(gender!=null)
                {
                    if(gender=="masculino"|gender=="femenino"|gender=="otro"|gender=="prefiero no decirlo")
                    {
                        egg= await _context.Users.Where(p=>p.Genero==gender).ToListAsync();
                    }
                }
            }
            return Ok(egg);
        }

        [HttpPut]
        [Route("/user/{RUT}")]
        public async Task<IActionResult> EditarUnUsuario(UserDto dto)
        {
            var Update=await _context.Users.FindAsync(dto.RUT);
            if(Update==null)
            {
                return NotFound();
            }
            Update.RUT=dto.RUT;
            Update.Nombre=dto.Nombre;
            Update.Correo=dto.Correo;
            Update.Genero=dto.Genero;
            Update.FechaNacimiento=dto.FechaNacimiento;
            _context.Update(Update);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("/user/{RUT}")]
        public async Task<IActionResult> EliminarUnUsuario(string RUT)
        {
            var deletethis = await _context.Users.FindAsync(RUT);
            if(deletethis==null)
            {
                return NotFound();
            }
            _context.Users.Remove(deletethis);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}