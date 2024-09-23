using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecrero.Application.models.cliente;
using Tecrero.Application.models.persona;
using Tercero.Domain.entities;

namespace Tecrero.Application.profiles
{
  public class ClienteProfile : Profile
  {
    public ClienteProfile()
    {
      CreateMap<ClienteEntity, ClienteCrearRequestModel>();
      CreateMap<ClienteEntity, ClienteRequestModel>().ReverseMap();
      CreateMap<ClienteEntity, ClienteCrearRequestModel>().ReverseMap();
      CreateMap<ClienteEntity, ClienteEditarRequestModel>().ReverseMap();

    }
  }
}
