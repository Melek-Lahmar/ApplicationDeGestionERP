using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDeGestionERP.Models
{
    public class G_Fournisseur
    {
        [Key]
        public int IDFournisseur { get; set; }

        [Required(ErrorMessage = "Le nom du fournisseur est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom du fournisseur ne peut pas dépasser 100 caractères.")]
        public string NomFournisseur { get; set; }

        [StringLength(13, ErrorMessage = "Le matricule fiscale  se compose de 13 chiffres et lettres.")]
        public string MatriculeFiscale { get; set; }


        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le numéro de téléphone ne peut pas dépasser 20 caractères.")]
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public string NumTelephone { get; set; }

        [StringLength(300, ErrorMessage = "L'adresse ne peut pas dépasser 300 caractères.")]
        public string Adresse { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le montant total des achats doit être positif.")]
        public double TotalMontantAchete { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le montant payé doit être positif.")]
        public double MontantPaye { get; set; }

        [NotMapped]
        public double MontantNonPaye
        {
            get { return TotalMontantAchete - MontantPaye; }
        }
    }
}
