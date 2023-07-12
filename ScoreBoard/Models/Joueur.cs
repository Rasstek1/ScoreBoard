using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ScoreBoard.Models
{
    public class Joueur
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du joueur est requis.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Le nom du joueur doit avoir entre 2 et 20 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom du joueur est requis.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Le prénom du joueur doit avoir entre 2 et 20 caractères.")]
        public string Prenom { get; set; }

        [RegularExpression(@"^[A-Z]{2,4}$", ErrorMessage = "Le champ équipe doit avoir entre 2 et 4 lettres majuscules.")]
        public string? Equipe { get; set; }

        [Phone(ErrorMessage = "Le numéro de téléphone doit être au format valide.")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Le courriel du joueur est requis.")]
        [EmailAddress(ErrorMessage = "Le courriel doit être une adresse courriel valide, de format Identifiant@scoreboard.ca.")]
        public string Courriel { get; set; }

        public List<Jeu>? Jeux { get; set; }
    }
}
