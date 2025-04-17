using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class PrestamoCreateDto
    {
        [Required]
        public Guid IdLibro { get; set; }
        [Required]
        public Guid IdUsuario { get; set; }
        [Required]
        public DateTime Fecha_Devolucion { get; set; }
    }
}
