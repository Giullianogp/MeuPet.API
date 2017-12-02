using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Models;
using MeuPet.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeuPet.API.Controllers
{
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        public PetController(IProvider provider) : base(provider)
        {
        }

        [HttpGet]
        [Route("Get")]
        public Pet Get()
        {
            return ObterServico<PetService>().Obter(new Pet() {PetId = 1});
        }
    }
}
