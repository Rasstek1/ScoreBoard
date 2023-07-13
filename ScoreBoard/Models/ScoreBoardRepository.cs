using static ScoreBoard.Models.IscoreBoardRepository;
using ScoreBoard.Repositories;

namespace ScoreBoard.Models
{
    public class ScoreBoardRepository : IJoueurRepository
    {
        private readonly ScoreBoardDbContext _dbContext;

        public List<Joueur> ListeJoueurs { get; set; }

        public ScoreBoardRepository(ScoreBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Joueur> GetJoueurs()
        {
            return _dbContext.Joueurs.ToList();
        }

        public void Modifier(Joueur joueur)
        {
            var joueurExistant = _dbContext.Joueurs.Find(joueur.Id);

            if (joueurExistant != null)
            {
                // Mettre à jour les propriétés du joueur existant avec les nouvelles valeurs
                joueurExistant.Nom = joueur.Nom;
                joueurExistant.Prenom = joueur.Prenom;
                joueurExistant.Equipe = joueur.Equipe;
                joueurExistant.Telephone = joueur.Telephone;
                joueurExistant.Courriel = joueur.Courriel;

                _dbContext.SaveChanges();
            }


        }

        public void Supprimer(int id)
        {
            var joueurASupprimer = _dbContext.Joueurs.Find(id);

            if (joueurASupprimer != null)
            {
                _dbContext.Joueurs.Remove(joueurASupprimer);
                _dbContext.SaveChanges();
            }
        }

        public Joueur GetJoueur(int id)
        {
            // Implémentation de la récupération d'un joueur spécifique en fonction de son identifiant
            return _dbContext.Joueurs.FirstOrDefault(j => j.Id == id);
            // ...
        }


    }
}
