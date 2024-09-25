using AutoMapper;
using Core.Application.models.cuenta;
using Core.Domain.entities;

namespace Core.Application.profiles
{
  public class CuentaProfile : Profile
  {
    public CuentaProfile()
    {
      CreateMap<CuentaEntity, CuentaCrearRequestModel>().ReverseMap();
      CreateMap<CuentaEntity, CuentaRequestModel>().ReverseMap();
      CreateMap<CuentaEntity, CuentaEditarRequestModel>().ReverseMap();
    }
  }
}

