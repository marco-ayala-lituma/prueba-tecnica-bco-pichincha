using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercero.Domain.entities;

namespace Tercero.Infrastructure.contexts
{
  public class TerceroContext : DbContext
  {
    public TerceroContext(DbContextOptions<TerceroContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

    }
    public DbSet<PersonaEntity> Persona { get; set; }
  }
}
