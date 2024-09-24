using Core.Domain.repositories.interfaces;
using Core.Domain.repositories.interfaces.generics;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.services
{
  public interface IUnitOfWork
  {
    IRepository<T> GetRepository<T>() where T : class;

    void SaveSync();

    void CleanTracker();

    void BeginTransaction();

    IDbContextTransaction BeginTransactionContext();

    void CommitTransaction();

    void RollbackTransaction();

    #region Personalizados

    IMovimientoDomainRepository GetMovimientoRepository();
    ICuentaDomainRepository GetCuentaRepository();

    #endregion Personalizados
  }
}
