using Tecrero.Application.models.persona;

namespace Tecrero.Application.services.persona.interfaces
{
  public interface IPersonaService
  {
    int Crear(PersonaCrearRequestModel request);
    bool Actualizar(PersonaEditarRequestModel request);

    PersonaRequestModel ObtenerPersona(int request);
    bool Eliminar(int PersonaId);
  }
}
