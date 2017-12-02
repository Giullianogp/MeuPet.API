using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
