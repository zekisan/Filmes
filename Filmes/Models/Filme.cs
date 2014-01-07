using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmes.Models
{
    public class Filme
    {
        public int FilmeID { get; set; }

        [Required]
        [Display(Name="Título")]
        [StringLength(100,ErrorMessage="O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Título original")]
        [StringLength(100, ErrorMessage = "O título original deve ter no máximo 100 caracteres.")]
        public string TituloOriginal { get; set; }

        [Required]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }

        public ICollection<Genero> Generos { get; set; }

        public Filme()
        {
            Generos = new HashSet<Genero>();
        }
    }
}