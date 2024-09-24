using AutoMapper;
using Core.Application.models.movimiento;
using Core.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.profiles
{
  public class MovimientoProfile : Profile
  {
    public MovimientoProfile()
    {
      CreateMap<MovimientoEntity, MovimientoCrearRequestModel>();
      CreateMap<MovimientoEntity, MovimientoRequestModel>().ReverseMap();
      CreateMap<MovimientoEntity, MovimientoEditarRequestModel>().ReverseMap();
    }
  }
}
