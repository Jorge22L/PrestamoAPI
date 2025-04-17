using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class PrestamoDto
    {
        public Guid IdPrestamo { get; set; }
        public Guid IdLibro { get; set; }
        public string? TituloLibro { get; set; }
        public Guid IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public DateTime Fecha_Prestamo { get; set; }
        public DateTime Fecha_Devolucion { get; set; }
        public string Estado { get; set; }
    }
}
