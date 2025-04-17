using Aplicacion.DTOs;
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
    public class LibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository libroRepository, IMapper mapper)
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
        }

        public async Task<List<Libro>> Listar()
        {
            return await _libroRepository.Listar();
        }

        public async Task<Libro?> BuscarPorId(Guid id)
        {
            return await _libroRepository.BuscarPorId(id);
        }

        public async Task<LibroDto> Agregar (LibroCreateDto libroCreateDto)
        {
            var libro = _mapper.Map<Libro>(libroCreateDto);
            libro.IdLibro = Guid.NewGuid();
            await _libroRepository.Agregar(libro);
            return _mapper.Map<LibroDto>(libro);
        }

        public async Task<LibroDto?> Actualizar(LibroUpdateDto libroUpdateDto)
        {
            var libro = await _libroRepository.BuscarPorId(libroUpdateDto.IdLibro);
            if (libro == null)
            {
                return null;
            }

            libro.Titulo = libroUpdateDto.Titulo != null ? libroUpdateDto.Titulo : libro.Titulo;
            libro.Autor = libroUpdateDto.Autor != null ? libroUpdateDto.Autor : libro.Autor;
            libro.Disponible = libroUpdateDto.Disponible != null ? libroUpdateDto.Disponible : libro.Disponible;

            await _libroRepository.Actualizar(libro);
            return _mapper.Map<LibroDto>(libro);
        }

        public async Task<bool> Eliminar(Guid id)
        {
            var libro = await _libroRepository.BuscarPorId(id);
            if(libro == null)
            {
                return false;
            }
            await _libroRepository.Eliminar(id);
            return true;
        }

    }
}
