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
            entidade.Usuario = Context.Usuario.First();
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

        public List<Agenda> GetProximas()
        {
            return Context.Agenda.Where(x => x.Data > DateTime.Now).ToList();
        }

        public List<Agenda> Get(Pet pet)
        {
            return Context.Agenda.Where(x => x.Data > DateTime.Now && x.Pet.PetId == pet.PetId).ToList();
        }
    }
}
