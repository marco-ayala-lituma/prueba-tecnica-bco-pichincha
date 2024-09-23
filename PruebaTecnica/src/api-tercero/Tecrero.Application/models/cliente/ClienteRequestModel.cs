using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecrero.Application.models.cliente
{
  public class ClienteRequestModel
  {
    public int ClienteId { get; set; } // Clave primaria única para Cliente

    public string Contrasena { get; set; } //Modo de prueba este campo no tendra metodo de encriptacion

    public bool Estado { get; set; } // Puede ser true (activo) o false (inactivo)
  }
}
