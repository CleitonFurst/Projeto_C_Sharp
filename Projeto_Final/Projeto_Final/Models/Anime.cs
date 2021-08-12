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
        [Required(ErrorMessage = "Informe um nome para o anime!")]
        [Display(Name = "Nome")]        
        public string Nome { get; set; }

        [Display(Name = "Img")]
        [Required(ErrorMessage = "Informe um link para a imagem do anime!")]
        public string link_img { get; set; }
        
        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "Adicione a sinopse do anime!")]
        public string Sinopse { get; set; }
        [Display(Name = "Episodio")]
        [Required(ErrorMessage = "Informe a quantidade de episodios!")]
        public int Episodio { get; set; }
        [Display(Name = "Temporada")]
        [Required(ErrorMessage = "Informe quantas temporadas o anime tem !")]
        public int Temporada { get; set; }

        public  List<Episodio> Episodios { get; set; }

    }
}
