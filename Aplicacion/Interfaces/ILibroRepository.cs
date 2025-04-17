using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> Listar();
        Task<Libro?> BuscarPorId(Guid id);
        Task Agregar(Libro libro);
        Task Actualizar(Libro libro);
        Task Eliminar(Guid id);
    }
}
