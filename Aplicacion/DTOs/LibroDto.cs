﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class LibroDto
    {
        public Guid IdLibro {  get; set; }
        public string Titulo {  get; set; }
        public string Autor { get; set; }
        public bool Disponible { get; set; }
    }
}
