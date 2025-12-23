using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDeGestionERP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationDeGestionERP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class G_UtilisateursController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public G_UtilisateursController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: G_Utilisateurs
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<G_Utilisateurs>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new G_Utilisateurs
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleName = roles.FirstOrDefault() // Prend le premier rôle associé
                });
            }

            return View(userViewModels);
        }

        // GET: G_Utilisateurs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = new G_Utilisateurs
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleName = roles.FirstOrDefault()
            };

            return View(userViewModel);
        }

        // GET: G_Utilisateurs/Create
        public async Task<IActionResult> Create()
        {

            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        // POST: G_Utilisateurs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,RoleName")] G_Utilisateurs g_Utilisateurs)
        {
            
                var user = new IdentityUser { UserName = g_Utilisateurs.UserName, Email = g_Utilisateurs.Email };
                var result = await _userManager.CreateAsync(user, "DefaultPassword123!");

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(g_Utilisateurs.RoleName))
                    {
                        await _userManager.AddToRoleAsync(user, g_Utilisateurs.RoleName);
                    }

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            

            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View(g_Utilisateurs);
        }

        // GET: G_Utilisateurs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = new G_Utilisateurs
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleName = roles.FirstOrDefault()
            };

            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View(userViewModel);
        }

        // POST: G_Utilisateurs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Email,RoleName")] G_Utilisateurs g_Utilisateurs)
        {
            if (id != g_Utilisateurs.Id)
            {
                return NotFound();
            }

               var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = g_Utilisateurs.UserName;
                user.Email = g_Utilisateurs.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    if (!string.IsNullOrEmpty(g_Utilisateurs.RoleName))
                    {
                        await _userManager.AddToRoleAsync(user, g_Utilisateurs.RoleName);
                    }

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            

            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View(g_Utilisateurs);
        }

        // GET: G_Utilisateurs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = new G_Utilisateurs
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleName = roles.FirstOrDefault()
            };

            return View(userViewModel);
        }

        // POST: G_Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}