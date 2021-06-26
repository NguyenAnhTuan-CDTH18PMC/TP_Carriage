using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_Cariage_API.Data;
using TP_Cariage_API.Models;

namespace TP_Cariage_API.Controllers
{
    public class GhesController : Controller
    {
        private readonly TPCarriageContext _context;

        public GhesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: Ghes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ghes.ToListAsync());
        }

        // GET: Ghes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghes = await _context.Ghes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ghes == null)
            {
                return NotFound();
            }

            return View(ghes);
        }

        // GET: Ghes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ghes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SoHang,SoCot,TrangThai")] Ghes ghes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ghes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ghes);
        }

        // GET: Ghes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghes = await _context.Ghes.FindAsync(id);
            if (ghes == null)
            {
                return NotFound();
            }
            return View(ghes);
        }

        // POST: Ghes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SoHang,SoCot,TrangThai")] Ghes ghes)
        {
            if (id != ghes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ghes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GhesExists(ghes.Id))
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
            return View(ghes);
        }

        // GET: Ghes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghes = await _context.Ghes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ghes == null)
            {
                return NotFound();
            }

            return View(ghes);
        }

        // POST: Ghes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ghes = await _context.Ghes.FindAsync(id);
            _context.Ghes.Remove(ghes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GhesExists(int id)
        {
            return _context.Ghes.Any(e => e.Id == id);
        }
    }
}
