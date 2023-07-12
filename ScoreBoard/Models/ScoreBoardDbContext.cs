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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurations supplémentaires si nécessaire
        }
    }
}
