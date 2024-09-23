using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercero.Domain.entities;
using Tercero.Domain.repositories.interfaces;
using Tercero.Infrastructure.contexts;
using Tercero.Infrastructure.repositories.generics;

namespace Tercero.Infrastructure.repositories.persona
{
  public class PersonaRepository : Repository<PersonaEntity>, IPersonaDomainRepository
  {
    public PersonaRepository(TerceroContext context) : base(context)
    {
    }
  }
}
