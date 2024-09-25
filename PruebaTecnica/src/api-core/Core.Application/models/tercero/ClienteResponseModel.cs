using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Application.models.tercero
{
  public class ClienteResponseModel
  {
    public int Code { get; set; }
    public string Message { get; set; }
    public Data Data { get; set; }
    public string CodeText { get; set; }
  }
  public class Data
  {
    public int ClienteId { get; set; }
    public string Contrasena { get; set; }
    public bool Estado { get; set; }
  }
}
