using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class InitialiseurBD
    {
       internal static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScoreBoardDbContext(serviceProvider.GetRequiredService<DbContextOptions<ScoreBoardDbContext>>()))
            {
                // Vérifiez si la base de données est déjà initialisée
                if (context.Joueurs.Any() || context.Jeux.Any())
                {
                    return; // La base de données est déjà initialisée
                }

                // Ajoutez ici le code pour peupler la base de données avec des données initiales
            }
        }
    }
}
