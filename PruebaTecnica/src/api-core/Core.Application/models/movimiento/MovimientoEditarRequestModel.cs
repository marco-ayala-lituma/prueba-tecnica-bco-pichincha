using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.models.movimiento
{
  public class MovimientoEditarRequestModel
  {
    [Required]
    public int Id { get; set; } // Clave única para el movimiento

    [Required]
    public DateTime Fecha { get; set; } // Fecha del movimiento

    [Required]
    [StringLength(50)]
    public string TipoMovimiento { get; set; } // Ej: "Depósito", "Retiro", etc.

    [Range(0, double.MaxValue)]
    public decimal Valor { get; set; } // Valor del movimiento

    [Range(0, double.MaxValue)]
    public decimal Saldo { get; set; } // Saldo después del movimiento
    [Required]
    [StringLength(6)]
    public string NumeroCuenta { get; set; }
  }
}
