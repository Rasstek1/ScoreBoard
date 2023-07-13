using Microsoft.EntityFrameworkCore;
using ScoreBoard.Repositories;

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

                // Ajouter votre code pour récupérer les joueurs et les jeux à partir de vos repositories
                var joueurRepository = serviceProvider.GetRequiredService<IJoueurRepository>();
                var jeuRepository = serviceProvider.GetRequiredService<IJeuRepository>();

                var joueurs = joueurRepository.GetJoueurs();
                var jeux = jeuRepository.GetJeux();

                // Ajouter les joueurs à la base de données
                context.Joueurs.AddRange(
                new Joueur { Id = 0, Nom = "Dupont", Prenom = "Jean", Equipe = "AIGL", Telephone = "514-123-4567", Courriel = "jean.dupont@aigles.com" },
                new Joueur { Id = 1, Nom = "Tremblay", Prenom = "Lucie", Equipe = "RNRD", Telephone = "450-987-6543", Courriel = "lucie.tremblay@renards.com" },
                new Joueur { Id = 2, Nom = "Gagnon", Prenom = "Alexandre", Equipe = "LION", Telephone = "819-345-6789", Courriel = "alexandre.gagnon@lions.com" },
                new Joueur { Id = 3, Nom = "Lapointe", Prenom = "Sophie", Equipe = "TIGR", Telephone = "418-765-4321", Courriel = "sophie.lapointe@tigres.com" },
                new Joueur { Id = 4, Nom = "Nguyen", Prenom = "Kevin", Equipe = "EPRV", Telephone = "514-876-5432", Courriel = "kevin.nguyen@eperviers.com" }
                );
                // Ajouter les jeux à la base de données
                context.Jeux.AddRange(
                new Jeu { Id = 0, Nom = "The Legend of Zelda: Breath of the Wild", DateSortie = new DateTime(2017, 3, 3), Description = "Jeu d'action-aventure en monde ouvert", Joueur = joueurRepository.GetJoueurs()[0], ScoreJoueur = 60, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 1, Nom = "Super Mario Odyssey", DateSortie = new DateTime(2017, 10, 27), Description = "Jeu de plateforme en monde ouvert", Joueur = joueurRepository.GetJoueurs()[0], ScoreJoueur = 50, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 2, Nom = "Red Dead Redemption 2", DateSortie = new DateTime(2018, 10, 26), Description = "Jeu d'action-aventure en monde ouvert dans le Far West", Joueur = joueurRepository.GetJoueurs()[0], ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 3, Nom = "Assassin's Creed Odyssey", DateSortie = new DateTime(2018, 10, 5), Description = "Jeu d'action-aventure en monde ouvert dans la Grèce antique", Joueur = joueurRepository.GetJoueurs()[1], ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 4, Nom = "God of War", DateSortie = new DateTime(2018, 4, 20), Description = "Jeu d'action-aventure en monde ouvert inspiré de la mythologie nordique", Joueur = joueurRepository.GetJoueurs()[1], ScoreJoueur = 30, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 5, Nom = "Cyberpunk 2077", DateSortie = new DateTime(2020, 12, 10), Description = "Jeu de rôle en monde ouvert futuriste", Joueur = joueurRepository.GetJoueurs()[2], ScoreJoueur = 70, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 6, Nom = "The Last of Us Part II", DateSortie = new DateTime(2020, 6, 19), Description = "Jeu d'action-aventure et de survie post-apocalyptique", Joueur = joueurRepository.GetJoueurs()[3], ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 7, Nom = "Animal Crossing: New Horizons", DateSortie = new DateTime(2020, 3, 20), Description = "Jeu de simulation de vie en monde ouvert", Joueur = joueurRepository.GetJoueurs()[3], ScoreJoueur = 10, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 8, Nom = "Doom Eternal", DateSortie = new DateTime(2020, 3, 20), Description = "Jeu de tir à la première personne", Joueur = joueurRepository.GetJoueurs()[3], ScoreJoueur = 90, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 9, Nom = "Ghost of Tsushima", DateSortie = new DateTime(2020, 7, 17), Description = "Jeu d'action-aventure en monde ouvert dans le Japon féodal", Joueur = joueurRepository.GetJoueurs()[4], ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu { Id = 10, Nom = "Hades", DateSortie = new DateTime(2020, 9, 17), Description = "Jeu de rôle d'action roguelike", Joueur = joueurRepository.GetJoueurs()[4], ScoreJoueur = 40, DateEnregistrement = DateTime.Now }
                );

                context.SaveChanges();
            }
        }
    }
}
