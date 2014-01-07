using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Filmes.Models
{
    public class InicializadorDB : DropCreateDatabaseAlways<Contexto>
    {
        

        protected override void Seed(Contexto context)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>() { 
                {1,"Ação"},
                {2,"Animação"},
                {3,"Aventura"},
                {4,"Biografia"},
                {5,"Comédia"},
                {6,"Crime"},
                {7,"Documentário"},
                {8,"Drama"},
                {9,"Esporte"},
                {10,"Familia"},
                {11,"Fantasia"},
                {12,"Ficção Científica"},
                {13,"Guerra"},
                {14,"História"},
                {15,"Horror"},
                {16,"Música"},
                {17,"Musical"},
                {19,"Romance"},
                {20,"Thriller"},
                {21,"Western"}
            };

            foreach (var item in dic)
            {
                context.Generos.Add(
                    new Genero()
                    {
                        GeneroID = item.Key,
                        Nome = item.Value
                    }
                );
            }

            context.SaveChanges();
        }
    }
}