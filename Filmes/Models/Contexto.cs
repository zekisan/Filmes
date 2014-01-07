using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Filmes.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }

        //public Contexto()
        //    :base("MyDB"){}


        //public DbSet<FilmeGenero> FilmesGeneros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>().HasMany(f => f.Generos).WithMany(g => g.Filmes).Map(
                    m => {
                        m.MapLeftKey("FilmeID");
                        m.MapRightKey("GeneroID");
                        m.ToTable("FilmesGeneros");
                    }
                );

            //modelBuilder.Entity<FilmeGenero>().HasKey(c => new { c.FilmeID, c.GeneroID });

            //modelBuilder.Entity<Filme>().HasMany(c => c.FilmesGeneros).WithRequired().HasForeignKey(c => c.FilmeID);

            //modelBuilder.Entity<Genero>().HasMany(c => c.FilmesGeneros).WithRequired().HasForeignKey(c => c.GeneroID);
        }
    }
}