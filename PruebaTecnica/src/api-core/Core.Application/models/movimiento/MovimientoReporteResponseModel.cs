using Core.Application.models.cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.models.movimiento
{
  public class MovimientoReporteResponseModel
  {
        public string Cliente { get; set; }
        public List<CuentasReporteRequestModel> cuentas { get; set; }
    public MovimientoReporteResponseModel() 
    {
    cuentas=new List<CuentasReporteRequestModel>();
    }
  }
  public class CuentasReporteRequestModel
  {
    public string NumeroCuenta { get; set; } // Clave única para la cuenta
    public string TipoCuenta { get; set; } // Ej: "Ahorros", "Corriente", etc.
    public decimal SaldoInicial { get; set; } // Saldo inicial de la cuenta
    public bool Estado { get; set; } // Estado de la cuenta: activo (true) o inactivo

    public List<MovimientosReporteRequestModel> movimientos { get; set; }
    public CuentasReporteRequestModel() 
    {
      movimientos = new List<MovimientosReporteRequestModel>();
    }
  }
  public class MovimientosReporteRequestModel
  {
    public DateTime Fecha { get; set; } // Fecha del movimiento
    public string TipoMovimiento { get; set; } // Ej: "Depósito", "Retiro", etc.
    public decimal Valor { get; set; } // Valor del movimiento
    public decimal Saldo { get; set; } // Saldo después del movimiento
    public MovimientosReporteRequestModel()
    { }
  }
}
