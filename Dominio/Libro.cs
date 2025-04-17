using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Libro
    {

        [Key]
        public Guid IdLibro { get; set; }
        public required string Titulo {  get; set; }
        public required string Autor {  get; set; }
        public bool Disponible { get; set; } = true;
        public ICollection<Prestamo>? Prestamos { get; set; }
    }
}
