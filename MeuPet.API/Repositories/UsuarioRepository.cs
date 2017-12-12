using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Models;

namespace MeuPet.API.Repositories
{
    public class UsuarioRepository : AbstractRepository<Usuario>
    {
        public UsuarioRepository(MeuPetContext dbContext) : base(dbContext)
        {
        }

        public override Usuario Obter(int id)
        {
            return Context.Usuario.Find(id);
        }

        public override Usuario Inserir(Usuario entidade)
        {
            Context.Usuario.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public override Usuario Editar(Usuario entidade)
        {
            Context.Usuario.Add(entidade);
            Context.SaveChanges();
            return entidade;
        }

        public override void Deletar(Usuario entidade)
        {
            Context.Usuario.Remove(entidade);
            Context.SaveChanges();
        }

        public Usuario Logar(Usuario user)
        {
            return Context.Usuario.FirstOrDefault(x => x.Nome == user.Nome && x.Senha == user.Senha);
        }


    }
}
