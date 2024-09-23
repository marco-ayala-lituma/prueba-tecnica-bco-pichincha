using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecrero.Application.models.persona;

namespace Tecrero.Application.services.persona.interfaces
{
  public interface IPersonaService
  {
    int Crear(PersonaCrearRequestModel request);
  }
}
