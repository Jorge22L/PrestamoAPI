using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using AutoMapper;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> Agregar(UsuarioCreateDto usuarioCreateDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioCreateDto);
            usuario.IdUsuario = Guid.NewGuid();
            await _usuarioRepository.Agregar(usuario);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto?> Actualizar(UsuarioUpdateDto usuarioUpdateDto)
        {
            var usuarioExiste = await _usuarioRepository.BuscarPorId(usuarioUpdateDto.IdUsuario);
            if (usuarioExiste == null) return null;
            
            _mapper.Map(usuarioUpdateDto, usuarioExiste);
            await _usuarioRepository.Actualizar(usuarioExiste);
            return _mapper.Map<UsuarioDto>(usuarioExiste);

        }

        public async Task<bool> Eliminar(Guid id)
        {
            var usuario = await _usuarioRepository.BuscarPorId(id);
            if (usuario == null) return false;
            await _usuarioRepository.Eliminar(id);
            return true;
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _usuarioRepository.Listar();
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _usuarioRepository.BuscarPorId(id);
        }
    }
}
