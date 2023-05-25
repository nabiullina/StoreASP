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
    public class PprovidersController : Controller
    {
        private readonly storeContext _context;

        public PprovidersController(storeContext context)
        {
            _context = context;
        }

        // GET: Pproviders
        public async Task<IActionResult> Index()
        {
              return _context.Pproviders != null ? 
                          View(await _context.Pproviders.ToListAsync()) :
                          Problem("Entity set 'storeContext.Pproviders'  is null.");
        }

        // GET: Pproviders/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Pproviders == null)
            {
                return NotFound();
            }

            var pprovider = await _context.Pproviders
                .FirstOrDefaultAsync(m => m.IdProvider == id);
            if (pprovider == null)
            {
                return NotFound();
            }

            return View(pprovider);
        }

        // GET: Pproviders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pproviders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProvider,Nazvanie,Fio,Number,Adress")] Pprovider pprovider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pprovider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pprovider);
        }

        // GET: Pproviders/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Pproviders == null)
            {
                return NotFound();
            }

            var pprovider = await _context.Pproviders.FindAsync(id);
            if (pprovider == null)
            {
                return NotFound();
            }
            return View(pprovider);
        }

        // POST: Pproviders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdProvider,Nazvanie,Fio,Number,Adress")] Pprovider pprovider)
        {
            if (id != pprovider.IdProvider)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pprovider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PproviderExists(pprovider.IdProvider))
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
            return View(pprovider);
        }

        // GET: Pproviders/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Pproviders == null)
            {
                return NotFound();
            }

            var pprovider = await _context.Pproviders
                .FirstOrDefaultAsync(m => m.IdProvider == id);
            if (pprovider == null)
            {
                return NotFound();
            }

            return View(pprovider);
        }

        // POST: Pproviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Pproviders == null)
            {
                return Problem("Entity set 'storeContext.Pproviders'  is null.");
            }
            var pprovider = await _context.Pproviders.FindAsync(id);
            if (pprovider != null)
            {
                _context.Pproviders.Remove(pprovider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PproviderExists(decimal id)
        {
          return (_context.Pproviders?.Any(e => e.IdProvider == id)).GetValueOrDefault();
        }
    }
}
