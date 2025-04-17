using Aplicacion.DTOs;
using AutoMapper;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Mappings
{
    public class LibroProfile : Profile
    {
        public LibroProfile()
        {
            CreateMap<LibroCreateDto, Libro>();
            CreateMap<Libro, LibroDto>();
            CreateMap<LibroUpdateDto, Libro>();
        }
    }
}
