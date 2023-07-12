using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Jeu
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du jeu est requis.")]
        public string Nom { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de sortie du jeu est requise.")]
        [Display(Name = "Date de sortie")]
        [ValidateDateInPast(ErrorMessage = "La date de sortie doit être antérieure à la date du jour.")]
        public DateTime DateSortie { get; set; }

        [Required(ErrorMessage = "La description du jeu est requise.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "L'identifiant du joueur est requis.")]
        [Range(1, int.MaxValue, ErrorMessage = "L'identifiant du joueur doit être un nombre positif.")]
        public int JoueurId { get; set; }

        public Joueur Joueur { get; set; }

        [Required(ErrorMessage = "Le score du joueur est requis.")]
        [Range(0, 100, ErrorMessage = "Le score doit être compris entre 0 et 100.")]
        public int ScoreJoueur { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date d'enregistrement du jeu est requise.")]
        [Display(Name = "Date d'enregistrement")]
        [ValidateDateInPast(ErrorMessage = "La date d'enregistrement doit être antérieure à la date du jour.")]
        public DateTime DateEnregistrement { get; set; }
    }

    public class ValidateDateInPastAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date >= DateTime.Today)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
