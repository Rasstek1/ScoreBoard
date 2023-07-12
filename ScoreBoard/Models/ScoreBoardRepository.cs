using static ScoreBoard.Models.IscoreBoardRepository;

namespace ScoreBoard.Models
{
    public class ScoreBoardRepository : IScoreBoardRepository
    {
        private readonly ScoreBoardDbContext _dbContext;

        public ScoreBoardRepository(ScoreBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Joueur> GetJoueurs()
        {
            return _dbContext.Joueurs.ToList();
        }

        public void AddJoueur(Joueur joueur)
        {
            _dbContext.Joueurs.Add(joueur);
            _dbContext.SaveChanges();
        }

        // Ajoutez d'autres méthodes pour accéder aux données des jeux

        // Implémentez les autres méthodes de l'interface IScoreBoardRepository
    }
}
