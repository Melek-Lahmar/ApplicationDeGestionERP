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
    public class G_FournisseurController : Controller
    {
        private readonly ApplicationDbContextes _context;

        public G_FournisseurController(ApplicationDbContextes context)
        {
            _context = context;
        }

        // GET: G_Fournisseur
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fournisseurs.ToListAsync());
        }

        // GET: G_Fournisseur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Fournisseur = await _context.Fournisseurs
                .FirstOrDefaultAsync(m => m.IDFournisseur == id);
            if (g_Fournisseur == null)
            {
                return NotFound();
            }

            return View(g_Fournisseur);
        }
        [HttpGet("G_Fournisseur/Search")]
        public IActionResult Index(string search)
        {
            // Stocker la requête de recherche dans ViewData pour la réafficher dans le formulaire
            ViewData["SearchQuery"] = search;

            // Récupérer toutes les catégories depuis la base de données
            var four = from c in _context.Fournisseurs
                       select c;

            // Filtrer les catégories si un terme de recherche est fourni
            if (!string.IsNullOrEmpty(search))
            {
                four = four.Where(c =>
                    c.NomFournisseur.Contains(search) ||
                    c.MatriculeFiscale.Contains(search) ||
                    c.NumTelephone.Contains(search) ||
                    c.Description.Contains(search) 
                );
            }

            // Passer les catégories filtrées à la vue
            return View(four.ToList());
        }

        // GET: G_Fournisseur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: G_Fournisseur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFournisseur,NomFournisseur,Description,NumTelephone,Adresse,TotalMontantAchete,MontantPaye")] G_Fournisseur g_Fournisseur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(g_Fournisseur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(g_Fournisseur);
        }

        // GET: G_Fournisseur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Fournisseur = await _context.Fournisseurs.FindAsync(id);
            if (g_Fournisseur == null)
            {
                return NotFound();
            }
            return View(g_Fournisseur);
        }

        // POST: G_Fournisseur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFournisseur,NomFournisseur,Description,NumTelephone,Adresse,TotalMontantAchete,MontantPaye")] G_Fournisseur g_Fournisseur)
        {
            if (id != g_Fournisseur.IDFournisseur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(g_Fournisseur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!G_FournisseurExists(g_Fournisseur.IDFournisseur))
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
            return View(g_Fournisseur);
        }

        // GET: G_Fournisseur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Fournisseur = await _context.Fournisseurs
                .FirstOrDefaultAsync(m => m.IDFournisseur == id);
            if (g_Fournisseur == null)
            {
                return NotFound();
            }

            return View(g_Fournisseur);
        }

        // POST: G_Fournisseur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var g_Fournisseur = await _context.Fournisseurs.FindAsync(id);
            if (g_Fournisseur != null)
            {
                _context.Fournisseurs.Remove(g_Fournisseur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool G_FournisseurExists(int id)
        {
            return _context.Fournisseurs.Any(e => e.IDFournisseur == id);
        }
    }
}
