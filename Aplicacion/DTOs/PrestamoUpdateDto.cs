using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class PrestamoUpdateDto
    {
        [Required]
        public Guid IdPrestamo { get; set; }
        public DateTime? Fecha_Devolucion { get; set; }
        public string? Estado { get; set; }
    }
}
