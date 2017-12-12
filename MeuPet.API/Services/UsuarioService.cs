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
    public class UsuarioService : AbstractService<Usuario, UsuarioRepository>
    {
        public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Usuario Obter(Usuario entidade)
            => Repository.Obter(entidade.UsuarioId);

        public override Usuario Inserir(Usuario entidade)
            => Repository.Inserir(entidade);

        public override Usuario Editar(Usuario entidade)
            => Repository.Editar(entidade);

        public override void Deletar(Usuario entidade)
            => Repository.Deletar(entidade);

        public Usuario Logar(Usuario user)
            => Repository.Logar(user);


    }
}
