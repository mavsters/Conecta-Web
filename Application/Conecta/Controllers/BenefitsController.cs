using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.Coins;
using Conecta.Models.Points;

namespace Conecta.Controllers
{
    public class BenefitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BenefitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Benefits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Benefits.Include(b => b.PointsMain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Benefits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefits = await _context.Benefits
                .Include(b => b.PointsMain)
                .FirstOrDefaultAsync(m => m.BenefitsId == id);
            if (benefits == null)
            {
                return NotFound();
            }

            return View(benefits);
        }

        // GET: Benefits/Create
        public IActionResult Create()
        {
            ViewData["PointsMainId"] = new SelectList(_context.Set<PointsMain>(), "PointsMainId", "PointsMainId");
            return View();
        }

        // POST: Benefits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BenefitsId,Date,DateEnd,Count,PointsMainId")] Benefits benefits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(benefits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PointsMainId"] = new SelectList(_context.Set<PointsMain>(), "PointsMainId", "PointsMainId", benefits.PointsMainId);
            return View(benefits);
        }

        // GET: Benefits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefits = await _context.Benefits.FindAsync(id);
            if (benefits == null)
            {
                return NotFound();
            }
            ViewData["PointsMainId"] = new SelectList(_context.Set<PointsMain>(), "PointsMainId", "PointsMainId", benefits.PointsMainId);
            return View(benefits);
        }

        // POST: Benefits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BenefitsId,Date,DateEnd,Count,PointsMainId")] Benefits benefits)
        {
            if (id != benefits.BenefitsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(benefits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenefitsExists(benefits.BenefitsId))
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
            ViewData["PointsMainId"] = new SelectList(_context.Set<PointsMain>(), "PointsMainId", "PointsMainId", benefits.PointsMainId);
            return View(benefits);
        }

        // GET: Benefits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefits = await _context.Benefits
                .Include(b => b.PointsMain)
                .FirstOrDefaultAsync(m => m.BenefitsId == id);
            if (benefits == null)
            {
                return NotFound();
            }

            return View(benefits);
        }

        // POST: Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var benefits = await _context.Benefits.FindAsync(id);
            _context.Benefits.Remove(benefits);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BenefitsExists(int id)
        {
            return _context.Benefits.Any(e => e.BenefitsId == id);
        }
    }
}
