using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.models.movimiento
{
  public class MovimientoCrearRequestModel
  {

    [Required(ErrorMessage = "El valor es obligatorio.")]
    public DateTime Fecha { get; set; } // Fecha del movimiento

    [Required(ErrorMessage = "El valor es obligatorio.")]
    [StringLength(50)]
    public string TipoMovimiento { get; set; } // Ej: "Depósito", "Retiro", etc.

    [Required(ErrorMessage = "El valor es obligatorio.")]
    public decimal Valor { get; set; } // Valor del movimiento

    [Required(ErrorMessage = "El valor es obligatorio.")]
    [StringLength(6)]
    public string NumeroCuenta { get; set; }
  }
}
