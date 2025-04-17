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
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PrestamosContext _context;

        public PrestamoRepository(PrestamosContext context)
        {
            _context = context;
        }

        public async Task Actualizar(Prestamo prestamo)
        {
            var prestamoExiste = await _context.Prestamos.AsNoTracking().FirstOrDefaultAsync(p => p.IdPrestamo == prestamo.IdPrestamo);
            if (prestamoExiste == null)
            {
                throw new Exception("El prestamo no existe");
            }
            prestamoExiste.Fecha_Devolucion = prestamo.Fecha_Prestamo != default ? prestamo.Fecha_Devolucion : prestamoExiste.Fecha_Devolucion;
            prestamoExiste.Estado = string.IsNullOrEmpty(prestamo.Estado) ? prestamoExiste.Estado : prestamo.Estado;

            _context.Prestamos.Update(prestamoExiste);
            await _context.SaveChangesAsync();

        }

        public async Task Agregar(Prestamo prestamo)
        {
            prestamo.IdPrestamo = Guid.NewGuid();
            await _context.Prestamos.AddAsync(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task<Prestamo?> BuscarPorId(Guid id)
        {
            return await _context.Prestamos
                .Include(l => l.Libro)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(p => p.IdPrestamo == id);
        }

        public async Task Eliminar(Guid id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if(prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Prestamo>> Listar()
        {
            return await _context.Prestamos
                .Include(l => l.Libro)
                .Include(u => u.Usuario)
                .ToListAsync();
        }

        public async Task<List<Prestamo>> ListarPrestamosActivos()
        {
            return await _context.Prestamos
                .Where(p => p.Estado == "Activo")
                .Include(l => l.Libro)
                .Include(u => u.Usuario)
                .ToListAsync();
        }
    }
}
