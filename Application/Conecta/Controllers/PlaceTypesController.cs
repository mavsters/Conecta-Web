using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.Type;

namespace Conecta.Controllers
{
    public class PlaceTypesController : LanguageController
    {
        private readonly ApplicationDbContext _context;

        public PlaceTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlaceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlaceType.ToListAsync());
        }

        // GET: PlaceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeType = await _context.PlaceType
                .FirstOrDefaultAsync(m => m.PlaceTypeID == id);
            if (placeType == null)
            {
                return NotFound();
            }

            return View(placeType);
        }

        // GET: PlaceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceTypeID,Name")] PlaceType placeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placeType);
        }

        // GET: PlaceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeType = await _context.PlaceType.FindAsync(id);
            if (placeType == null)
            {
                return NotFound();
            }
            return View(placeType);
        }

        // POST: PlaceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceTypeID,Name")] PlaceType placeType)
        {
            if (id != placeType.PlaceTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceTypeExists(placeType.PlaceTypeID))
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
            return View(placeType);
        }

        // GET: PlaceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeType = await _context.PlaceType
                .FirstOrDefaultAsync(m => m.PlaceTypeID == id);
            if (placeType == null)
            {
                return NotFound();
            }

            return View(placeType);
        }

        // POST: PlaceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placeType = await _context.PlaceType.FindAsync(id);
            _context.PlaceType.Remove(placeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceTypeExists(int id)
        {
            return _context.PlaceType.Any(e => e.PlaceTypeID == id);
        }
    }
}
