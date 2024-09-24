using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecrero.Application.models.cliente;
using Tecrero.Application.models.persona;

namespace Tecrero.Application.services.cliente.interfaces
{
  public interface IClienteService
  {
    int Crear(ClienteCrearRequestModel request);
    bool Actualizar(ClienteEditarRequestModel request);
    ClienteRequestModel ObtenerCliente(int request);
    bool Eliminar(int PersonaId);
  }
}
