using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmes.Models
{
    public class FilmeGenero
    {
        public int FilmeID { get; set; }
        public int GeneroID { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
        public virtual ICollection<Genero> Generos { get; set; }
    }
}