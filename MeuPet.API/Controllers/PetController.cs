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
        [Route("get")]
        public Pet Get()
        {
            return ObterServico<PetService>().Obter(new Pet { PetId = 1 });
        }

        [HttpGet]
        [Route("getall")]
        public List<Pet> GetAll()
        {
            //var context = ObterHttpContext();
            return ObterServico<PetService>().ObterListaCompleta();
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Inserir([FromBody] Pet pet)
        {
            return Ok(ObterServico<PetService>().Inserir(pet));
        }

        [HttpPost]
        [Route("editar")]
        public IActionResult Editar([FromBody] Pet pet)
        {
            return Ok(ObterServico<PetService>().Editar(pet));
        }
    }
}
