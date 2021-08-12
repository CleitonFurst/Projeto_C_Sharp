using Microsoft.AspNetCore.Mvc;
using Projeto_Final.Data;
using Projeto_Final.Models;
using Projeto_Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Controllers
{
   
    public class AnimeController : Controller
    {
        IAnimeService _service, _serviceStatic, _serviseSql,_serviceFull;
        
        public AnimeController(AnimeSqlService serviceSql,AnimeStaticService serviceStatic, AnimeServiceFull serviceFull)
        {
            _serviceStatic = serviceStatic;
            _serviseSql = serviceSql;
            _service = serviceSql;
            _serviceFull = serviceFull;
        }

        private void SelectService(string service = "sql")
        {
            switch (service)
            {
                
                case "static":
                    this._service = this._serviceStatic;
                    break;
                case "all":
                    this._service = this._serviceFull;
                    break;
                default:
                    this._service = this._serviseSql;
                    break;
            }
        }
        public IActionResult Index(string busca, bool ordenar = false, string service = "sql")
        {
            SelectService(service);

            ViewBag.ordenar = ordenar;
            if (service == "sql") SetViewBag(nome: busca, sort: ordenar, source: "sql");
            else SetViewBag(nome: busca, sort: ordenar);
          
            if (_service.getAll().Count == 0)
            {
               return RedirectToAction(nameof(Create));
            }
            ViewBag.totalAnimes = _service.getAll().Count;
            int totalEpisodios = 0;
            int totalTemporadas = 0;
            foreach (Anime anime in _service.getAll())
            {
                totalEpisodios += anime.Episodio;
                totalTemporadas += anime.Temporada;
            }
            ViewBag.totalEpisodios = totalEpisodios;
            ViewBag.totalTemporadas = totalTemporadas;

            return View(_service.getAll(busca,ordenar));
        }
        private void SetViewBag(List<Anime> all = null,string nome = null, bool sort = false, string source = null)
        {
            ViewBag.sorted = sort;
            ViewBag.nome = nome;
            if (all == null) all = _service.getAll();
            ViewBag.total = all.Count();
            ViewBag.source = source;
            int totalEpisodios = 0;
            int totalTemporadas = 0;
            foreach (Anime anime in _service.getAll())
            {
                totalEpisodios += anime.Episodio;
                totalTemporadas += anime.Temporada;
            }
            ViewBag.totalEpisodios = totalEpisodios;
            ViewBag.totalTemporadas = totalTemporadas;

        }
        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Anime anime)
        {
            // List<Anime> animes = _context.Anime.ToList();
            //anime.Id = animes.Count() + 1;
            // animes.Add(anime);
            // return View("Index", animes);
            //_context.Add(anime);
            //_context.SaveChanges();
            //return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid) return View(anime);
            return _service.create(anime) ? RedirectToAction(nameof(Index)) : View(anime);//se post crie anime se não volte para a pagina index  
        }
        public IActionResult Read(int? id)
        {
            //Anime anime = _context.Anime.FirstOrDefault(p => p.Id == id);
            //Anime anime = lista.FirstOrDefault(p => p.Id == id);//busca dentro da minha lista p o anime com o id passado por parametro
            //return anime != null ? View(anime) : RedirectToAction(nameof(Index));//verefica se anime for diferente de null retorna Vieww(anime) caso não tenha esse anime retona para a pagina index
            Anime anime = _service.get(id);
            return anime != null ? View(anime) : NotFound();// se anime for diferente de null retorna o anime se for igual a null retorna NotFoubd
        
        
        }
        public IActionResult Update(int? id)// faz a vereficação se o anime não é nulo e joga para a tela de update
        {

            //Anime anime = _context.Anime.FirstOrDefault(p => p.Id == id);
            //return anime != null ?
            //  View(anime) : 
            //RedirectToAction(nameof(Index));
            Anime anime = _service.get(id);
            return anime != null ? View(anime) : NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Anime animeatualizado)// pega os dados atualizados do anime e salva no banco de dados 
        {
            //List<Anime> listaAnimes = _context.Anime.ToList();//cria uma nova lista que recebe os animes já cadastrados 
            //Anime animeExistente = listaAnimes.FirstOrDefault(p => p.Id == animeatualizado.Id);
            //if (animeExistente == null) return RedirectToAction(nameof(Index));

            // int indice = listaAnimes.IndexOf(animeExistente);//pega o indice do anime que esta na lista 

            //listaAnimes[indice] = animeatualizado;

            //return View(nameof(Index), listaAnimes); //retorna para a pagina index a lista com o objeto atualizado 
            //_context.Anime.Update(animeatualizado);
            // _context.SaveChanges();

            // return RedirectToAction(nameof(Index));
            if (!ModelState.IsValid) return View(animeatualizado);

            if (_service.update(animeatualizado))// se todos os campos preenchidos corretamente passa o anime como parametro para o metodo updade da classe AnimeSqlService
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(animeatualizado);//se não foram preenchidos corretamente 
            }

        }
  

        public IActionResult Delete(int? id)
        {
            // List<Anime> lista = _context.Anime.ToList();
            //Anime anime = lista.FirstOrDefault(p => p.Id == id);

            //if (anime != null)
            //{
            //   this.Confirmacao(id);
            //   lista.Remove(anime);
            //   return View(nameof(Index), lista);
            //}
            // return NotFound();
            this.Confirmacao(id);
            
               return NotFound();
           
        }

        public IActionResult Confirmacao(int? id)
        {
            Anime anime = _service.getAll().FirstOrDefault(p => p.Id == id);
            return anime != null ? View(anime) : RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult Confirmacao(Anime anime)
        {

            // Delete(anime.Id);

            if (_service.delete(anime.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            /// return View(nameof(Index));
            /// 
            return NotFound();

        }

        
    }
    
}
