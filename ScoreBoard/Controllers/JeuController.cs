using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScoreBoard.Models;
using ScoreBoard.Repositories;
using ScoreBoard.ViewModels;
using System;
using System.Linq;

namespace ScoreBoard.Controllers
{
    public class JeuController : Controller
    {
        private readonly IJeuRepository _jeuRepository;
        private readonly IJoueurRepository _joueurRepository;

        public JeuController(IJeuRepository jeuRepository, IJoueurRepository joueurRepository)
        {
            _jeuRepository = jeuRepository;
            _joueurRepository = joueurRepository;
        }

        public IActionResult Index()
        {
            var jeux = _jeuRepository.ListeJeux.Select(j => new JeuViewModel
            {
                Id = j.Id,
                Nom = j.Nom,
                DateSortie = j.DateSortie,
                Description = j.Description,
                JoueurId = j.JoueurId,
                NomJoueur = _joueurRepository.GetJoueur(j.JoueurId)?.Nom,
                ScoreJoueur = j.ScoreJoueur,
                DateEnregistrement = j.DateEnregistrement
            }).ToList();

            return View(jeux);
        }

        public IActionResult Details(int id)
        {
            var jeu = _jeuRepository.GetJeu(id);
            if (jeu == null)
            {
                return NotFound();
            }

            var jeuViewModel = new JeuViewModel
            {
                Id = jeu.Id,
                Nom = jeu.Nom,
                DateSortie = jeu.DateSortie,
                Description = jeu.Description,
                JoueurId = jeu.JoueurId,
                NomJoueur = _joueurRepository.GetJoueur(jeu.JoueurId)?.Nom,
                ScoreJoueur = jeu.ScoreJoueur,
                DateEnregistrement = jeu.DateEnregistrement
            };

            return View(jeuViewModel);
        }
        public IActionResult Create()
        {
            var joueurs = _joueurRepository.ListeJoueurs;

            var jeuViewModel = new JeuViewModel
            {
                Joueurs = joueurs.Select(j => new SelectListItem
                {
                    Value = j.Id.ToString(),
                    Text = j.Nom
                }).ToList()
            };

            return View(jeuViewModel);
        }



        [HttpPost]
        public IActionResult Create(JeuViewModel jeuViewModel)
        {
            if (ModelState.IsValid)
            {
                var jeu = new Jeu
                {
                    Nom = jeuViewModel.Nom,
                    DateSortie = jeuViewModel.DateSortie,
                    Description = jeuViewModel.Description,
                    JoueurId = jeuViewModel.JoueurId,
                    ScoreJoueur = jeuViewModel.ScoreJoueur,
                    DateEnregistrement = DateTime.Now
                };

                _jeuRepository.Ajouter(jeu);

                return RedirectToAction("Index");
            }

            var joueurs = _joueurRepository.ListeJoueurs;
            ViewBag.Joueurs = joueurs;
            return View(jeuViewModel);
        }

        public IActionResult Edit(int id)
        {
            var jeu = _jeuRepository.GetJeu(id);
            if (jeu == null)
            {
                return NotFound();
            }

            var joueurs = _joueurRepository.ListeJoueurs;
            var joueursSelectList = joueurs.Select(j => new SelectListItem
            {
                Value = j.Id.ToString(),
                Text = j.Nom
            }).ToList();

            var jeuViewModel = new JeuViewModel
            {
                Id = jeu.Id,
                Nom = jeu.Nom,
                DateSortie = jeu.DateSortie,
                Description = jeu.Description,
                JoueurId = jeu.JoueurId,
                NomJoueur = jeu.Joueur?.Nom,
                ScoreJoueur = jeu.ScoreJoueur,
                DateEnregistrement = jeu.DateEnregistrement,
                Joueurs = joueursSelectList
            };

            return View(jeuViewModel);
        }


        [HttpPost]
        public IActionResult Edit(int id, JeuViewModel jeuViewModel)
        {
            if (id != jeuViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var jeu = _jeuRepository.GetJeu(id);
                if (jeu == null)
                {
                    return NotFound();
                }

                jeu.Nom = jeuViewModel.Nom;
                jeu.DateSortie = jeuViewModel.DateSortie;
                jeu.Description = jeuViewModel.Description;
                jeu.JoueurId = jeuViewModel.JoueurId;
                jeu.ScoreJoueur = jeuViewModel.ScoreJoueur;

                _jeuRepository.Modifier(jeu);

                return RedirectToAction("Index");
            }

            var joueurs = _joueurRepository.ListeJoueurs;
            ViewBag.Joueurs = joueurs;
            return View(jeuViewModel);
        }

        public IActionResult Delete(int id)
        {
            var jeu = _jeuRepository.GetJeu(id);
            if (jeu == null)
            {
                return NotFound();
            }

            var jeuViewModel = new JeuViewModel
            {
                Id = jeu.Id,
                Nom = jeu.Nom,
                DateSortie = jeu.DateSortie,
                Description = jeu.Description,
                JoueurId = jeu.JoueurId,
                NomJoueur = _joueurRepository.GetJoueur(jeu.JoueurId)?.Nom,
                ScoreJoueur = jeu.ScoreJoueur,
                DateEnregistrement = jeu.DateEnregistrement
            };

            return View(jeuViewModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var jeu = _jeuRepository.GetJeu(id);
            if (jeu == null)
            {
                return NotFound();
            }

            _jeuRepository.Supprimer(id);

            return RedirectToAction("Index");
        }
    }
}
