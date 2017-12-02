using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Models;

namespace MeuPet.API.Context
{
    public static class SeedData
    {

        public static void EnsureSeedData(this MeuPetContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Usuario.Any())
                {
                    context.Usuario.Add(new Usuario { Nome = "Admin", Senha = "123" });
                    context.SaveChanges();
                }

                if (!context.Pet.Any())
                {
                    var user = context.Usuario.First();

                    context.Pet.Add(new Pet { Nome = "Bart", Nascimento = new DateTime(2012, 01, 24), Usuario = user, ImageUrl = "https://meupetblob.blob.core.windows.net/pets/maxresdefault.jpg" });
                    context.Pet.Add(new Pet { Nome = "Lisa", Nascimento = new DateTime(2009, 05, 12), Usuario = user, ImageUrl = "https://meupetblob.blob.core.windows.net/pets/cb1d1c72-e185-485c-8108-280deba845a2.jpg" });
                    context.SaveChanges();
                }
            }
        }

    }
}
