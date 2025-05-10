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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FindAFelineApp.Web.Controllers
{
    public class AdopterController : Controller
    {
        private readonly IAdopterService _adopterService;
        private readonly UserManager<IdentityUser> _userManager;

        public AdopterController(IAdopterService adopterService, UserManager<IdentityUser> userManager)
        {
            _adopterService = adopterService;
            _userManager = userManager;
        }

        // GET: Adopter
        public async Task<IActionResult> Index()
        {
            return View(await _adopterService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopter = await _adopterService.GetByIdAsync(id.Value);
            if (adopter == null)
            {
                return NotFound();
            }

            return View(adopter);
        }

        // GET: Adopters/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adopters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdopterDTO model)
        {
            var userId = (await _userManager.GetUserAsync(User))?.Id;
            model.UserId = userId;
            if (ModelState.IsValid)
            {
                await _adopterService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Adopters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopter = await _adopterService.GetByIdAsync(id.Value);
            if (adopter == null)
            {
                return NotFound();
            }
            return View(adopter);
        }

        // POST: Adopters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdopterDTO model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _adopterService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Adopters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopter = await _adopterService.GetByIdAsync(id.Value);
            if (adopter == null)
            {
                return NotFound();
            }

            return View(adopter);
        }

        // POST: Adopters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _adopterService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}