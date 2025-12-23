using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDeGestionERP.Models
{
    public class G_Categorie
    {
        [Key]
        public int CategorieID { get; set; }

        [Required(ErrorMessage = "Le nom de la catégorie est obligatoire.")]
        [StringLength(100)]
        public string NomCategorie { get; set; }

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string DescriptionCategorie { get; set; } // Nouvelle propriété pour la description

        public virtual List<G_Article> Articles { get; set; } = new List<G_Article>(); // Initialisation de la liste
    }
}
