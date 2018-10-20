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
    public class MapsController : LanguageController
    {
        private readonly ApplicationDbContext _context;

        public MapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maps1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Map.Include(m => m.Neighborhood);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Maps1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _context.Map
                .Include(m => m.Neighborhood)
                .FirstOrDefaultAsync(m => m.MapId == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // GET: Maps1/Create
        public IActionResult Create()
        {
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "NeighborhoodId");
            return View();
        }

        // POST: Maps1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MapId,Type,NeighborhoodId")] Map map)
        {
            if (ModelState.IsValid)
            {
                _context.Add(map);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "NeighborhoodId", map.NeighborhoodId);
            return View(map);
        }

        // GET: Maps1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _context.Map.FindAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "NeighborhoodId", map.NeighborhoodId);
            return View(map);
        }

        // POST: Maps1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MapId,Type,NeighborhoodId")] Map map)
        {
            if (id != map.MapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(map);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapExists(map.MapId))
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
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "NeighborhoodId", map.NeighborhoodId);
            return View(map);
        }

        // GET: Maps1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _context.Map
                .Include(m => m.Neighborhood)
                .FirstOrDefaultAsync(m => m.MapId == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // POST: Maps1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var map = await _context.Map.FindAsync(id);
            _context.Map.Remove(map);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapExists(int id)
        {
            return _context.Map.Any(e => e.MapId == id);
        }
    }
}
