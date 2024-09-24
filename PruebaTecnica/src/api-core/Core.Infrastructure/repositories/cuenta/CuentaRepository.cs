using Core.Domain.entities;
using Core.Domain.repositories.interfaces;
using Core.Infrastructure.contexts;
using Core.Infrastructure.repositories.generics;

namespace Core.Infrastructure.repositories.cuenta
{
  public class CuentaRepository : Repository<CuentaEntity>, ICuentaDomainRepository
  {
    public CuentaRepository(CoreContext context) : base(context)
    {
    }
  }
}
