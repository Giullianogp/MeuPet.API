using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Models;

namespace MeuPet.API.Repositories
{
    public class AgendaRepository : AbstractRepository<Agenda>
    {
        public AgendaRepository(MeuPetContext dbContext) : base(dbContext)
        {
        }

        public override Agenda Obter(int id)
        {
            return Context.Agenda.Find(id);
        }

        public override Agenda Inserir(Agenda entidade)
        {
            Context.Agenda.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public override Agenda Editar(Agenda entidade)
        {
            Context.Agenda.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public override void Deletar(Agenda entidade)
        {
            Context.Agenda.Remove(entidade);
            Context.SaveChanges();
        }
    }
}
