using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.models.movimiento
{
  public class MovimientoRequestModel
  {
    public int Id { get; set; } // Clave única para el movimiento
    public DateTime Fecha { get; set; } // Fecha del movimiento
    public string TipoMovimiento { get; set; } // Ej: "Depósito", "Retiro", etc.
    public decimal Valor { get; set; } // Valor del movimiento
    public decimal Saldo { get; set; } // Saldo después del movimiento
    public string NumeroCuenta { get; set; }
  }
}
