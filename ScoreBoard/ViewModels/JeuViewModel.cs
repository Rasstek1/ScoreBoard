using Microsoft.AspNetCore.Mvc.Rendering;
using ScoreBoard.Models;

namespace ScoreBoard.ViewModels
{
    public class JeuViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateSortie { get; set; }
        public string Description { get; set; }
        public int JoueurId { get; set; }
        public string NomJoueur { get; set; }
        public int ScoreJoueur { get; set; }
        public DateTime DateEnregistrement { get; set; }

        public List<SelectListItem> Joueurs { get; set; }

      
    }
}
