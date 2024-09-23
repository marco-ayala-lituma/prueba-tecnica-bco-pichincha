namespace Tercero.Domain.entities.bases
{
  public class BaseEntity
  {
    public bool Eliminado { get; set; }

    public BaseEntity()
    {
      Eliminado = false;
    }
  }
}
