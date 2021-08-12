using Projeto_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Services
{
    public interface IEpisodioService
    {
        bool create(Episodio episodio);
        bool delete(int? id);
        Episodio get(int? id);

        List<Episodio> getAll();
        List<Episodio> getAll(int? id);
        bool update(Episodio e);
    }
}
