using Microsoft.EntityFrameworkCore;
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
    public DbSet<ClienteEntity> Cliente { get; set; }
  }
}
