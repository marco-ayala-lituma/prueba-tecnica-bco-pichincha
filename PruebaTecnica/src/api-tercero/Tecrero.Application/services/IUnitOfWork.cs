using Microsoft.EntityFrameworkCore.Storage;
using Tercero.Domain.repositories.interfaces;
using Tercero.Domain.repositories.interfaces.generics;

namespace Tecrero.Application.services
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

    IPersonaDomainRepository GetPersonaRepository();
    IClienteDomainRepository GetClienteRepository();

    #endregion Personalizados
  }
}
