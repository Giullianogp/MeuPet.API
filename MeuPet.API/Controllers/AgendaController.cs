﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeuPet.API.Controllers
{
    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {
        public AgendaController(IProvider provider) : base(provider)
        {
        }
    }
}