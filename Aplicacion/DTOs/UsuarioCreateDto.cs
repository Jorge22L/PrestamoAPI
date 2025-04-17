using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Apellido { get; set; }
        [EmailAddress(ErrorMessage = "El campo {0} no es un correo electrónico válido.")]
        public string Email { get; set; }
        [Phone]
        public string? Telefono { get; set; }
    }
}
