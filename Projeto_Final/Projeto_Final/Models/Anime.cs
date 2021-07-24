using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Anime
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }
        [Display(Name = "Episodio")]
        public int Episodio { get; set; }
        [Display(Name = "Temporada")]
        public int Temporada { get; set; }

    }
}
