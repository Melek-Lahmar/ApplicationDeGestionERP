//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ApplicationDeGestionERP.Models;
//using System.IO.Pipelines;

//namespace ApplicationDeGestionERP.Controllers
//{
//    public class G_FactureController : Controller
//    {
//        private readonly ApplicationDbContextes _context;

//        public G_FactureController(ApplicationDbContextes context)
//        {
//            _context = context;
//        }

//        // GET: G_Facture
//        public async Task<IActionResult> Index()
//        {
//            var factures = await _context.Factures.Include(g => g.Client).ToListAsync();
//            return View(factures);
//        }

//        // GET: G_Facture/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (!id.HasValue)
//            {
//                return NotFound();
//            }

//            var facture = await _context.Factures
//                .Include(g => g.Client)
//                .FirstOrDefaultAsync(m => m.FactureID == id.Value);

//            if (facture == null)
//            {
//                return NotFound();
//            }

//            return View(facture);
//        }

//        // GET: G_Facture/Create
//        public IActionResult Create()
//        {
//            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "AdresseClient");
//            return View();
//        }

//        // POST: G_Facture/Create
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Create(G_Facture facture)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _context.Add(facture);
//        //        await _context.SaveChangesAsync();
//        //        return RedirectToAction(nameof(Index));
//        //    }

//        //    ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "AdresseClient", facture.ClientID);
//        //    return View(facture);
//        //}

//        [HttpPost]
//        //[ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(G_Facture facture)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                    return Json(new { isValid = false, Message = "Model not valid" });

//                if (facture.FactureID == 0)
//                {
//                    _context.Add(facture);
//                }

//                await _context.SaveChangesAsync();
//                return Json(new { isValid = true, data = facture });
//            }
//            catch (Exception ex)
//            {
//                return Json(new { isValid = false, Message = ex.InnerException is null ? ex.Message : ex.InnerException.Message });
//            }
//        }

//        // GET: G_Facture/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (!id.HasValue)
//            {
//                return NotFound();
//            }

//            var facture = await _context.Factures.FindAsync(id.Value);
//            if (facture == null)
//            {
//                return NotFound();
//            }

//            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "AdresseClient", facture.ClientID);
//            return View(facture);
//        }

//        // POST: G_Facture/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, G_Facture facture)
//        {
//            if (id != facture.FactureID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(facture);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!G_FactureExists(facture.FactureID))
//                    {
//                        return NotFound();
//                    }
//                    throw;
//                }
//                return RedirectToAction(nameof(Index));
//            }

//            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "AdresseClient", facture.ClientID);
//            return View(facture);
//        }

//        // GET: G_Facture/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (!id.HasValue)
//            {
//                return NotFound();
//            }

//            var facture = await _context.Factures
//                .Include(g => g.Client)
//                .FirstOrDefaultAsync(m => m.FactureID == id.Value);

//            if (facture == null)
//            {
//                return NotFound();
//            }

//            return View(facture);
//        }

//        // POST: G_Facture/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var facture = await _context.Factures.FindAsync(id);
//            if (facture != null)
//            {
//                _context.Factures.Remove(facture);
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        private bool G_FactureExists(int id)
//        {
//            return _context.Factures.Any(e => e.FactureID == id);
//        }
//        public IActionResult GetLigneFacturePartial(int index)
//        {
//            var ligneFacture = new G_LigneFacture();
//            ViewBag.ArticleID = new SelectList(_context.Articles.ToList(), "ArticleID", "NomArticle");
//            ViewData["Index"] = index; // Passer l'index
//            return PartialView("_LigneFacture", ligneFacture);
//        }
//    }
//}
using ApplicationDeGestionERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using System.IO;
using System.Linq;
using NuGet.Packaging;
using ApplicationDeGestionERP.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using ApplicationDeGestionERP.Helpers;

namespace ApplicationDeGestionERP.Controllers
{

    public class G_FactureController : Controller

    {
        private readonly ApplicationDbContextes _context;

        public G_FactureController(ApplicationDbContextes context)
        {
            _context = context;
        }

        public IActionResult CreateOrEdit(int? id)
        {
            G_Facture model = id == null
                ? new G_Facture { DateFacture = DateTime.Now }
                : _context.Factures
                          .Include(f => f.LignesFacture)
                          .FirstOrDefault(f => f.FactureID == id);

            if (model == null)
                return NotFound();

            ViewBag.Clients = _context.Clients.Select(c => new SelectListItem
            {
                Value = c.ClientID.ToString(),
                Text = c.NomClient + " " + c.PrénomClient
            }).ToList();

            var articles = _context.Articles.Select(a => new SelectListItem
            {
                Value = a.ArticleID.ToString(),
                Text = a.NomArticle
            }).ToList();

            if (!articles.Any())
            {
                ModelState.AddModelError("", "Aucun article trouvé dans la base de données.");
                return View(model);
            }

            ViewBag.Articles = articles;
            return View(model);
        }
        //[HttpGet("G_Facture/Search")]
        //public IActionResult Index(string search)
        //{
        //    // Stocker la requête de recherche dans ViewData pour la réafficher dans le formulaire
        //    ViewData["SearchQuery"] = search;

