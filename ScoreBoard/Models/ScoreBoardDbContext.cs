using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class ScoreBoardDbContext : DbContext
    {
        public ScoreBoardDbContext(DbContextOptions<ScoreBoardDbContext> options) : base(options)
        {
        }

        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Jeu> Jeux { get; set; }

       
    }
}
