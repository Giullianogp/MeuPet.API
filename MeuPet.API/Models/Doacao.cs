using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPet.API.Models
{
    public class Doacao
    {
        public int DoacaoId { get; set; }
        public string Descricao { get; set; }
        public string Contato { get; set; }
        public string ImageUrl { get; set; }

        public Usuario Usuario { get; set; }
    }
}
