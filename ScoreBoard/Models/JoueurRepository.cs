﻿using ScoreBoard.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScoreBoard.Repositories
{
    public class JoueurRepository : IJoueurRepository
    {
        private readonly ScoreBoardDbContext _dbContext;

        public List<Joueur> ListeJoueurs { get; set; }

        public JoueurRepository(ScoreBoardDbContext dbContext)
        {
            _dbContext = dbContext;
            ListeJoueurs = _dbContext.Joueurs.ToList();
        }

        public Joueur? GetJoueur(int id)
        {
            return ListeJoueurs.FirstOrDefault(j => j.Id == id);
        }

        public void Ajouter(Joueur joueur)
        {
            _dbContext.Joueurs.Add(joueur);
            _dbContext.SaveChanges();
            ListeJoueurs.Add(joueur);
        }

        public void Modifier(Joueur joueur)
        {
            _dbContext.Joueurs.Update(joueur);
            _dbContext.SaveChanges();
        }

        public void Supprimer(int id)
        {
            var joueur = _dbContext.Joueurs.FirstOrDefault(j => j.Id == id);
            if (joueur != null)
            {
                _dbContext.Joueurs.Remove(joueur);
                _dbContext.SaveChanges();
                ListeJoueurs.Remove(joueur);
            }
        }
    }
}
