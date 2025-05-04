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

namespace FindAFelineApp.Web.Controllers
{
    public class FosterParentController : Controller
    {
        private readonly IFosterParentService _fosterParentService;

        public FosterParentController(IFosterParentService fosterParentService)
        {
            _fosterParentService = fosterParentService;
        }

        // GET: FosterParent
        public async Task<IActionResult> Index()
        {
            return View(await _fosterParentService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fosterParent = await _fosterParentService.GetByIdAsync(id.Value);
            if (fosterParent == null)
            {
                return NotFound();
            }

            return View(fosterParent);
        }

        // GET: FosterParent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FosterParents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FosterParentDTO model)
        {
            if (ModelState.IsValid)
            {
                await _fosterParentService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: FosterParent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fosterParent = await _fosterParentService.GetByIdAsync(id.Value);
            if (fosterParent == null)
            {
                return NotFound();
            }
            return View(fosterParent);
        }

        // POST: FosterParents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FosterParentDTO model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _fosterParentService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: FosterParents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fosterParent = await _fosterParentService.GetByIdAsync(id.Value);
            if (fosterParent == null)
            {
                return NotFound();
            }

            return View(fosterParent);
        }

        // POST: FosterParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _fosterParentService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}