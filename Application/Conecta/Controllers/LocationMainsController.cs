using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.Location;

namespace Conecta.Controllers
{
    public class LocationMainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationMainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocationMains
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LocationMain.Include(l => l.Place).Include(l => l.UserMain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LocationMains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationMain = await _context.LocationMain
                .Include(l => l.Place)
                .Include(l => l.UserMain)
                .FirstOrDefaultAsync(m => m.LocationMainId == id);
            if (locationMain == null)
            {
                return NotFound();
            }

            return View(locationMain);
        }

        // GET: LocationMains/Create
        public IActionResult Create()
        {
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId");
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId");
            return View();
        }

        // POST: LocationMains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationMainId,Lat,Lon,PlaceId,UserMainId")] LocationMain locationMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId", locationMain.PlaceId);
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId", locationMain.UserMainId);
            return View(locationMain);
        }

        // GET: LocationMains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationMain = await _context.LocationMain.FindAsync(id);
            if (locationMain == null)
            {
                return NotFound();
            }
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId", locationMain.PlaceId);
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId", locationMain.UserMainId);
            return View(locationMain);
        }

        // POST: LocationMains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationMainId,Lat,Lon,PlaceId,UserMainId")] LocationMain locationMain)
        {
            if (id != locationMain.LocationMainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationMainExists(locationMain.LocationMainId))
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
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "PlaceId", locationMain.PlaceId);
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId", locationMain.UserMainId);
            return View(locationMain);
        }

        // GET: LocationMains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationMain = await _context.LocationMain
                .Include(l => l.Place)
                .Include(l => l.UserMain)
                .FirstOrDefaultAsync(m => m.LocationMainId == id);
            if (locationMain == null)
            {
                return NotFound();
            }

            return View(locationMain);
        }

        // POST: LocationMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationMain = await _context.LocationMain.FindAsync(id);
            _context.LocationMain.Remove(locationMain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationMainExists(int id)
        {
            return _context.LocationMain.Any(e => e.LocationMainId == id);
        }
    }
}
