using System;

namespace MeuPet.API.Helpers
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        TRepositorio ObterRepositorio<TRepositorio>();
    }
}