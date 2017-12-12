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

                    context.Pet.Add(new Pet { Nome = "Bart", Nascimento = new DateTime(2012, 01, 24), Peso = "5,0", Usuario = user, ImageUrl = "https://meupetblob.blob.core.windows.net/pets/maxresdefault.jpg" });
                    context.Pet.Add(new Pet { Nome = "Lisa", Nascimento = new DateTime(2009, 05, 12), Raca = "Vira-lata", Usuario = user, ImageUrl = "https://meupetblob.blob.core.windows.net/pets/cb1d1c72-e185-485c-8108-280deba845a2.jpg" });
                    context.Pet.Add(new Pet { Nome = "Rex", Nascimento = new DateTime(2015, 01, 12), Raca = "Maltes", Usuario = user, ImageUrl = "https://meupetblob.blob.core.windows.net/pets/image.png" });

                    context.SaveChanges();
                }

                if (!context.Agenda.Any())
                {
                    var user = context.Usuario.First();
                    var pet1 = context.Pet.First(x => x.Nome == "Bart");

                    context.Agenda.Add(new Agenda
                    {
                        Usuario = user,
                        Pet = pet1,
                        Descricao = "aplicar a ultima vacina da raiva",
                        Data = new DateTime(2017, 12, 24),
                        Endereco = "Pet do centro",
                        Titulo = "Vacina Raiva"
                    });

                    context.Agenda.Add(new Agenda
                    {
                        Usuario = user,
                        Pet = pet1,
                        Descricao = "",
                        Data = new DateTime(2017, 12, 26),
                        Endereco = "Pet do centro",
                        Titulo = "Banho e Tosa"
                    });


                    var pet2 = context.Pet.First(x => x.Nome == "Bart");

                    context.Agenda.Add(new Agenda
                    {
                        Usuario = user,
                        Pet = pet2,
                        Descricao = "",
                        Data = new DateTime(2017, 12, 26),
                        Endereco = "Pet do centro",
                        Titulo = "Banho e Tosa"
                    });

                    var pet3 = context.Pet.First(x => x.Nome == "Bart");

                    context.Agenda.Add(new Agenda
                    {
                        Usuario = user,
                        Pet = pet3,
                        Descricao = "muita pulga, não para de se coçar",
                        Data = new DateTime(2017, 12, 24),
                        Endereco = "Pet do centro",
                        Titulo = "Vacina para pulga"
                    });

                }


                if (!context.Doacao.Any())
                {
                    var user = context.Usuario.First();
                    context.Doacao.Add(new Doacao { Usuario = user, Contato = "(51)5555555", Descricao = "Filhotinho de gato com quatro patas" });
                    context.Doacao.Add(new Doacao { Usuario = user, Contato = "(54)6666666", Descricao = "Cachorro Preto. Obs: Parece que está com raiva." });
                    context.Doacao.Add(new Doacao { Usuario = user, Contato = "(55)6666666", Descricao = "Filhote com 45 dias." });
                    context.SaveChanges();
                }
            }
        }

    }
}
