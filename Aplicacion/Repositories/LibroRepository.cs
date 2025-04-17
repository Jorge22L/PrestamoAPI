using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly PrestamosContext _context;
        public LibroRepository(PrestamosContext context) => _context = context;
        public async Task Actualizar(Libro libro)
        {
            _context.Entry(libro).State = EntityState.Detached;
            var libroExistente = await _context.Libros.AsNoTracking().FirstOrDefaultAsync(l => l.IdLibro == libro.IdLibro);
            if (libroExistente == null)
            {
                throw new Exception("El libro no existe");
            }
            libroExistente.Titulo = string.IsNullOrEmpty(libro.Titulo) ? libroExistente.Titulo : libro.Titulo;
            libroExistente.Autor = string.IsNullOrEmpty(libro.Autor) ? libroExistente.Autor : libro.Autor;
            libroExistente.Disponible = libro.Disponible;

            _context.Libros.Update(libroExistente);
            await _context.SaveChangesAsync();
        }

        public async Task Agregar(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
        }

        public async Task<Libro?> BuscarPorId(Guid id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task Eliminar(Guid id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null) { 
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Libro>> Listar()
        {
            return await _context.Libros.ToListAsync();
        }
    }
}
