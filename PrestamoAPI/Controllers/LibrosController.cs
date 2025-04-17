using Aplicacion.DTOs;
using Aplicacion.Services;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace PrestamoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibroService _libroService;
        public LibrosController(LibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> Listar()
        {
            return Ok(await _libroService.Listar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Libro?>> BuscarPorId(Guid id)
        {
            var libro = await _libroService.BuscarPorId(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        [HttpPost]
        public async Task<ActionResult<LibroDto>> Agregar([FromBody] LibroCreateDto libroCreateDto)
        {
            var libro = await _libroService.Agregar(libroCreateDto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = libro.IdLibro }, libro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LibroDto>> Actualizar(Guid id, [FromBody]LibroUpdateDto libroUpdateDto)
        {
            if(id != libroUpdateDto.IdLibro)
            {
                return BadRequest("El ID del libro no existe");
            }

            var libroActualizado = await _libroService.Actualizar(libroUpdateDto);

            if(libroActualizado == null)
            {
                return NotFound();
            }

            return Ok(libroActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(Guid id)
        {
            var eliminado = await _libroService.Eliminar(id);
            if (!eliminado)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
