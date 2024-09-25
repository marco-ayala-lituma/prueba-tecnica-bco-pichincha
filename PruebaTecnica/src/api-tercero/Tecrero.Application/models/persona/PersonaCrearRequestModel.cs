using System.ComponentModel.DataAnnotations;

namespace Tecrero.Application.models.persona
{
  public class PersonaCrearRequestModel
  {
    [Required(ErrorMessage ="El nombre es campo requerido")]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required(ErrorMessage ="El Genero es requerido")]
    [StringLength(10)]
    public string Genero { get; set; } // Ej: "Masculino", "Femenino", etc.

    [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años.")]
    public int Edad { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="La identificacion debe contener maximo 50 caracteres")]
    public string Identificacion { get; set; }

    [StringLength(200,ErrorMessage ="La direccion debe contener maximo 200 carcateres")]
    public string Direccion { get; set; }

    [StringLength(15,ErrorMessage ="El telefono debe contener maximo 15 caracteres")]
    [Phone]
    public string Telefono { get; set; }
  }
}
