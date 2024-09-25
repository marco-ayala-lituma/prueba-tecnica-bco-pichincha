using Core.Application.models.cuenta;
using Core.Application.models.movimiento;

namespace Core.Application.services.movimiento.interfaces
{
  public interface IMovimientoService
  {
    int Crear(MovimientoCrearRequestModel request);
    bool Actualizar(MovimientoEditarRequestModel request);
    MovimientoRequestModel ObtenerMovimiento(int request);
    bool Eliminar(int PersonaId);

    MovimientoReporteResponseModel ObtenerReporteMovimientos(ClienteReporteRequestModel request);
  }
}
