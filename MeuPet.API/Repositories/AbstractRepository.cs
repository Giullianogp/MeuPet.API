using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;

namespace MeuPet.API.Repositories
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity>
    {
        protected readonly MeuPetContext Context;

        public AbstractRepository(MeuPetContext dbContext)
        {
            Context = dbContext;
        }

        public abstract TEntity Obter(int id);
        public abstract TEntity Inserir(TEntity entidade);
        public abstract TEntity Editar(TEntity entidade);
        public abstract void Deletar(TEntity entidade);

        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {

                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
