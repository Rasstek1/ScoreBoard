using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using ScoreBoard.Repositories;
using ScoreBoard.ViewModels;

namespace ScoreBoard.Controllers
{
    public class DashboardController : Controller
    {

        //injecté le repository IJoueurRepository dans le constructeur du contrôleur DashboardController
        private readonly IJeuRepository _jeuRepository;
        private readonly IJoueurRepository _joueurRepository;

        public DashboardController(IJoueurRepository joueurRepository, IJeuRepository jeuRepository)
        {
            _joueurRepository = joueurRepository;
            _jeuRepository = jeuRepository;
        }

        //Dans la méthode Index du contrôleur DashboardController, récupérez les données nécessaires pour le tableau récapitulatif des scores
        //des joueurs. Cela peut être fait en utilisant votre repository ou tout autre mécanisme d'accès aux données.
        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel();
            // Ajoutez des données à votre modèle de vue ici si nécessaire
            var viewModelList = new List<DashboardViewModel> { viewModel };
            return View(viewModelList);
        }


        private int CalculateTotalScore(IEnumerable<Joueur> joueurs)
        {
            int totalScore = 0;
            foreach (var joueur in joueurs)
            {
                totalScore += joueur.ScoreTotal;
            }
            return totalScore;
        }



    }
}
