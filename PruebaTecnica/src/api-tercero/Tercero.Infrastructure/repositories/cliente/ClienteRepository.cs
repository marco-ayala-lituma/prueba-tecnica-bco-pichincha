using Tercero.Domain.entities;
using Tercero.Domain.repositories.interfaces;
using Tercero.Infrastructure.contexts;
using Tercero.Infrastructure.repositories.generics;

namespace Tercero.Infrastructure.repositories.cliente
{
  public class ClienteRepository : Repository<ClienteEntity>, IClienteDomainRepository
  {
    public ClienteRepository(TerceroContext context) : base(context)
    {
    }
  }
}

