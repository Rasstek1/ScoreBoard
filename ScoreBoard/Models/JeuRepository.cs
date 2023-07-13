using System.Collections.Generic;
using System.Linq;
using ScoreBoard.Models;

namespace ScoreBoard.Repositories
{
    public class JeuRepository : IJeuRepository
    {
        private readonly ScoreBoardDbContext _dbContext;

        public JeuRepository(ScoreBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Jeu> ListeJeux => _dbContext.Jeux.ToList();

        public Jeu GetJeu(int id)
        {
            return _dbContext.Jeux.FirstOrDefault(j => j.Id == id);
        }

        public void Ajouter(Jeu jeu)
        {
            _dbContext.Jeux.Add(jeu);
            _dbContext.SaveChanges();
        }

        public void Modifier(Jeu jeu)
        {
            _dbContext.Jeux.Update(jeu);
            _dbContext.SaveChanges();
        }

        public void Supprimer(int id)
        {
            var jeu = _dbContext.Jeux.FirstOrDefault(j => j.Id == id);
            if (jeu != null)
            {
                _dbContext.Jeux.Remove(jeu);
                _dbContext.SaveChanges();
            }
        }

        public List<Jeu> GetJeux()
        {
            return _dbContext.Jeux.ToList();
        }

    }
}
