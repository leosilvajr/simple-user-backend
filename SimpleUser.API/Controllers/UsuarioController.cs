using Microsoft.AspNetCore.Mvc;
using SimpleUser.Application.Services;
using SimpleUser.Application.DTOs;
using SimpleUser.Domain.Entities;
using System.Linq;

namespace SimpleUser.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]  // Corrigindo a rota para /api/usuarios (com "s")
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Endpoint de listagem de usuários com paginação
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var usuarios = await _usuarioService.GetAllAsync();

            var pagedUsers = usuarios.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalUsers = usuarios.Count();

            return Ok(new
            {
                items = pagedUsers,
                totalPages = (int)Math.Ceiling((double)totalUsers / pageSize),
                totalUsers
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDto)
        {
            await _usuarioService.AddAsync(usuarioDto);
            return CreatedAtAction(nameof(Get), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            await _usuarioService.UpdateAsync(id, usuarioDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}
