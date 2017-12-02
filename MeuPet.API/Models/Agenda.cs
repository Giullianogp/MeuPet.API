using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPet.API.Models
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }

        public Usuario Usuario { get; set; }
        public Pet Pet { get; set; }
    }
}
