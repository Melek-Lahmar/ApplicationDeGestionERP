using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDeGestionERP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FastReport.Data;
using MySqlX.XDevAPI;

namespace ApplicationDeGestionERP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        private readonly ApplicationDbContextes _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashBoardController(ApplicationDbContextes context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> tables()
        {
            // Charger les clients et inclure les informations de factures, lignes de factures et articles
            var clients = await _context.Clients
                .Include(c => c.Factures)
                    .ThenInclude(f => f.LignesFacture)
                        .ThenInclude(l => l.Article)  // Inclure l'article pour chaque ligne de facture
                .ToListAsync();

            // Calculer le total des achats pour chaque client et trier par TotalAchat décroissant
            var clientTotals = clients
                .Select(client => new
                {
                    Client = client,
                    TotalAchat = client.Factures
                                         .SelectMany(f => f.LignesFacture) // Aplatir les lignes de facture
                                         .Sum(l => l.Quantite * (l.Article != null ? l.Article.PrixAchat : 0)) // Calcul du total d'achats en évitant les null
                })
                .OrderByDescending(ct => ct.TotalAchat) // Trier par TotalAchat décroissant
                .ToList();

            // Passer les résultats triés à la vue sous forme de ViewBag (dictionnaire par ClientID)
            ViewBag.ClientTotals = clientTotals.ToDictionary(ct => ct.Client.ClientID, ct => ct.TotalAchat);

            // Retourner les clients triés à la vue
            return View(clientTotals.Select(ct => ct.Client).ToList());
        }




        public async Task<IActionResult> charts()
        {
            // Récupérer les articles les plus fréquemment achetés
            var articles = await _context.LignesFacture
                .GroupBy(l => l.ArticleID)
                .Where(g => g.Sum(l => l.Quantite) > 10)
                .Select(g => new
                {
                    ArticleID = g.Key,
                    ArticleName = g.First().Article.NomArticle,
                    TotalQuantity = g.Sum(l => l.Quantite),
                    TotalGagner = g.Sum(l => (l.Article.PrixDeVente - l.Article.PrixAchat) * l.Quantite) // Correction du calcul de gain
                })
                .OrderByDescending(a => a.TotalQuantity)
                .ToListAsync();

            // Si aucun article trouvé, passer une liste vide
            ViewBag.Articles = articles.Any() ? articles.Cast<object>().ToList() : new List<object>();

            
            return View();
        }














    }

}
