using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.models.cuenta
{
  public class CuentaRequestModel
  {
    public string NumeroCuenta { get; set; } // Clave única para la cuenta
    public string TipoCuenta { get; set; } // Ej: "Ahorros", "Corriente", etc.
    public decimal SaldoInicial { get; set; } // Saldo inicial de la cuenta
    public bool Estado { get; set; } // Estado de la cuenta: activo (true) o inactivo
  }
}
