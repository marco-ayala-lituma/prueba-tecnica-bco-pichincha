using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecrero.Application.models.persona;
using Tercero.Domain.entities;

namespace Tecrero.Application.profiles
{
  public class PersonaProfile : Profile
  {
    public PersonaProfile()
    {
      CreateMap<PersonaEntity, PersonaCrearRequestModel>().ReverseMap();
    }
  }
}
