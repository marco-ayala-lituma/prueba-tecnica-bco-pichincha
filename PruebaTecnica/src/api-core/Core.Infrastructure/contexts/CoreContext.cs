using Core.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.contexts
{
  public class CoreContext : DbContext
  {
    public CoreContext(DbContextOptions<CoreContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

    }
    public DbSet<MovimientoEntity> Movimiento { get; set; }
    public DbSet<CuentaEntity> Cuenta { get; set; }
  }
}

