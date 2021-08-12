using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Final.Models;
using Projeto_Final.Services;
using System.Collections.Generic;
using System.Linq;


namespace Projeto_Final.Controllers
{
   
    public class EpisodioController : Controller
    {
        IEpisodioService _service;
        IAnimeService _animeService;

        public EpisodioController(EpisodioSqlService serviceSql, AnimeSqlService animeserviceSql)
        {
            this._service = serviceSql;
            this._animeService = animeserviceSql;
        }


        public IActionResult Index(int? id)
        {
            
         
            if (_service.getAll(id).Count == 0)
            {
               return RedirectToAction(nameof(Create));
            }
            return View(_service.getAll(id));
           
        }
        private void SetViewBag(List<Episodio> all = null,string nome = null, bool sort = false, string source = null)
        {
            ViewBag.sorted = sort;
            ViewBag.nome = nome;
            if (all == null) all = _service.getAll();
            ViewBag.total = all.Count();
            ViewBag.source = source;          
           

        }
        [HttpGet]
        
        public IActionResult Create()
        {
            var animes = _animeService.getAll();
            ViewBag.listaDeAnimes = new SelectList(animes, "Id", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Episodio episodio)
        {
            var animes = _animeService.getAll();
            ViewBag.listaDeAnimes = new SelectList(animes, "Id", "Nome", episodio.anime);
            if (!ModelState.IsValid) return View(episodio);

            if (_service.create(episodio))
                return View(nameof(Index), _service.getAll());
            else
            {
                return View(episodio);
            }

        }
        public IActionResult Read(int? id)
        {
            Episodio episodio = _service.get(id);
            return episodio != null ? View(episodio) : View(nameof(Index), _service.getAll());// se anime for diferente de null retorna o anime se for igual a null retorna NotFoubd


        }
        public IActionResult Update(int? id)// faz a vereficação se o anime não é nulo e joga para a tela de update
        {

            var animes = _animeService.getAll();
            ViewBag.listaDeAnimes = new SelectList(animes, "Id", "Nome");
            Episodio episodio = _service.get(id);
            return episodio != null ? View(episodio) : View(nameof(Index), _service.getAll());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Episodio episodioatualizado)// pega os dados atualizados do anime e salva no banco de dados 
        {
            var animes = _animeService.getAll();
            ViewBag.listaDeAnimes = new SelectList(animes, "Id", "Nome", episodioatualizado.anime);
            if (!ModelState.IsValid) return View(episodioatualizado);

            if (_service.update(episodioatualizado))// se todos os campos preenchidos corretamente passa o anime como parametro para o metodo updade da classe AnimeSqlService
            {
                return View(nameof(Index), _service.getAll());
            }
            else
            {
                return View(episodioatualizado);//se não foram preenchidos corretamente 
            }

        }
  

        public IActionResult Delete(int? id)
        {
            if (_service.delete(id)) //// ConsultaStaticService.Create(Consulta)
            {
                return View(nameof(Index), _service.getAll());
            }
            else
            {
                return View(nameof(Index), _service.getAll());
            }

        }

     

        
    }
    
}
