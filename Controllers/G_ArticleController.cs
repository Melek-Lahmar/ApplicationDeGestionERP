using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationDeGestionERP.Models;

namespace ApplicationDeGestionERP.Controllers
{
    public class G_ArticleController : Controller
    {
        private readonly ApplicationDbContextes _context;

        public G_ArticleController(ApplicationDbContextes context)
        {
            _context = context;
        }

        // GET: G_Article
        public async Task<IActionResult> Index()
        {
            var applicationDbContextes = _context.Articles.Include(g => g.Categorie);
            return View(await applicationDbContextes.ToListAsync());
        }
        [HttpGet("G_Article/Search")]
        public IActionResult Index(string search)
        {
            // Stocker la requête de recherche dans ViewData pour la réafficher dans le formulaire
            ViewData["SearchQuery"] = search;

            // Récupérer tous les articles depuis la base de données
            var articles = from a in _context.Articles
                           select a;

            // Filtrer les articles si un terme de recherche est fourni
            if (!string.IsNullOrEmpty(search))
            {
                articles = articles.Where(a =>
                    a.NomArticle.Contains(search) ||
                    a.DescriptionArticle.Contains(search) ||
                    a.PrixAchat.ToString().Contains(search) ||
                    a.PrixDeVente.ToString().Contains(search) ||
                    a.QteStockArticle.ToString().Contains(search) ||
                    a.ReferenceArticle.ToString().Contains(search)
                );
            }

            // Passer les articles filtrés à la vue
            return View(articles.ToList());
        }

        // GET: G_Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Article = await _context.Articles
                .Include(g => g.Categorie)
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (g_Article == null)
            {
                return NotFound();
            }

            return View(g_Article);
        }

        // GET: G_Article/Create
        public IActionResult Create()
        {
            ViewData["CategorieID"] = new SelectList(_context.Categories, "CategorieID", "NomCategorie");
            return View();
        }

        // POST: G_Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleID,ReferenceArticle,NomArticle,DescriptionArticle,QteStockArticle,PrixAchat,PrixDeVente,TVA,CategorieID,ImageUrl")] G_Article g_Article)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(g_Article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieID"] = new SelectList(_context.Categories, "CategorieID", "NomCategorie", g_Article.CategorieID);
            return View(g_Article);
        }

        // GET: G_Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Article = await _context.Articles.FindAsync(id);
            if (g_Article == null)
            {
                return NotFound();
            }
            ViewData["CategorieID"] = new SelectList(_context.Categories, "CategorieID", "NomCategorie", g_Article.CategorieID);
            return View(g_Article);
        }

        // POST: G_Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleID,ReferenceArticle,NomArticle,DescriptionArticle,QteStockArticle,PrixAchat,PrixDeVente,TVA,CategorieID,ImageUrl")] G_Article g_Article)
        {
            if (id != g_Article.ArticleID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(g_Article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!G_ArticleExists(g_Article.ArticleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieID"] = new SelectList(_context.Categories, "CategorieID", "NomCategorie", g_Article.CategorieID);
            return View(g_Article);
        }

        // GET: G_Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Article = await _context.Articles
                .Include(g => g.Categorie)
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (g_Article == null)
            {
                return NotFound();
            }

            return View(g_Article);
        }

        // POST: G_Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var g_Article = await _context.Articles.FindAsync(id);
            if (g_Article != null)
            {
                _context.Articles.Remove(g_Article);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool G_ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleID == id);
        }
        /*public async Task<IActionResult> Index(string search)
        {
            ViewData["SearchQuery"] = search;

            var articles = from a in _context.Articles
                           select a;

            if (!string.IsNullOrEmpty(search))
            {
                double searchPrice;
                bool isPrice = double.TryParse(search, out searchPrice);

                articles = articles.Where(a =>
                    a.NomArticle.Contains(search) ||
                    a.DescriptionArticle.Contains(search) ||
                    (isPrice && (a.PrixAchat == searchPrice || a.PrixDeVente == searchPrice)));

            }

            return View(await articles.ToListAsync());
        }*/

    }
}
