using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JoueurController : Controller
    {
       private readonly IJoueurRepository _joueurRepository;

        public JoueurController(IJoueurRepository joueurRepository)
        {
            _joueurRepository = joueurRepository;
        }

        public IActionResult Index()
        {
            var joueurs = _joueurRepository.ListeJoueurs;
            return View(joueurs);
        }

        public IActionResult Modifier(int id)
        {
            var joueur = _joueurRepository.GetJoueur(id);
            if (joueur == null)
            {
                return NotFound();
            }

            var viewModel = new JoueurViewModel
            {
                Id = joueur.Id,
                Nom = joueur.Nom,
                Prenom = joueur.Prenom,
                Equipe = joueur.Equipe,
                Telephone = joueur.Telephone,
                Courriel = joueur.Courriel
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Modifier(JoueurViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var joueur = _joueurRepository.GetJoueur(viewModel.Id);
                if (joueur == null)
                {
                    return NotFound();
                }

                joueur.Nom = viewModel.Nom;
                joueur.Prenom = viewModel.Prenom;
                joueur.Equipe = viewModel.Equipe;
                joueur.Telephone = viewModel.Telephone;
                joueur.Courriel = viewModel.Courriel;

                _joueurRepository.Modifier(joueur);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public IActionResult Supprimer(int id)
        {
            var joueur = _joueurRepository.GetJoueur(id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        [HttpPost]
        public IActionResult ConfirmerSuppression(int id)
        {
            _joueurRepository.Supprimer(id);
            return RedirectToAction("Index");
        }
    }
    
}
