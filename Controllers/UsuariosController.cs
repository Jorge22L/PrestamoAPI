using Aplicacion.DTOs;
using Aplicacion.Services;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace PrestamoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Listar()
        {
            return Ok(await _usuarioService.Listar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> BuscarPorId(Guid id)
        {
            var usuario = await _usuarioService.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Agregar([FromBody] UsuarioCreateDto usuarioCreateDto)
        {
            var usuario = await _usuarioService.Agregar(usuarioCreateDto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDto>> Actualizar(Guid id, [FromBody] UsuarioUpdateDto usuarioUpdateDto)
        {
            if (id != usuarioUpdateDto.IdUsuario)
            {
                return BadRequest("El ID del usuario no existe");
            }

            var usuario = await _usuarioService.Actualizar(usuarioUpdateDto);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var eliminado = await _usuarioService.Eliminar(id);
            if(!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
