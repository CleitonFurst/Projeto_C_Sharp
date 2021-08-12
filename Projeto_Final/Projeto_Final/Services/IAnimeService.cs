using Projeto_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Services
{
    public interface IAnimeService
    {
        bool create(Anime anime);
        bool delete(int? id);
        Anime get(int? id);

        List<Anime> getAll(string buscar = null, bool ordenar = false);

        bool update(Anime a);
    }
}
