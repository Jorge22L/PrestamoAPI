using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<Prestamo?> BuscarPorId(Guid id);
        Task<List<Prestamo>> Listar();
        Task<List<Prestamo>> ListarPrestamosActivos();
        Task Agregar(Prestamo prestamo);
        Task Actualizar(Prestamo prestamo);
        Task Eliminar(Guid id);
    }
}
