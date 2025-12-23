using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDeGestionERP.Models
{
    public class G_LigneFacture
    {
        [Key]
        public int LigneFactureID { get; set; }

        [Required(ErrorMessage = "L'article est obligatoire.")]
        public int ArticleID { get; set; }

        [ForeignKey("ArticleID")]
        public virtual G_Article? Article { get; set; }

        [Required(ErrorMessage = "La quantité est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être au moins 1.")]
        public int Quantite { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix unitaire doit être positif.")]
        public double PrixUnitaire { get; set; }

        public int FactureID { get; set; }

        [ForeignKey("FactureID")]
        public virtual G_Facture? Facture { get; set; }

        public double MontantLigne => Quantite * PrixUnitaire; // Montant calculé de la ligne
    }
}