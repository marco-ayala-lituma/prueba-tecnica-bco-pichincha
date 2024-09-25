using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.models.cuenta
{
  public class ClienteReporteRequestModel
  {
    [Required(ErrorMessage = "El campo es requerido")]
    public int ClienteId  { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public DateTime Fecha { get; set; }
    
  }
}
