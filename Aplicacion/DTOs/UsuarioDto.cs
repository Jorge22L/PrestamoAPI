﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class UsuarioDto
    {
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
