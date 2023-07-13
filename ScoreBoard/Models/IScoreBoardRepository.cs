namespace ScoreBoard.Models
{
    public interface IScoreBoardRepository
    {
        IEnumerable<Joueur> GetJoueurs();
        void AddJoueur(Joueur joueur);
        // Ajoutez d'autres méthodes pour accéder aux données des jeux

        // Implémentez les autres méthodes pour accéder aux données des joueurs et des jeux
    }
}
