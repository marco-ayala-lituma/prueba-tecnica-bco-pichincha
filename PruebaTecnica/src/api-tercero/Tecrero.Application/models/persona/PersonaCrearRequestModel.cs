using System.ComponentModel.DataAnnotations;

namespace Tecrero.Application.models.persona
{
  public class PersonaCrearRequestModel
  {
    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(10)]
    public string Genero { get; set; } // Ej: "Masculino", "Femenino", etc.

    [Range(0, 120)]
    public int Edad { get; set; }

    [Required]
    [StringLength(50)]
    public string Identificacion { get; set; }

    [StringLength(200)]
    public string Direccion { get; set; }

    [StringLength(15)]
    [Phone]
    public string Telefono { get; set; }
  }
}
