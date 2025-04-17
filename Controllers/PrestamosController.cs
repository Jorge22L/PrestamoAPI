using Aplicacion.DTOs;
using Aplicacion.Services;
using Microsoft.AspNetCore.Mvc;

namespace PrestamoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly PrestamoService _prestamoService;

        public PrestamosController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrestamoDto>>> Listar()
        {
            var prestamos = await _prestamoService.Listar();
            return Ok(prestamos);
        }

        [HttpGet("activos")]
        public async Task<ActionResult<List<PrestamoDto>>> ListarPrestamosActivos()
        {
            var prestamosActivos = await _prestamoService.ListarPrestamosActivos();
            return Ok(prestamosActivos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamoDto>> BuscarPorId(Guid id)
        {
            var prestamo = await _prestamoService.BuscarPorId(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return Ok(prestamo);
        }

        [HttpPost]
        public async Task<ActionResult<PrestamoDto>> Agregar([FromBody] PrestamoCreateDto prestamoCreateDto)
        {
            try
            {
                var prestamoDto = await _prestamoService.Agregar(prestamoCreateDto);
                return CreatedAtAction(nameof(BuscarPorId), new { id = prestamoDto.IdPrestamo }, prestamoDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{idPrestamo}")]
        public async Task<ActionResult<PrestamoDto>> Actualizar(Guid idPrestamo, [FromBody] PrestamoUpdateDto prestamoUpdateDto)
        {
            if(idPrestamo != prestamoUpdateDto.IdPrestamo)
            {
                return BadRequest("El id del prestamo no coincide");
            }

            var prestamoDto = await _prestamoService.Actualizar(prestamoUpdateDto);
            if (prestamoDto == null)
            {
                return NotFound();
            }
            return Ok(prestamoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(Guid id)
        {
            var prestamoEliminado = await _prestamoService.Eliminar(id);
            if (prestamoEliminado == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
