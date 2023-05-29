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
    public class SalesController : Controller
    {
        private readonly storeContext _context;

        public SalesController(storeContext context)
        {
            _context = context;
        }

        [Route("Sales/GetClientSales/{cliId}")]
        public async Task<IActionResult> GetClientSales(long cliId)
        {
            var deliveries = await _context.Sales.Include("ProductSales.IdProductNavigation").Where(s => s.IdClient == cliId).ToListAsync();
            ViewBag.cliid = cliId;
            return View(deliveries);
        }

        
        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.Sales.Include(s => s.IdClientNavigation);
            return View(await storeContext.ToListAsync());
        }
    
        // GET: Sales/Create
        public async Task<IActionResult> Create(long clientId)
        {
            var sale = new Sale { IdClient = clientId, IdClientNavigation = await _context.Clients.FindAsync(clientId) };
            return View(sale);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(long clientId, [Bind("IdSale,DataS,Oplata,Itogo,IdDiscount")] Sale sale)
        {
            sale.IdClient = clientId;
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetClientSales), new{cliId=clientId});
            }
            return View(sale);
        }

        // GET: Sales/Edit/5
        [Route("Sales/Edit/{saleId}/{cliId}")]
        public async Task<IActionResult> Edit(long saleId, long cliId)
        {
            if (saleId == null || cliId == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.Include("ProductSales.IdProductNavigation").Where(s=>s.IdSale==saleId).FirstOrDefaultAsync();
            if (sale == null)
            {
                return NotFound();
            }
            // ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient", sale.IdClient);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sales/Edit/{saleId}/{cliId}")]
        public async Task<IActionResult> Edit(long saleId, long cliId, [Bind("IdSale,DataS,Oplata,Itogo,IdDiscount")] Sale sale)
        {
            sale.IdClient = cliId;
            if (saleId != sale.IdSale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.IdSale))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetClientSales), new{cliId});
            }
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.IdClientNavigation)
                .FirstOrDefaultAsync(m => m.IdSale == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'storeContext.Sales'  is null.");
            }
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetClientSales), new{cliid=sale.IdClient});
        }

        private bool SaleExists(long id)
        {
          return (_context.Sales?.Any(e => e.IdSale == id)).GetValueOrDefault();
        }
    }
}
