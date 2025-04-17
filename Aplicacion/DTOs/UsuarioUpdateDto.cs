using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class UsuarioUpdateDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [EmailAddress(ErrorMessage = "El campo {0} no es un correo electrónico válido.")]
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
