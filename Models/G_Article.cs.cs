using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDeGestionERP.Models
{
    public class G_Article
    {
        [Key]
        public int ArticleID { get; set; }

        [Required(ErrorMessage = "La référence de l'article est obligatoire.")]
        [StringLength(50, ErrorMessage = "La référence ne peut pas dépasser 50 caractères.")]
        public string ReferenceArticle { get; set; }

        [Required(ErrorMessage = "Le nom de l'article est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string NomArticle { get; set; }

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string DescriptionArticle { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être positive.")]
        public int QteStockArticle { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix d'achat doit être positif.")]
        public double PrixAchat { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix de vente doit être positif.")]
        public double PrixDeVente { get; set; }

        [Range(0, 100, ErrorMessage = "La TVA doit être entre 0 et 100.")]
        public int TVA { get; set; }

        public int CategorieID { get; set; }

        [ForeignKey("CategorieID")]
        public virtual G_Categorie Categorie { get; set; }

        // Attribut pour l'image du produit
        [StringLength(255, ErrorMessage = "L'URL de l'image ne peut pas dépasser 255 caractères.")]
        public string ImageUrl { get; set; } // Nouvelle propriété pour l'image

        // Propriété calculée pour l'état du produit
        public string Etat
        {
            get { return QteStockArticle == 0 ? "Rupture de Stock" : "En Stock"; }
        }
    }
}