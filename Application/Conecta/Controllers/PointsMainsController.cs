using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.Points;
using Conecta.Models.Coins;

namespace Conecta.Controllers
{
    public class PointsMainsController : LanguageController
    {
        private readonly ApplicationDbContext _context;

        public PointsMainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PointsMains
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PointsMain.Include(p => p.QRMain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PointsMains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsMain = await _context.PointsMain
                .Include(p => p.QRMain)
                .FirstOrDefaultAsync(m => m.PointsMainId == id);
            if (pointsMain == null)
            {
                return NotFound();
            }

            return View(pointsMain);
        }

        // GET: PointsMains/Create
        public IActionResult Create()
        {
            ViewData["QRMainId"] = new SelectList(_context.Set<QRMain>(), "QRMainId", "QRMainId");
            return View();
        }

        // POST: PointsMains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PointsMainId,Date,count,QRMainId")] PointsMain pointsMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointsMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QRMainId"] = new SelectList(_context.Set<QRMain>(), "QRMainId", "QRMainId", pointsMain.QRMainId);
            return View(pointsMain);
        }

        // GET: PointsMains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsMain = await _context.PointsMain.FindAsync(id);
            if (pointsMain == null)
            {
                return NotFound();
            }
            ViewData["QRMainId"] = new SelectList(_context.Set<QRMain>(), "QRMainId", "QRMainId", pointsMain.QRMainId);
            return View(pointsMain);
        }

        // POST: PointsMains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PointsMainId,Date,count,QRMainId")] PointsMain pointsMain)
        {
            if (id != pointsMain.PointsMainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointsMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointsMainExists(pointsMain.PointsMainId))
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
            ViewData["QRMainId"] = new SelectList(_context.Set<QRMain>(), "QRMainId", "QRMainId", pointsMain.QRMainId);
            return View(pointsMain);
        }

        // GET: PointsMains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsMain = await _context.PointsMain
                .Include(p => p.QRMain)
                .FirstOrDefaultAsync(m => m.PointsMainId == id);
            if (pointsMain == null)
            {
                return NotFound();
            }

            return View(pointsMain);
        }

        // POST: PointsMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointsMain = await _context.PointsMain.FindAsync(id);
            _context.PointsMain.Remove(pointsMain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointsMainExists(int id)
        {
            return _context.PointsMain.Any(e => e.PointsMainId == id);
        }
    }
}
