using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationDeGestionERP.Models;
using MySqlX.XDevAPI;

namespace ApplicationDeGestionERP.Controllers
{
    public class G_ClientController : Controller
    {
        private readonly ApplicationDbContextes _context;

        public G_ClientController(ApplicationDbContextes context)
        {
            _context = context;
        }

        // GET: G_Client
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        // GET: G_Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (g_Client == null)
            {
                return NotFound();
            }

            return View(g_Client);
        }
        [HttpGet("G_Client/Search")]
        public IActionResult Index(string search)
        {
            // Stocker la requête de recherche dans ViewData pour la réafficher dans le formulaire
            ViewData["SearchQuery"] = search;

            // Récupérer toutes les catégories depuis la base de données
            var client = from c in _context.Clients
                             select c;

            // Filtrer les catégories si un terme de recherche est fourni
            if (!string.IsNullOrEmpty(search))
            {
                client = client.Where(c =>
                    c.NomClient.Contains(search) ||
                    c.PrénomClient.Contains(search) ||
                    c.TelephoneClient.Contains(search) ||
                    c.TypeClient.Contains(search) ||
                    c.MatriculeFiscaleOuCin.Contains(search)
                );
            }

            // Passer les catégories filtrées à la vue
            return View(client.ToList());
        }

        // GET: G_Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: G_Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,NomClient,PrénomClient,AdresseClient,TelephoneClient,TypeClient,MatriculeFiscaleOuCin")] G_Client g_Client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(g_Client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(g_Client);
        }

        // GET: G_Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Client = await _context.Clients.FindAsync(id);
            if (g_Client == null)
            {
                return NotFound();
            }
            return View(g_Client);
        }

        // POST: G_Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,NomClient,PrénomClient,AdresseClient,TelephoneClient,TypeClient,MatriculeFiscaleOuCin")] G_Client g_Client)
        {
            if (id != g_Client.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(g_Client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!G_ClientExists(g_Client.ClientID))
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
            return View(g_Client);
        }

        // GET: G_Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var g_Client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (g_Client == null)
            {
                return NotFound();
            }

            return View(g_Client);
        }

        // POST: G_Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var g_Client = await _context.Clients.FindAsync(id);
            if (g_Client != null)
            {
                _context.Clients.Remove(g_Client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool G_ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientID == id);
        }
    }
}
