using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Helpers;

namespace MeuPet.API.Services
{
    public abstract class AbstractService<TEntity, TRepository>
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected TRepository Repository { get; }

        public AbstractService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.ObterRepositorio<TRepository>();
        }

        public abstract TEntity Obter(TEntity entidade);
        public abstract TEntity Inserir(TEntity entidade);
        public abstract TEntity Editar(TEntity entidade);
        public abstract void Deletar(TEntity entidade);
    }
}
