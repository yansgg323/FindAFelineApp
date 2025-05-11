using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FindAFelineApp.Data;
using FindAFelineApp.Data.Entities;
using FindAFelineApp.Services.Abstractions;
using FindAFelineApp.Services.DTOs;
using FindAFelineApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FindAFelineApp.Web.Controllers
{
    public class CatsController : Controller
    {
        private readonly ICatService _catService;
        private readonly IAdopterService _adopterService;
        private readonly UserManager<IdentityUser> _userManager;

        public CatsController(ICatService catService, IAdopterService adopterService, UserManager<IdentityUser> userManager)
        {
            _catService = catService;
            _adopterService = adopterService;
            _userManager = userManager;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
            return View(await _catService.GetNotAdoptedAsync());
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _catService.GetByIdAsync(id.Value);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cats/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CatDTO model)
        {
            if (ModelState.IsValid)
            {
                await _catService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize]
        [HttpGet("Cats/Adopt/{catId}")]
        public async Task<IActionResult> Adopt(int? catId)
        {
            if (catId == null)
            {
                return NotFound();
            }

            var userId = (await _userManager.GetUserAsync(User))?.Id;
            var adopter = await _adopterService.GetByUserIdAsync(userId);
            if (adopter == null)
            {
                return RedirectToAction("Create", "Adopter");
            }

            var cat = await _catService.GetByIdAsync(catId.Value);

            if(cat == null)
            {
                return NotFound();
            }
            await _adopterService.AdoptCatAsync(cat, adopter);
            return View(adopter);
        }

        // GET: Cats/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _catService.GetByIdAsync(id.Value);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Edit(int id, CatDTO model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _catService.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CatExistsAsync(model.Id))
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
            return View(model);
        }

        // GET: Cats/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _catService.GetByIdAsync(id.Value);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _catService.GetByIdAsync(id);
            if (cat != null)
            {
                await _catService.DeleteByIdAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CatExistsAsync(int id)
        {
            return (await _catService.GetByIdAsync(id)).Id == id;
        }
    }
}
