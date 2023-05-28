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
    public class ProductSalesController : Controller
    {
        private readonly storeContext _context;

        public ProductSalesController(storeContext context)
        {
            _context = context;
        }

        // GET: ProductSales
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.ProductSales.Include(p => p.IdProductNavigation).Include(p => p.IdSaleNavigation);
            return View(await storeContext.ToListAsync());
        }

        // GET: ProductSales/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ProductSales == null)
            {
                return NotFound();
            }

            var productSale = await _context.ProductSales
                .Include(p => p.IdProductNavigation)
                .Include(p => p.IdSaleNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (productSale == null)
            {
                return NotFound();
            }

            return View(productSale);
        }

        // GET: ProductSales/Create
        public IActionResult Create()
        {
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct");
            ViewData["IdSale"] = new SelectList(_context.Sales, "IdSale", "IdSale");
            return View();
        }

        // POST: ProductSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,IdSale,KolVo2")] ProductSale productSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", productSale.IdProduct);
            ViewData["IdSale"] = new SelectList(_context.Sales, "IdSale", "IdSale", productSale.IdSale);
            return View(productSale);
        }

        // GET: ProductSales/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ProductSales == null)
            {
                return NotFound();
            }

            var productSale = await _context.ProductSales.FindAsync(id);
            if (productSale == null)
            {
                return NotFound();
            }
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", productSale.IdProduct);
            ViewData["IdSale"] = new SelectList(_context.Sales, "IdSale", "IdSale", productSale.IdSale);
            return View(productSale);
        }

        // POST: ProductSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdProduct,IdSale,KolVo2")] ProductSale productSale)
        {
            if (id != productSale.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSaleExists(productSale.IdProduct))
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
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", productSale.IdProduct);
            ViewData["IdSale"] = new SelectList(_context.Sales, "IdSale", "IdSale", productSale.IdSale);
            return View(productSale);
        }

        // GET: ProductSales/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ProductSales == null)
            {
                return NotFound();
            }

            var productSale = await _context.ProductSales
                .Include(p => p.IdProductNavigation)
                .Include(p => p.IdSaleNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (productSale == null)
            {
                return NotFound();
            }

            return View(productSale);
        }

        // POST: ProductSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ProductSales == null)
            {
                return Problem("Entity set 'storeContext.ProductSales'  is null.");
            }
            var productSale = await _context.ProductSales.FindAsync(id);
            if (productSale != null)
            {
                _context.ProductSales.Remove(productSale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSaleExists(long id)
        {
          return (_context.ProductSales?.Any(e => e.IdProduct == id)).GetValueOrDefault();
        }
    }
}
