using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly InventoryAppContext _context;

        public InventoriesController(InventoryAppContext context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index(string searchStringSerial, string searchStringPriceFrom, string searchStringPriceTo,
            string searchStringRoom, string searchStringInstallFrom, string searchStringInstallTo)
        {

            var item = from m in _context.Inventory
                       select m;

            if (!String.IsNullOrEmpty(searchStringPriceFrom) && !String.IsNullOrEmpty(searchStringPriceTo))
            {
                item = item.Where(s => s.Price >= decimal.Parse(searchStringPriceFrom) && s.Price <= decimal.Parse(searchStringPriceTo));
            }
            if (!String.IsNullOrEmpty(searchStringInstallFrom) && !String.IsNullOrEmpty(searchStringInstallTo))
            {
                item = item.Where(s => s.InstallationDate >= DateTime.Parse(searchStringInstallFrom) && s.InstallationDate <= DateTime.Parse(searchStringInstallTo));
            }
            if (!String.IsNullOrEmpty(searchStringSerial))
            {
                item = item.Where(s => s.ManufacturerSerialNumber == int.Parse(searchStringSerial));
            }
            if (!String.IsNullOrEmpty(searchStringRoom))
            {
                item = item.Where(s => s.OfficeRoomNumber == searchStringRoom);
            }


            return View(await item.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufacturerSerialNumber,OfficeRoomNumber,OfficeLocation,ComputerSpecification,OperatingSystem,OwnerName,InstallationDate,Price")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufacturerSerialNumber,OfficeRoomNumber,OfficeLocation,ComputerSpecification,OperatingSystem,OwnerName,InstallationDate,Price")] Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.Id))
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
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventory == null)
            {
                return Problem("Entity set 'InventoryAppContext.Inventory'  is null.");
            }
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventory.Remove(inventory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
          return _context.Inventory.Any(e => e.Id == id);
        }
    }
}
