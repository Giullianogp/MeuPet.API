using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Models;

namespace MeuPet.API.Repositories
{
    public class PetRepository : AbstractRepository<Pet>
    {
        public PetRepository(MeuPetContext dbContext) : base(dbContext)
        {
        }

        public override Pet Obter(int id)
        {
            return Context.Pet.Find(id);
        }

        public override Pet Inserir(Pet entidade)
        {
            entidade.ImageUrl = "https://meupetblob.blob.core.windows.net/pets/image.png";

            entidade.Usuario = Context.Usuario.First();

            Context.Pet.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public override Pet Editar(Pet entidade)
        {
            Context.Pet.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public List<Pet> ObterLista(Usuario user)
        {
            var usuario = Context.Usuario.First(x => x.Nome == user.Nome);
            return Context.Pet.Where(x => x.Usuario.UsuarioId == usuario.UsuarioId).ToList();
        }

        public List<Pet> ObterListaCompleta()
        {
          
            return Context.Pet.ToList();
        }

        


        public override void Deletar(Pet entidade)
        {
            Context.Pet.Remove(entidade);
            Context.SaveChanges();
        }
    }
}
