using Microsoft.EntityFrameworkCore;
using Projeto_Final.Data;
using Projeto_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Services 
{
    public class EpisodioSqlService : IEpisodioService
    {
        AnimeContext context;

        public EpisodioSqlService(AnimeContext context)
        {
            this.context = context;
        }

        public List<Episodio> getAll()
        {
            return context.Episodio.Include(a => a.anime).ToList();
        }
        public List<Episodio> getAll(int? id)
        {
            List<Episodio> lista = new List<Episodio>();
            //esta puxando os episodios referent eao anime e como esta sendo passado o id pela rota simplifica na hora da busca sem precisar fazer um inner join 
            lista = context.Episodio.Where(x => x.animeId == id).ToList();
            return lista;
        }
        public bool create(Episodio episodio)
        {
            try
            {
                context.Episodio.Add(episodio);//adiciona o novo anime 
                context.SaveChanges();//salva o novo anime no banco de dados 
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Episodio get(int? id)
        {
            return context.Episodio.Include(a => a.anime).FirstOrDefault(a => a.Id == id);
        }
        public bool update(Episodio a)
        {
            try
            {
                context.Episodio.Update(a);
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
                context.Episodio.Remove(get(id));
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
