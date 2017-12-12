using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Helpers;
using MeuPet.API.Models;
using MeuPet.API.Repositories;

namespace MeuPet.API.Services
{
    public class AgendaService : AbstractService<Agenda, AgendaRepository>
    {
        public AgendaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Agenda Obter(Agenda entidade)
            => Repository.Obter(entidade.AgendaId);

        public override Agenda Inserir(Agenda entidade)
            => Repository.Inserir(entidade);

        public override Agenda Editar(Agenda entidade)
            => Repository.Editar(entidade);

        public override void Deletar(Agenda entidade)
            => Repository.Deletar(entidade);

        public List<Agenda> GetProximas()
            => Repository.GetProximas();

        public List<Agenda> Get(Pet pet)
            => Repository.Get(pet);
    }
}
