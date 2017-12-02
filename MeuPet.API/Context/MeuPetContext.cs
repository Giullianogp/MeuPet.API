using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuPet.API.Context
{
    public class MeuPetContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Doacao> Doacao { get; set; }

        public MeuPetContext(DbContextOptions<MeuPetContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
