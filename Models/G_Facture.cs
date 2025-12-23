using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDeGestionERP.Models
{
    public class G_Facture
    {
        [Key]
        public int FactureID { get; set; }

        [Required(ErrorMessage = "La référence de facture est requise.")]
        [StringLength(50, ErrorMessage = "La référence de facture ne peut pas dépasser 50 caractères.")]
        public string FactureRef { get; set; }

        [Required(ErrorMessage = "La date de la facture est obligatoire.")]
        public DateTime DateFacture { get; set; }

        [Required(ErrorMessage = "Le client est obligatoire.")]
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public virtual G_Client? Client { get; set; }

        public virtual List<G_LigneFacture> LignesFacture { get; set; } = new List<G_LigneFacture>();

        // Calcul des totaux HT et TTC
        public double MontantTotalHT => CalculateMontantTotalHT();
        public double MontantTotalTTC => CalculateMontantTotalTTC();

        // Méthode pour calculer le total HT
        private double CalculateMontantTotalHT()
        {
            double totalHT = 0;
            foreach (var ligne in LignesFacture)
            {
                if (ligne != null)
                {
                    totalHT += ligne.MontantLigne; // Ajouter le montant HT de chaque ligne
                }
            }
            return totalHT;
        }

        // Méthode pour calculer le total TTC, en prenant en compte la TVA de chaque article
        private double CalculateMontantTotalTTC()
        {
            double totalTTC = 0;

            if (LignesFacture != null && LignesFacture.Count > 0) // Vérifiez si LignesFacture n'est pas null et contient des lignes
            {
                foreach (var ligne in LignesFacture)
                {
                    if (ligne != null && ligne.Article != null) // Vérifiez si ligne et ligne.Article ne sont pas null
                    {
                        // Remplacer IsValid par une vérification simple
                        int tauxTVA = ligne.Article.TVA >= 0 ? ligne.Article.TVA : 19;

                        double montantHT = ligne.MontantLigne;
                        double montantTTC = montantHT + (montantHT * tauxTVA / 100);
                        totalTTC += montantTTC;
                    }
                }
            }

            return totalTTC;
        }
    }
}