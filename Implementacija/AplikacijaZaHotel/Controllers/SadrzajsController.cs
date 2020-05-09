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
    public class SadrzajsController : Controller
    {
        private readonly AplikacijaZaHotelContext _context;

        public SadrzajsController(AplikacijaZaHotelContext context)
        {
            _context = context;
        }

        // GET: Sadrzajs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sadrzaj.ToListAsync());
        }

        // GET: Sadrzajs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sadrzaj = await _context.Sadrzaj
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sadrzaj == null)
            {
                return NotFound();
            }

            return View(sadrzaj);
        }

        // GET: Sadrzajs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sadrzajs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Cijena,Dostupnost,Opis")] Sadrzaj sadrzaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sadrzaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sadrzaj);
        }

        // GET: Sadrzajs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sadrzaj = await _context.Sadrzaj.FindAsync(id);
            if (sadrzaj == null)
            {
                return NotFound();
            }
            return View(sadrzaj);
        }

        // POST: Sadrzajs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Cijena,Dostupnost,Opis")] Sadrzaj sadrzaj)
        {
            if (id != sadrzaj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sadrzaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SadrzajExists(sadrzaj.Id))
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
            return View(sadrzaj);
        }

        // GET: Sadrzajs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sadrzaj = await _context.Sadrzaj
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sadrzaj == null)
            {
                return NotFound();
            }

            return View(sadrzaj);
        }

        // POST: Sadrzajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sadrzaj = await _context.Sadrzaj.FindAsync(id);
            _context.Sadrzaj.Remove(sadrzaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SadrzajExists(int id)
        {
            return _context.Sadrzaj.Any(e => e.Id == id);
        }
    }
}
