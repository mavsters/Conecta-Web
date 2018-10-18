using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conecta.Data;
using Conecta.Models.User;

namespace Conecta.Controllers
{
    public class UserMainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserMainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserMains
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserMain.ToListAsync());
        }

        // GET: UserMains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMain = await _context.UserMain
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userMain == null)
            {
                return NotFound();
            }

            return View(userMain);
        }

        // GET: UserMains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserMains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Password,Email")] UserMain userMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userMain);
        }

        // GET: UserMains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMain = await _context.UserMain.FindAsync(id);
            if (userMain == null)
            {
                return NotFound();
            }
            return View(userMain);
        }

        // POST: UserMains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Password,Email")] UserMain userMain)
        {
            if (id != userMain.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMainExists(userMain.UserId))
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
            return View(userMain);
        }

        // GET: UserMains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMain = await _context.UserMain
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userMain == null)
            {
                return NotFound();
            }

            return View(userMain);
        }

        // POST: UserMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userMain = await _context.UserMain.FindAsync(id);
            _context.UserMain.Remove(userMain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserMainExists(int id)
        {
            return _context.UserMain.Any(e => e.UserId == id);
        }
    }
}