        //    // Récupérer toutes les factures depuis la base de données
        //    var factures = _context.Factures.AsQueryable();

        //    // Filtrer les factures si un terme de recherche est fourni
        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        factures = factures.Where(f =>
        //            f.FactureRef.Contains(search) ||
        //            (f.Client != null && (f.Client.NomClient.Contains(search) || f.Client.PrénomClient.Contains(search))) ||
        //            f.DateFacture.ToString().Contains(search)
        //        );
        //    }

        //    // Passer les factures filtrées à la vue
        //    return View(factures.ToList());
        //}

        [HttpPost]
        public IActionResult CreateOrEdit([FromBody] G_Facture model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Données invalides." });
                }


                if (model.FactureID == 0)
                    _context.Factures.Add(model);
                else
                    _context.Factures.Update(model);

                foreach (var ligne in model.LignesFacture)
                {
                    ligne.FactureID = model.FactureID;
                    if (ligne.LigneFactureID == 0)
                        _context.LignesFacture.Add(ligne);
                    else
                        _context.LignesFacture.Update(ligne);
                }

                _context.SaveChanges();

                foreach (var ligne in model.LignesFacture)
                {
                    var getArticle = _context.Articles.FirstOrDefault(x => x.ArticleID == ligne.ArticleID);
                    getArticle.QteStockArticle -= ligne.Quantite;
                    _context.SaveChanges();

                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "Erreur interne : " + ex.Message });
            }
        }

        public IActionResult Index()
        {
            var factures = _context.Factures
                .Include(f => f.Client)
                .Include(f => f.LignesFacture)
                .ToList();

            return View(factures);
        }

        public IActionResult Delete(int id)
        {
            var facture = _context.Factures.Include(f => f.LignesFacture).FirstOrDefault(f => f.FactureID == id);
            if (facture != null)
            {
                _context.LignesFacture.RemoveRange(facture.LignesFacture);
                _context.Factures.Remove(facture);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetPrixUnitaire(int articleId)
        {
            var article = _context.Articles.FirstOrDefault(a => a.ArticleID == articleId);
            return article == null ? NotFound() : Json(article.PrixDeVente);
        }

        public IActionResult Details(int id)
        {
            var facture = _context.Factures
                .Include(f => f.Client)
                .Include(f => f.LignesFacture).ThenInclude(l => l.Article)
                .FirstOrDefault(f => f.FactureID == id);

            if (facture == null)
                return NotFound();

            // Calculer le total de la facture
            double total = (facture.MontantTotalTTC) + 1;

            // Convertir la partie entière du total en mots
            int totalEntier = (int)total;
            string totalEnLettres = NumberToWordsConverter.NumberToWords(totalEntier);
            double totale = facture.MontantTotalTTC - facture.MontantTotalHT;
            int timbre = 1;
            // Passer le montant en lettres à la vue
            ViewBag.TotalEnLettres = totalEnLettres;
            ViewBag.totale = totale;
            ViewBag.timbre = timbre;
            return View(facture);
        }


        public IActionResult ImprimerFacture(int id)
        {
            // Récupérer la facture depuis la base de données
            var facture = _context.Factures
                .Include(f => f.LignesFacture)
                .ThenInclude(lf => lf.Article)
                .FirstOrDefault(f => f.FactureID == id);

            if (facture == null)
            {
                return NotFound();
            }

            // Créer un flux mémoire pour écrire le PDF
            using (var ms = new MemoryStream())
            {
                // Créer un PdfWriter à partir du flux mémoire
                using (var writer = new PdfWriter(ms))
                {
                    // Créer un PdfDocument avec le writer
                    using (var pdf = new PdfDocument(writer))
                    {
                        // Créer un document PDF
                        var document = new Document(pdf);

                        // Titre de la facture
                        document.Add(new Paragraph("Facture n° " + facture.FactureID));

                        // Détails de la facture
                        document.Add(new Paragraph("Date : " + facture.DateFacture.ToString("dd/MM/yyyy")));
                        document.Add(new Paragraph("Client : " + facture.Client.NomClient));

                        // Ajouter une ligne horizontale pour la séparation
                        //document.Add(new LineSeparator(1f));

                        // Produits de la facture
                        foreach (var produit in facture.LignesFacture)
                        {
                            document.Add(new Paragraph($"Produit : {produit.Article.NomArticle}, Quantité: {produit.Quantite}, Prix Unitaire: {produit.PrixUnitaire:C2}"));
                        }

                        // Ajouter une ligne horizontale pour la séparation
                        //document.Add(new LineSeparator(1f));

                        // Total de la facture
                        double total = facture.LignesFacture.Sum(lf => lf.Quantite * lf.PrixUnitaire);
                        document.Add(new Paragraph($"Total : {total:C2}"));
                    }
                }

                // Retourner le PDF en tant que fichier téléchargeable
                return File(ms.ToArray(), "application/pdf", "facture_" + id + ".pdf");
            }
        }





    }


}