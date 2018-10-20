using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.CountryStructure;

namespace Conecta.Controllers
{
    public class CommunesController : LanguageController
    {
        private readonly ApplicationDbContext _context;

        public CommunesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Communes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Commune.Include(c => c.Province);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Communes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commune = await _context.Commune
                .Include(c => c.Province)
                .FirstOrDefaultAsync(m => m.CommuneId == id);
            if (commune == null)
            {
                return NotFound();
            }

            return View(commune);
        }

        // GET: Communes/Create
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceId");
            return View();
        }

        // POST: Communes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommuneId,Name,ProvinceId")] Commune commune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceId", commune.ProvinceId);
            return View(commune);
        }

        // GET: Communes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commune = await _context.Commune.FindAsync(id);
            if (commune == null)
            {
                return NotFound();
            }
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceId", commune.ProvinceId);
            return View(commune);
        }

        // POST: Communes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommuneId,Name,ProvinceId")] Commune commune)
        {
            if (id != commune.CommuneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommuneExists(commune.CommuneId))
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
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceId", commune.ProvinceId);
            return View(commune);
        }

        // GET: Communes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commune = await _context.Commune
                .Include(c => c.Province)
                .FirstOrDefaultAsync(m => m.CommuneId == id);
            if (commune == null)
            {
                return NotFound();
            }

            return View(commune);
        }

        // POST: Communes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commune = await _context.Commune.FindAsync(id);
            _context.Commune.Remove(commune);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommuneExists(int id)
        {
            return _context.Commune.Any(e => e.CommuneId == id);
        }
    }
}
