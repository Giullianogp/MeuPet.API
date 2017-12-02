using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Models;
using MeuPet.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuPet.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController(IProvider provider) : base(provider)
        { }

        [HttpPost]
        [Route("Inserir")]
        public Usuario Inserir([FromBody] Usuario usuario)
        {
            return ObterServico<UsuarioService>().Inserir(usuario);
        }

        [HttpPost]
        [Route("Logar")]
        public Usuario Logar([FromBody] Usuario usuario)
        {
            return ObterServico<UsuarioService>().Obter(usuario);
        }



    }
}
