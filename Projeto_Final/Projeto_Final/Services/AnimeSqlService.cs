using Projeto_Final.Data;
using Projeto_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Services 
{
    public class AnimeSqlService : IAnimeService
    {
        AnimeContext context;

        public AnimeSqlService(AnimeContext context)
        {
            this.context = context;
        }

        public List<Anime> getAll(string busca = null, bool ordenar = false)
        {
            List<Anime> lista = context.Anime.ToList();
            
            if (busca != null)
            {
                return lista.FindAll(a => a.Nome.ToLower().Contains(busca.ToLower()));// retornar uma busca em toda a lista onde a string buscada toda em minusco for igual a string do anime tudo minuscula/
            }

            if (ordenar)
            {
                lista = lista.OrderBy(a => a.Nome).ToList();//traz a lista ordenada
                return lista;
            }
            return lista;
        }
        public bool create(Anime anime)
        {
            try
            {
                context.Anime.Add(anime);//adiciona o novo anime 
                context.SaveChanges();//salva o novo anime no banco de dados 
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Anime get(int? id)
        {
            return context.Anime.Find(id);
        }
        public bool update(Anime a)
        {
            try
            {
                context.Anime.Update(a);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool delete(int? id)
        {
            try
            {
                context.Anime.Remove(get(id));
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
