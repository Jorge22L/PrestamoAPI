using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> BuscarPorId(Guid id);
        Task<List<Usuario>> Listar();
        Task Agregar (Usuario usuario);
        Task Actualizar(Usuario usuario);
        Task Eliminar(Guid id);
    }
}
