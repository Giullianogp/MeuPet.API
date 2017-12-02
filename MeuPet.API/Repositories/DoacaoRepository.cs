using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Models;

namespace MeuPet.API.Repositories
{
    public class DoacaoRepository : AbstractRepository<Doacao>
    {
        public DoacaoRepository(MeuPetContext dbContext) : base(dbContext)
        {
        }

        public override Doacao Obter(int id)
        {
            return Context.Doacao.Find(id);
        }

        public override Doacao Inserir(Doacao entidade)
        {
            Context.Doacao.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public override Doacao Editar(Doacao entidade)
        {
            Context.Doacao.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public override void Deletar(Doacao entidade)
        {
            Context.Doacao.Remove(entidade);
            Context.SaveChanges();
        }
    }
}
