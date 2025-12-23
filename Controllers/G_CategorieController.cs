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
    public class G_CategorieController : Controller
    {
        private readonly ApplicationDbContextes _context;

        public G_CategorieController(ApplicationDbContextes context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var categorie = _context.Categories
                .Include(c => c.Articles) // Inclure les articles associés
                .FirstOrDefault(c => c.CategorieID == id);

            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }
        [HttpGet("G_Categorie/Search")]
        public IActionResult Index(string search)
        {
            // Stocker la requête de recherche dans ViewData pour la réafficher dans le formulaire
            ViewData["SearchQuery"] = search;

            // Récupérer toutes les catégories depuis la base de données
            var categories = from c in _context.Categories
                             select c;

            // Filtrer les catégories si un terme de recherche est fourni
            if (!string.IsNullOrEmpty(search))
            {
                categories = categories.Where(c =>
                    c.NomCategorie.Contains(search) ||
                    c.DescriptionCategorie.Contains(search)
                );
            }

            // Passer les catégories filtrées à la vue
            return View(categories.ToList());
        }

        // GET: G_Categorie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: G_Categorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Categorie = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategorieID == id);
            if (g_Categorie == null)
            {
                return NotFound();
            }

            return View(g_Categorie);
        }

        // GET: G_Categorie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: G_Categorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategorieID,NomCategorie,DescriptionCategorie")] G_Categorie g_Categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(g_Categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(g_Categorie);
        }

        // GET: G_Categorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Categorie = await _context.Categories.FindAsync(id);
            if (g_Categorie == null)
            {
                return NotFound();
            }
            return View(g_Categorie);
        }

        // POST: G_Categorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategorieID,NomCategorie,DescriptionCategorie")] G_Categorie g_Categorie)
        {
            if (id != g_Categorie.CategorieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(g_Categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!G_CategorieExists(g_Categorie.CategorieID))
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
            return View(g_Categorie);
        }

        // GET: G_Categorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Categorie = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategorieID == id);
            if (g_Categorie == null)
            {
                return NotFound();
            }

            return View(g_Categorie);
        }

        // POST: G_Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var g_Categorie = await _context.Categories.FindAsync(id);
            if (g_Categorie != null)
            {
                _context.Categories.Remove(g_Categorie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool G_CategorieExists(int id)
        {
            return _context.Categories.Any(e => e.CategorieID == id);
        }
    }
}
