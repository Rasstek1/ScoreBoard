using System.Collections.Generic;
using ScoreBoard.Models;

namespace ScoreBoard.Repositories
{
    public interface IJeuRepository
    {
        List<Jeu> ListeJeux { get; }
        Jeu GetJeu(int id);
        List<Jeu> GetJeux(); // Ajoutez cette méthode
        void Ajouter(Jeu jeu);
        void Modifier(Jeu jeu);
        void Supprimer(int id);

    }
}
