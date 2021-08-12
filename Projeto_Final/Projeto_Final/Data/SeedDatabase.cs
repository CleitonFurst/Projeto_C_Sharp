using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projeto_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<AnimeContext>();
                context.Database.Migrate();

                if (!context.Anime.Any())
                {
                    context.Anime.Add(new Anime
                    {
                        Id = 1,
                        Nome = "Nanatsu no Taizai",
                        link_img = "https://th.bing.com/th/id/R.76ca91023312b3e42a34b658326123b7?rik=1ooSNCadRLA%2fFw&pid=ImgRaw",
                        Sinopse = "A história segue os “Sete Pecados Capitais”," +
                                                                                   "um grupo maligno de cavaleiros que conspiraram " +
                                                                                   "para derrubar o reino de Britânia, " +
                                                                                   "supostamente foram erradicados pelos Cavaleiros Divinos," +
                                                                                   " embora ainda existam rumores de que eles estão vivos." +
                                                                                   "Dez anos depois," +
                                                                                   " os Cavaleiros Divinos realizaram um golpe de estado e " +
                                                                                   "assassinaram o rei," +
                                                                                   "  se tornando os novos e tiranos governantes do reino.Elizabeth, " +
                                                                                   "a única filha do rei," +
                                                                                   " sai em uma jornada para encontrar os “Sete Pecados Capitais”, " +
                                                                                   "e recrutá-los para que possam ajudar a tomar o reino de volta.",
                        Episodio = 96,
                        Temporada = 4
                    });
                    context.Anime.Add(new Anime
                    {
                        Id = 2,
                        Nome = "One Piece",
                        link_img = "https://th.bing.com/th/id/OIP.4ao1__Y6jld7Q41uKujXhwHaEK?pid=ImgDet&rs=1",
                        Sinopse = "One Piece Todos os Episodios Online, " +
                                                                                      "Assistir One Piece Anime Completo, Assistir One Piece Online." +
                                                                                      "Houve um homem que conquistou tudo aquilo que o mundo tinha a oferecer," +
                                                                                      " o lendário Rei dos Piratas," +
                                                                                      "Gold Roger.Capturado e condenado à execução pelo Governo Mundial," +
                                                                                      "suas últimas palavras lançaram legiões aos mares. “Meu tesouro ? Se quiserem," +
                                                                                      "podem pegá - lo.Procurem - no! Ele contém tudo que este mundo pode oferecer!”." +
                                                                                      "Foi a revelação do maior tesouro, o One Piece, cobiçado por homens de todo o mundo," +
                                                                                      "sonhando com fama e riqueza imensuráveis… Assim começou a Grande Era dos Piratas!",
                        Episodio = 983,
                        Temporada = 21
                    });
                }
            }
        }
    }
}
