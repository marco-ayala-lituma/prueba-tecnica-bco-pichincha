using Core.Domain.repositories.interfaces;
using Core.Domain.repositories.interfaces.generics;
using Core.Infrastructure.contexts;
using Core.Infrastructure.repositories.cuenta;
using Core.Infrastructure.repositories.generics;
using Core.Infrastructure.repositories.movimiento;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.services
{
  public class UnitOfWork : IUnitOfWork
  {
    protected readonly CoreContext _context;

    public UnitOfWork(CoreContext context)
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


    public IMovimientoDomainRepository GetMovimientoRepository()
    {
      return new MovimientoRepository(_context);
    }

    public ICuentaDomainRepository GetCuentaRepository()
    {
      return new CuentaRepository(_context);
    }
    #endregion Personalizados
  }
}