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
    public class DoacaoService : AbstractService<Doacao, DoacaoRepository>
    {
        public DoacaoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Doacao Obter(Doacao entidade)
            => Repository.Obter(entidade.DoacaoId);

        public override Doacao Inserir(Doacao entidade)
            => Repository.Inserir(entidade);

        public override Doacao Editar(Doacao entidade)
            => Repository.Editar(entidade);

        public override void Deletar(Doacao entidade)
            => Repository.Deletar(entidade);
    }
}
