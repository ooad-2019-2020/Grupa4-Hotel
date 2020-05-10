using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplikacijaZaHotel.Data;
using AplikacijaZaHotel.Models;

namespace AplikacijaZaHotel.Controllers
{
    public class VrstasController : Controller
    {
        private readonly AplikacijaZaHotelContext _context;

        public VrstasController(AplikacijaZaHotelContext context)
        {
            _context = context;
        }

        // GET: Vrstas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vrsta.ToListAsync());
        }

        // GET: Vrstas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrsta = await _context.Vrsta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vrsta == null)
            {
                return NotFound();
            }

            return View(vrsta);
        }

        // GET: Vrstas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vrstas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Cijena,Balkon,Dostupnost,Kapacitet")] Vrsta vrsta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vrsta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vrsta);
        }

        // GET: Vrstas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrsta = await _context.Vrsta.FindAsync(id);
            if (vrsta == null)
            {
                return NotFound();
            }
            return View(vrsta);
        }

        // POST: Vrstas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Cijena,Balkon,Dostupnost,Kapacitet")] Vrsta vrsta)
        {
            if (id != vrsta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vrsta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VrstaExists(vrsta.Id))
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
            return View(vrsta);
        }

        // GET: Vrstas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrsta = await _context.Vrsta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vrsta == null)
            {
                return NotFound();
            }

            return View(vrsta);
        }

        // POST: Vrstas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vrsta = await _context.Vrsta.FindAsync(id);
            _context.Vrsta.Remove(vrsta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VrstaExists(int id)
        {
            return _context.Vrsta.Any(e => e.Id == id);
        }
    }
}
