using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.Coins;
using Conecta.Models.Location;

namespace Conecta.Controllers
{
    public class QRMainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QRMainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QRMains
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QRMain.Include(q => q.Event).Include(q => q.Place).Include(q => q.UserMain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QRMains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qRMain = await _context.QRMain
                .Include(q => q.Event)
                .Include(q => q.Place)
                .Include(q => q.UserMain)
                .FirstOrDefaultAsync(m => m.QRMainId == id);
            if (qRMain == null)
            {
                return NotFound();
            }

            return View(qRMain);
        }

        // GET: QRMains/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId");
            ViewData["PlaceId"] = new SelectList(_context.Set<Place>(), "PlaceId", "PlaceId");
            ViewData["UserId"] = new SelectList(_context.UserMain, "UserId", "UserId");
            return View();
        }

        // POST: QRMains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QRMainId,Date,active,scan,UserId,PlaceId,EventId")] QRMain qRMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qRMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", qRMain.EventId);
            ViewData["PlaceId"] = new SelectList(_context.Set<Place>(), "PlaceId", "PlaceId", qRMain.PlaceId);
            ViewData["UserId"] = new SelectList(_context.UserMain, "UserId", "UserId", qRMain.UserId);
            return View(qRMain);
        }

        // GET: QRMains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qRMain = await _context.QRMain.FindAsync(id);
            if (qRMain == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", qRMain.EventId);
            ViewData["PlaceId"] = new SelectList(_context.Set<Place>(), "PlaceId", "PlaceId", qRMain.PlaceId);
            ViewData["UserId"] = new SelectList(_context.UserMain, "UserId", "UserId", qRMain.UserId);
            return View(qRMain);
        }

        // POST: QRMains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QRMainId,Date,active,scan,UserId,PlaceId,EventId")] QRMain qRMain)
        {
            if (id != qRMain.QRMainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qRMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QRMainExists(qRMain.QRMainId))
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
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", qRMain.EventId);
            ViewData["PlaceId"] = new SelectList(_context.Set<Place>(), "PlaceId", "PlaceId", qRMain.PlaceId);
            ViewData["UserId"] = new SelectList(_context.UserMain, "UserId", "UserId", qRMain.UserId);
            return View(qRMain);
        }

        // GET: QRMains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qRMain = await _context.QRMain
                .Include(q => q.Event)
                .Include(q => q.Place)
                .Include(q => q.UserMain)
                .FirstOrDefaultAsync(m => m.QRMainId == id);
            if (qRMain == null)
            {
                return NotFound();
            }

            return View(qRMain);
        }

        // POST: QRMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qRMain = await _context.QRMain.FindAsync(id);
            _context.QRMain.Remove(qRMain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QRMainExists(int id)
        {
            return _context.QRMain.Any(e => e.QRMainId == id);
        }
    }
}
