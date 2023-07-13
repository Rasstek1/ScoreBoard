using ScoreBoard.Models;
using ScoreBoard.ViewModels;

namespace ScoreBoard.ViewModels
{
    public class DashboardViewModel
    {
        public List<(Joueur joueur, int score)> ScoresJoueurs { get; set; }
        public List<Joueur> Joueurs { get; set; }
    }
}
