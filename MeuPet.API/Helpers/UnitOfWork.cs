using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace MeuPet.API.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDictionary<string, object> _Repositories;

        private MeuPetContext _DbContext;
        private IDbContextTransaction _Transaction;

        public UnitOfWork(MeuPetContext dbContext)
        {
            _DbContext = dbContext;
            _Repositories = new Dictionary<string, object>();
        }

        public TRepositorio ObterRepositorio<TRepositorio>()
        {
            var repositoryType = typeof(TRepositorio);

            if (_Repositories.ContainsKey(repositoryType.FullName))
            {
                return (TRepositorio)_Repositories[repositoryType.FullName];
            }

            var instance = (TRepositorio)Activator.CreateInstance(repositoryType, _DbContext);
            _Repositories.Add(repositoryType.FullName, instance);
            return instance;
        }

        public void BeginTransaction()
        {
            if (_Transaction != null)
                throw new NotSupportedException("UnitOfWork já possui uma transação aberta.");

            _Transaction = _DbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_Transaction != null)
            {
                _Transaction.Commit();

                _Transaction.Dispose();
                _Transaction = null;
            }
        }

        public void Rollback()
        {
            if (_Transaction != null)
            {
                _Transaction.Rollback();

                _Transaction.Dispose();
                _Transaction = null;
            }
        }

        public void Dispose()
        {
            if (_Transaction != null)
            {
                _DbContext.Database.CommitTransaction();
            }
        }

    }
}
