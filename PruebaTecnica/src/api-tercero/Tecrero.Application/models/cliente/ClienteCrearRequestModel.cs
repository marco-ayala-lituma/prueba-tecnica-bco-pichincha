using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecrero.Application.models.cliente
{
  public class ClienteCrearRequestModel
  {
    [Required]
    public int ClienteId { get; set; } // Clave primaria única para Cliente

    [Required]
    [StringLength(100)]
    public string Contrasena { get; set; } //Modo de prueba este campo no tendra metodo de encriptacion

    [Required]
    public bool Estado { get; set; } // Puede ser true (activo) o false (inactivo)
  }
}
