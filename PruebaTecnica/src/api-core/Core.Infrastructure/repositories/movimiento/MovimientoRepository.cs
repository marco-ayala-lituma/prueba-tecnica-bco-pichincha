using Core.Domain.entities;
using Core.Domain.repositories.interfaces;
using Core.Infrastructure.contexts;
using Core.Infrastructure.repositories.generics;

namespace Core.Infrastructure.repositories.movimiento
{
  public class MovimientoRepository : Repository<MovimientoEntity>, IMovimientoDomainRepository
  {
    public MovimientoRepository(CoreContext context) : base(context)
    {
    }
  }
}
