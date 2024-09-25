using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.models.cuenta
{
  public class CuentaCrearRequestModel
  {
    [Required(ErrorMessage ="El campo es requerido")]
    public string NumeroCuenta { get; set; } // Clave única para la cuenta

    [Required(ErrorMessage = "El campo es requerido")]
    public int ClienteId { get; set; } // Relacion de clienteId

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(50)]
    public string TipoCuenta { get; set; } // Ej: "Ahorros", "Corriente", etc.

    [Required(ErrorMessage = "El campo es requerido")]
    public decimal SaldoInicial { get; set; } // Saldo inicial de la cuenta

    [Required(ErrorMessage = "El campo es requerido")]
    public bool Estado { get; set; } // Estado de la cuenta: activo (true) o inactivo
  }
}
