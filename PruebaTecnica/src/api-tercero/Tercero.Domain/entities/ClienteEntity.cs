using System.ComponentModel.DataAnnotations;

namespace Tercero.Domain.entities
{
  public class ClienteEntity 
  {
    [Required]
    public int ClienteId { get; set; } // Clave primaria única para Cliente

    [Required]
    [StringLength(100)]
    public string Contrasena { get; set; } //Modo de prueba este campo no tendra metodo de encriptacion

    [Required]
    public bool Estado { get; set; } // Puede ser true (activo) o false (inactivo)

    // Clave foránea que referencia a Persona
    //public int PersonaId { get; set; } // Aquí agregamos PersonaId para establecer la relación
    public virtual PersonaEntity Persona { get; set; } // Navegación a Persona
  }

}
