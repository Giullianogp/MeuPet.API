using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPet.API.Repositories
{
    public interface IRepository<TEntity> : IDisposable
    {
        TEntity Obter(int id);
        TEntity Inserir(TEntity entidade);
        TEntity Editar(TEntity entidade);
    }
}
