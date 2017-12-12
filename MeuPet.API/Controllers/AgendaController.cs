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
    public class AgendaController : ControllerBase
    {
        public AgendaController(IProvider provider) : base(provider)
        {
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Inserir([FromBody] Agenda agenda)
        {
            return Ok(ObterServico<AgendaService>().Inserir(agenda));
        }

        [HttpPost]
        [Route("editar")]
        public IActionResult Editar([FromBody] Agenda agenda)
        {
            return Ok(ObterServico<AgendaService>().Editar(agenda));
        }

        [HttpGet]
        [Route("GetProximas")]
        public IActionResult GetProximas()
        {
            return Ok(ObterServico<AgendaService>().GetProximas());
        }

        [HttpPost]
        [Route("Get")]
        public IActionResult Get([FromBody] Pet pet)
        {
            return Ok(ObterServico<AgendaService>().Get(pet));
        }
    }
}
