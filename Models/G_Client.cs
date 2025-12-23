using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ApplicationDeGestionERP.Models
{
    public class G_Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "Le nom du client est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string NomClient { get; set; }

        [Required(ErrorMessage = "Le Prénom du client est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le Prénom ne peut pas dépasser 100 caractères.")]
        public string PrénomClient { get; set; }

        [Required(ErrorMessage = "L'adresse du client est obligatoire.")]
        [StringLength(200, ErrorMessage = "L'adresse ne peut pas dépasser 200 caractères.")]
        public string AdresseClient { get; set; }

        [Phone(ErrorMessage = "Numéro de téléphone invalide.")]
        public string TelephoneClient { get; set; }

        [Required(ErrorMessage = "Le type de client est obligatoire.")]
        public string TypeClient { get; set; } // "Personne Physique" or "Personne Morale"

        [Required(ErrorMessage = "Le matricule fiscal ou CIN est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le matricule fiscal ou CIN ne peut pas dépasser 50 caractères.")]
        public string MatriculeFiscaleOuCin { get; set; }

        public virtual List<G_Facture> Factures { get; set; } = new List<G_Facture>();

        public double TotalAchat
        {
            get { return Factures?.Sum(f => f.MontantTotalTTC) ?? 0; }
        }
    }
}