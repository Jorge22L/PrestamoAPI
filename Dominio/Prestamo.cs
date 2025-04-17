using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Prestamo
    {
        [Key]
        public Guid IdPrestamo { get; set; }
        public Guid? IdLibro { get; set; }
        public Libro? Libro { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public DateTime Fecha_Prestamo { get; set; }
        public DateTime Fecha_Devolucion { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
