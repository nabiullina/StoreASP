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
    public class PostavkaProductsController : Controller
    {
        private readonly storeContext _context;

        public PostavkaProductsController(storeContext context)
        {
            _context = context;
        }

        // GET: PostavkaProducts
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.PostavkaProducts.Include(p => p.IdPostavkaNavigation).Include(p => p.IdProductNavigation);
            return View(await storeContext.ToListAsync());
        }

        // GET: PostavkaProducts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.PostavkaProducts == null)
            {
                return NotFound();
            }

            var postavkaProduct = await _context.PostavkaProducts
                .Include(p => p.IdPostavkaNavigation)
                .Include(p => p.IdProductNavigation)
                .FirstOrDefaultAsync(m => m.IdPostavka == id);
            if (postavkaProduct == null)
            {
                return NotFound();
            }

            return View(postavkaProduct);
        }

        // GET: PostavkaProducts/Create
        public IActionResult Create()
        {
            ViewData["IdPostavka"] = new SelectList(_context.Postavkas, "IdPostavka", "IdPostavka");
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct");
            return View();
        }

        // POST: PostavkaProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPostavka,IdProduct,KolVo")] PostavkaProduct postavkaProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postavkaProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPostavka"] = new SelectList(_context.Postavkas, "IdPostavka", "IdPostavka", postavkaProduct.IdPostavka);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", postavkaProduct.IdProduct);
            return View(postavkaProduct);
        }

        // GET: PostavkaProducts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.PostavkaProducts == null)
            {
                return NotFound();
            }

            var postavkaProduct = await _context.PostavkaProducts.FindAsync(id);
            if (postavkaProduct == null)
            {
                return NotFound();
            }
            ViewData["IdPostavka"] = new SelectList(_context.Postavkas, "IdPostavka", "IdPostavka", postavkaProduct.IdPostavka);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", postavkaProduct.IdProduct);
            return View(postavkaProduct);
        }

        // POST: PostavkaProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdPostavka,IdProduct,KolVo")] PostavkaProduct postavkaProduct)
        {
            if (id != postavkaProduct.IdPostavka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postavkaProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostavkaProductExists(postavkaProduct.IdPostavka))
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
            ViewData["IdPostavka"] = new SelectList(_context.Postavkas, "IdPostavka", "IdPostavka", postavkaProduct.IdPostavka);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", postavkaProduct.IdProduct);
            return View(postavkaProduct);
        }

        // GET: PostavkaProducts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.PostavkaProducts == null)
            {
                return NotFound();
            }

            var postavkaProduct = await _context.PostavkaProducts
                .Include(p => p.IdPostavkaNavigation)
                .Include(p => p.IdProductNavigation)
                .FirstOrDefaultAsync(m => m.IdPostavka == id);
            if (postavkaProduct == null)
            {
                return NotFound();
            }

            return View(postavkaProduct);
        }

        // POST: PostavkaProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.PostavkaProducts == null)
            {
                return Problem("Entity set 'storeContext.PostavkaProducts'  is null.");
            }
            var postavkaProduct = await _context.PostavkaProducts.FindAsync(id);
            if (postavkaProduct != null)
            {
                _context.PostavkaProducts.Remove(postavkaProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostavkaProductExists(decimal id)
        {
          return (_context.PostavkaProducts?.Any(e => e.IdPostavka == id)).GetValueOrDefault();
        }
    }
}
