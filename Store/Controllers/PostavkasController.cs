using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreASP.Models;

namespace StoreASP.Controllers
{
    public class PostavkasController : Controller
    {
        private readonly storeContext _context;

        public PostavkasController(storeContext context)
        {
            _context = context;
        }

        // GET: Postavkas
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.Postavkas.Include(p => p.IdProviderNavigation);
            return View(await storeContext.ToListAsync());
        }

        // GET: Postavkas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Postavkas == null)
            {
                return NotFound();
            }

            var postavka = await _context.Postavkas
                .Include(p => p.IdProviderNavigation)
                .FirstOrDefaultAsync(m => m.IdPostavka == id);
            if (postavka == null)
            {
                return NotFound();
            }

            return View(postavka);
        }

        // GET: Postavkas/Create
        public IActionResult Create()
        {
            ViewData["IdProvider"] = new SelectList(_context.Pproviders, "IdProvider", "IdProvider");
            return View();
        }

        // POST: Postavkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPostavka,DataPostavka,CostZakupki,StatusPostavka,IdProvider")] Postavka postavka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postavka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvider"] = new SelectList(_context.Pproviders, "IdProvider", "IdProvider", postavka.IdProvider);
            return View(postavka);
        }

        // GET: Postavkas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Postavkas == null)
            {
                return NotFound();
            }

            var postavka = await _context.Postavkas.FindAsync(id);
            if (postavka == null)
            {
                return NotFound();
            }
            ViewData["IdProvider"] = new SelectList(_context.Pproviders, "IdProvider", "IdProvider", postavka.IdProvider);
            return View(postavka);
        }

        // POST: Postavkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdPostavka,DataPostavka,CostZakupki,StatusPostavka,IdProvider")] Postavka postavka)
        {
            if (id != postavka.IdPostavka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postavka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostavkaExists(postavka.IdPostavka))
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
            ViewData["IdProvider"] = new SelectList(_context.Pproviders, "IdProvider", "IdProvider", postavka.IdProvider);
            return View(postavka);
        }

        // GET: Postavkas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Postavkas == null)
            {
                return NotFound();
            }

            var postavka = await _context.Postavkas
                .Include(p => p.IdProviderNavigation)
                .FirstOrDefaultAsync(m => m.IdPostavka == id);
            if (postavka == null)
            {
                return NotFound();
            }

            return View(postavka);
        }

        // POST: Postavkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Postavkas == null)
            {
                return Problem("Entity set 'storeContext.Postavkas'  is null.");
            }
            var postavka = await _context.Postavkas.FindAsync(id);
            if (postavka != null)
            {
                _context.Postavkas.Remove(postavka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostavkaExists(long id)
        {
          return (_context.Postavkas?.Any(e => e.IdPostavka == id)).GetValueOrDefault();
        }
    }
}
