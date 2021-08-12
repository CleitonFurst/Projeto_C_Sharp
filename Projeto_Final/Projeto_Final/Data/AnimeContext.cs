using Microsoft.EntityFrameworkCore;
using Projeto_Final.Models;


namespace Projeto_Final.Data
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> option) : base(option) { }

        public DbSet<Anime> Anime { get; set; }
        public DbSet<Episodio> Episodio { get; set; }
    }
}
