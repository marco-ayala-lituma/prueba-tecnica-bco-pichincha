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

      // Configurar la relación entre Cliente y Persona
      modelBuilder.Entity<ClienteEntity>()
          .HasKey(c => c.ClienteId); // Establecer ClienteId como clave primaria

      modelBuilder.Entity<ClienteEntity>()
          .HasOne(c => c.Persona) // Un Cliente tiene una Persona
          .WithOne(p => p.Cliente) // Una Persona tiene un Cliente
          .HasForeignKey<ClienteEntity>(c => c.ClienteId); // Establecer PersonaId como clave foránea
    }
    public DbSet<PersonaEntity> Persona { get; set; }
    public DbSet<ClienteEntity> Cliente { get; set; }
  }
}
