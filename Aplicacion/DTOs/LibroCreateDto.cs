using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class LibroCreateDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public required string Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        public required string Autor { get; set; }
        public bool Disponible { get; set; }
    }
}
