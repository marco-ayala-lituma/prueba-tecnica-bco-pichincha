using System.ComponentModel.DataAnnotations;

namespace Tercero.Domain.entities
{
  public class ClienteEntity : PersonaEntity
  {
    [Key]
    public int ClienteId { get; set; } // Clave primaria única para Cliente

    [Required]
    [StringLength(100)]
    public string Contrasena { get; set; } //Modo de prueba este campo no tendra metodo de encriptacion

    [Required]
    public bool Estado { get; set; } // Puede ser true (activo) o false (inactivo)
  }

}
