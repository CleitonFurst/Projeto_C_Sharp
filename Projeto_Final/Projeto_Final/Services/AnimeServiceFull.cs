using Projeto_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Services
{
    public class AnimeServiceFull : IAnimeService
    {
        IAnimeService _serviceStatic, _serviceSql;
        public AnimeServiceFull(AnimeSqlService serviceSql, AnimeStaticService serviceStatic)
        {
            _serviceStatic = serviceStatic;
            _serviceSql = serviceSql;

        }
        public List<Anime> getAll(string buscar = null, bool ordenar = false) {
            List<Anime> Sql = _serviceSql.getAll(buscar, ordenar);
            List<Anime> Static = _serviceStatic.getAll(buscar, ordenar);
            return Static.Concat(Sql).ToList();
        }

        public bool create(Anime anime)
        {
            return false;
        }
        public bool delete(int? id)
        {
            return false;
        }
        public Anime get(int? id)
        {
            return new();
        }
        public  bool update(Anime a)
        {
            return false;
        }
    }
}
