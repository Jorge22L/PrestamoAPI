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
    public class PrestamoProfile : Profile
    {
        public PrestamoProfile()
        {
            CreateMap<PrestamoCreateDto, Prestamo>()
                .ForMember(dest => dest.IdPrestamo, opt => opt.Ignore())
                .ForMember(dest => dest.Fecha_Prestamo, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => "Activo"))
                .ForMember(dest => dest.Libro, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore()); ;

            CreateMap<Prestamo, PrestamoDto>()
                .ForMember(dest => dest.IdPrestamo, opt => opt.MapFrom(src => src.IdPrestamo))
                .ForMember(dest => dest.IdLibro, opt => opt.MapFrom(src => src.IdLibro))
                .ForMember(dest => dest.TituloLibro, opt => opt.MapFrom(src => src.Libro!.Titulo))
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario!.Nombre))
                .ForMember(dest => dest.Fecha_Prestamo, opt => opt.MapFrom(src => src.Fecha_Prestamo))
                .ForMember(dest => dest.Fecha_Devolucion, opt => opt.MapFrom(src => src.Fecha_Devolucion))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));

            CreateMap<PrestamoUpdateDto, Prestamo>()
                .ForMember(dest => dest.IdPrestamo, opt => opt.MapFrom(src => src.IdPrestamo))
                .ForMember(dest => dest.Libro, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null && !srcMember.Equals(default)));
        }
    }
}
