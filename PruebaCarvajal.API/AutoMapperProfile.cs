using AutoMapper;
using PruebaCarvajal.API.Models;
using PruebaCarvajal.API.Models.DTOs;
using PruebaCarvajal.Domain;

namespace PruebaCarvajal.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TipoDocumento, TipoDocumentoDTO>();
            CreateMap<UsuarioCreate, Usuario>();
            CreateMap<UsuarioUpdate, Usuario>();
            CreateMap<Usuario, UsuarioQuery>();
            CreateMap<UsuarioLoginDTO, Usuario>();
        }
    }
}
