using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.entities
{
  public class CuentaEntity
  {
    [Key]
    public int NumeroCuenta { get; set; } // Clave única para la cuenta

    [Required]
    [StringLength(50)]
    public string TipoCuenta { get; set; } // Ej: "Ahorros", "Corriente", etc.

    [Range(0, double.MaxValue)]
    public decimal SaldoInicial { get; set; } // Saldo inicial de la cuenta

    [Required]
    public bool Estado { get; set; } // Estado de la cuenta: activo (true) o inactivo
  }
}
