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
    public class PetService : AbstractService<Pet, PetRepository>
    {
        public PetService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Pet Obter(Pet entidade)
            => Repository.Obter(entidade.PetId);

        public List<Pet> ObterLista(Usuario user)
            => Repository.ObterLista(user);

        public override Pet Inserir(Pet entidade)
            => Repository.Inserir(entidade);

        public override Pet Editar(Pet entidade)
            => Repository.Editar(entidade);

        public override void Deletar(Pet entidade)
            => Repository.Deletar(entidade);

        public List<Pet> ObterListaCompleta()
            => Repository.ObterListaCompleta();

        
    }
}
