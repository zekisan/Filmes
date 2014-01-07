using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmes.Models
{
    public class Genero
    {
        public int GeneroID { get; set; }
        public string Nome { get; set; }

        public ICollection<Filme> Filmes { get; set; }

        public Genero()
        {
            Filmes = new HashSet<Filme>();
        }
    }
}