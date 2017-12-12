using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MeuPet.API.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IServiceProvider ServiceProvider;

        protected ControllerBase(IProvider provider)
        {
            ServiceProvider = provider.ObterBaseProvider();
        }

        protected HttpContext ObterHttpContext()
        {
            return ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        }

        protected virtual TService ObterServico<TService>()
        {
            return ServiceProvider.GetService<TService>();
        }
    }
}
