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
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioUpdateDto, Usuario>();
        }
    }
}
