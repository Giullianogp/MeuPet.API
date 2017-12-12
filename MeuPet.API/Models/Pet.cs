using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPet.API.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Nome { get; set; }
        public string ImageUrl { get; set; }
        public string Peso { get; set; }
        public string Raca { get; set; }
        public DateTime Nascimento { get; set; }
        public Usuario Usuario { get; set; }
        public List<Agenda> Agendas { get; set; }

    }
}
