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
    public class UserMain_EventController : LanguageController
    {
        private readonly ApplicationDbContext _context;

        public UserMain_EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserMain_Event
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserMain_Event.Include(u => u.Event).Include(u => u.UserMain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserMain_Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMain_Event = await _context.UserMain_Event
                .Include(u => u.Event)
                .Include(u => u.UserMain)
                .FirstOrDefaultAsync(m => m.UserMain_EventId == id);
            if (userMain_Event == null)
            {
                return NotFound();
            }

            return View(userMain_Event);
        }

        // GET: UserMain_Event/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId");
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId");
            return View();
        }

        // POST: UserMain_Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserMain_EventId,Attend,UserMainId,EventId")] UserMain_Event userMain_Event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userMain_Event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", userMain_Event.EventId);
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId", userMain_Event.UserMainId);
            return View(userMain_Event);
        }

        // GET: UserMain_Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMain_Event = await _context.UserMain_Event.FindAsync(id);
            if (userMain_Event == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", userMain_Event.EventId);
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId", userMain_Event.UserMainId);
            return View(userMain_Event);
        }

        // POST: UserMain_Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserMain_EventId,Attend,UserMainId,EventId")] UserMain_Event userMain_Event)
        {
            if (id != userMain_Event.UserMain_EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMain_Event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMain_EventExists(userMain_Event.UserMain_EventId))
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
            ViewData["EventId"] = new SelectList(_context.Event, "UserId", "UserId", userMain_Event.EventId);
            ViewData["UserMainId"] = new SelectList(_context.UserMain, "UserId", "UserId", userMain_Event.UserMainId);
            return View(userMain_Event);
        }

        // GET: UserMain_Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMain_Event = await _context.UserMain_Event
                .Include(u => u.Event)
                .Include(u => u.UserMain)
                .FirstOrDefaultAsync(m => m.UserMain_EventId == id);
            if (userMain_Event == null)
            {
                return NotFound();
            }

            return View(userMain_Event);
        }

        // POST: UserMain_Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userMain_Event = await _context.UserMain_Event.FindAsync(id);
            _context.UserMain_Event.Remove(userMain_Event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserMain_EventExists(int id)
        {
            return _context.UserMain_Event.Any(e => e.UserMain_EventId == id);
        }
    }
}
