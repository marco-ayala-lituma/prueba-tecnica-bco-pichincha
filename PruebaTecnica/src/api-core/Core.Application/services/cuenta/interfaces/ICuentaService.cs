using Core.Application.models.cuenta;

namespace Core.Application.services.cuenta.interfaces
{
  public interface ICuentaService
  {
    string Crear(CuentaCrearRequestModel request);
    bool Actualizar(CuentaEditarRequestModel request);
    CuentaRequestModel ObtenerCuenta(int request);
    bool Eliminar(string PersonaId);
  }
}
