using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPet.API
{
    public interface IProvider
    {
        IServiceProvider ObterBaseProvider();
    }

    public class Provider : IProvider
    {
        private readonly IServiceProvider _provider;
        public Provider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IServiceProvider ObterBaseProvider()
        {
            return _provider;
        }
    }
}
