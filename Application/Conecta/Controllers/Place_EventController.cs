using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.Events;

namespace Conecta.Controllers
{
    public class Place_EventController : LanguageController
    {
        private readonly ApplicationDbContext _context;

        public Place_EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Place_Event
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Place_Event.Include(p => p.Event).Include(p => p.Place);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Place_Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place_Event = await _context.Place_Event
                .Include(p => p.Event)
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.Place_EventId == id);
            if (place_Event == null)
            {
                return NotFound();
            }

            return View(place_Event);
        }

        // GET: Place_Event/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId");
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId");
            return View();
        }

        // POST: Place_Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Place_EventId,EventId,PlaceId")] Place_Event place_Event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place_Event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", place_Event.EventId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId", place_Event.PlaceId);
            return View(place_Event);
        }

        // GET: Place_Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place_Event = await _context.Place_Event.FindAsync(id);
            if (place_Event == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", place_Event.EventId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId", place_Event.PlaceId);
            return View(place_Event);
        }

        // POST: Place_Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Place_EventId,EventId,PlaceId")] Place_Event place_Event)
        {
            if (id != place_Event.Place_EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place_Event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Place_EventExists(place_Event.Place_EventId))
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
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", place_Event.EventId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId", place_Event.PlaceId);
            return View(place_Event);
        }

        // GET: Place_Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place_Event = await _context.Place_Event
                .Include(p => p.Event)
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.Place_EventId == id);
            if (place_Event == null)
            {
                return NotFound();
            }

            return View(place_Event);
        }

        // POST: Place_Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place_Event = await _context.Place_Event.FindAsync(id);
            _context.Place_Event.Remove(place_Event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Place_EventExists(int id)
        {
            return _context.Place_Event.Any(e => e.Place_EventId == id);
        }
    }
}
