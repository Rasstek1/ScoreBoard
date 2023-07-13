namespace ScoreBoard.Models
{
    public interface IJoueurRepository
    {
        List<Joueur> ListeJoueurs { get; set; }
        List<Joueur> GetJoueurs();
        Joueur GetJoueur(int id); // Ajoutez cette méthode
        void Modifier(Joueur joueur);
        void Supprimer(int id);
    }
}

//La classe IJoueurRepository est une interface définissant les opérations possibles sur les joueurs,
//telles que l'obtention d'un joueur par ID, la modification d'un joueur, la suppression d'un joueur, etc.

