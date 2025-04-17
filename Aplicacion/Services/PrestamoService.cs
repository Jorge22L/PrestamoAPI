using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Services
{
    public class PrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly ILibroRepository _libroRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public PrestamoService(IPrestamoRepository prestamoRepository, ILibroRepository libroRepository, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _prestamoRepository = prestamoRepository;
            _libroRepository = libroRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<PrestamoDto> Agregar(PrestamoCreateDto prestamoCreateDto)
        {
            if (prestamoCreateDto.IdLibro == null)
            {
                throw new Exception("El libro es requerido");
            }
            var libro = await _libroRepository.BuscarPorId(prestamoCreateDto.IdLibro);
            var usuario = await _usuarioRepository.BuscarPorId(prestamoCreateDto.IdUsuario);

            if(libro == null || usuario == null)
            {
                throw new Exception("El libro o el usuario no existen");
            }

            var prestamo = new Prestamo
            {
                IdPrestamo = Guid.NewGuid(),
                IdLibro = prestamoCreateDto.IdLibro,
                Libro = libro,
                IdUsuario = prestamoCreateDto.IdUsuario,
                Usuario = usuario,
                Fecha_Prestamo = DateTime.UtcNow,
                Fecha_Devolucion = prestamoCreateDto.Fecha_Devolucion,
                Estado = "Activo",
            };

            await _prestamoRepository.Agregar(prestamo);
            return _mapper.Map<PrestamoDto>(prestamo);

        }

        public async Task<List<PrestamoDto>> Listar()
        {
            var prestamos = await _prestamoRepository.Listar();
            return _mapper.Map<List<PrestamoDto>>(prestamos);
        }

        public async Task<List<PrestamoDto>> ListarPrestamosActivos()
        {
            var prestamosActivos = await _prestamoRepository.ListarPrestamosActivos();
            return _mapper.Map<List<PrestamoDto>>(prestamosActivos);
        }

        public async Task<PrestamoDto?> BuscarPorId(Guid id)
        {
            var prestamo = await _prestamoRepository.BuscarPorId(id);
            if (prestamo == null) return null;
            return _mapper.Map<PrestamoDto>(prestamo);
        }

        public async Task<PrestamoDto> Actualizar(PrestamoUpdateDto prestamoUpdateDto)
        {
            var prestamoExiste = await _prestamoRepository.BuscarPorId(prestamoUpdateDto.IdPrestamo);
            if (prestamoExiste == null) return null;

            if(prestamoUpdateDto.Fecha_Devolucion.HasValue)
            {
                prestamoExiste.Fecha_Devolucion = prestamoUpdateDto.Fecha_Devolucion.Value;
            }

            if(!string.IsNullOrEmpty(prestamoUpdateDto.Estado))
            {
                prestamoExiste.Estado = prestamoUpdateDto.Estado;
            }

            await _prestamoRepository.Actualizar(prestamoExiste);
            return _mapper.Map<PrestamoDto>(prestamoExiste);
        }

        public async Task<bool> Eliminar(Guid id)
        {
            var prestamo = await _prestamoRepository.BuscarPorId(id);
            if (prestamo == null) return false;
            await _prestamoRepository.Eliminar(id);
            return true;
        }
    }
}
