using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Models;
using MeuPet.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuPet.API.Controllers
{
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {
        public DoacaoController(IProvider provider) : base(provider)
        {
        }

        [HttpGet]
        [Route("getall")]
        [AllowAnonymous]
        public List<Doacao> GetAll()
        {
            return ObterServico<DoacaoService>().GetAll();
        }
    }
}
