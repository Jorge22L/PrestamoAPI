using Aplicacion.Interfaces;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PrestamosContext _context;

        public UsuarioRepository(PrestamosContext context)
        {
            _context = context;
        }

        public async Task Actualizar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Detached;
            var usuarioExiste = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.IdUsuario == usuario.IdUsuario);
            if (usuarioExiste == null)
            {
                throw new Exception("El usuario no existe");
            }
            usuarioExiste.Nombre = string.IsNullOrEmpty(usuario.Nombre) ? usuarioExiste.Nombre : usuario.Nombre;
            usuarioExiste.Apellido = string.IsNullOrEmpty(usuario.Apellido) ? usuarioExiste.Apellido : usuario.Apellido;
            usuarioExiste.Email = string.IsNullOrEmpty(usuario.Email) ? usuarioExiste.Email : usuario.Email;
            usuarioExiste.Telefono = string.IsNullOrEmpty(usuario.Telefono) ? usuarioExiste.Telefono : usuario.Telefono;

            _context.Usuarios.Update(usuarioExiste);
            await _context.SaveChangesAsync();
        }

        public async Task Agregar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task Eliminar(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
