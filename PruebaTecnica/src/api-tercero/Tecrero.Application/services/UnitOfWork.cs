using Microsoft.EntityFrameworkCore.Storage;
using Tercero.Domain.repositories.interfaces;
using Tercero.Domain.repositories.interfaces.generics;
using Tercero.Infrastructure.contexts;
using Tercero.Infrastructure.repositories.cliente;
using Tercero.Infrastructure.repositories.generics;
using Tercero.Infrastructure.repositories.persona;

namespace Tecrero.Application.services
{
  public class UnitOfWork : IUnitOfWork
  {
    protected readonly TerceroContext _context;

    public UnitOfWork(TerceroContext context)
    {
      _context = context;
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
      return new Repository<T>(_context);
    }

    public void SaveSync()
    {
      _context.SaveChanges();
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    public void CleanTracker()
    {
      this._context.ChangeTracker.Clear();
    }


    public void BeginTransaction()
    {
      _context.Database.BeginTransaction();
    }
    public IDbContextTransaction BeginTransactionContext()
    {
      return _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
      _context.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
      _context.Database.RollbackTransaction();
    }



    #region Personalizados


    public IPersonaDomainRepository GetPersonaRepository()
    {
      return new PersonaRepository(_context);
    }

    public IClienteDomainRepository GetClienteRepository()
    {
      return new ClienteRepository(_context);
    }
    #endregion Personalizados
  }
}