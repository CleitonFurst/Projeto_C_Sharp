using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Episodio
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe um nome para o Episodio!")]
        [Display(Name = "Nome")]        
        public string Nome { get; set; }

        [Display(Name = "Link")]
        [Required(ErrorMessage = "Informe um link para o Episodio!")]
        public string link { get; set; }

        [Display(Name = "Link_img")]
        [Required(ErrorMessage = "Informe um link de uma imagem para o Episodio!")]
        public string link_img { get; set; }

        [Display(Name = "Episodio")]
        [Required(ErrorMessage = "Informe o numero do Episodio!")]
        public int NumeroEpisodio { get; set; }
        [Display(Name = "Temporada")]
        [Required(ErrorMessage = "Informe a temporada do episodio!")]
        public int Temporada { get; set; }

        public int? animeId { get; set; }

        public Anime anime { get; set; }

    }
}
