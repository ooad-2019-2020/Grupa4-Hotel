using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplikacijaZaHotel.Data;
using AplikacijaZaHotel.Models;
using System.Data.SqlClient;
using Xceed.Wpf.Toolkit;

namespace AplikacijaZaHotel.Controllers
{
    public class SobasController : Controller
    {
        private readonly AplikacijaZaHotelContext _context;

        public SobasController(AplikacijaZaHotelContext context)
        {
            _context = context;
        }

        // GET: Sobas
        public async Task<IActionResult> Index()
        {
            var aplikacijaZaHotelContext = _context.Soba.Include(s => s.Vrsta);
            return View(await aplikacijaZaHotelContext.ToListAsync());
        }

        // GET: Sobas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Soba
                .Include(s => s.Vrsta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        // GET: Sobas/Create
        public IActionResult Create()
        {
            ViewData["VrstaID"] = new SelectList(_context.Vrsta, "VrstaId", "Naziv");
            return View();
        }

        // POST: Sobas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrojSobe,VrstaID")] Soba soba)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(soba);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
            }
            catch(Exception ex)
            {
                //Console.WriteLine("sta ima");
                ModelState.AddModelError("Error", "Uneseni broj sobe je zazet!");
            }

            ViewData["VrstaID"] = new SelectList(_context.Vrsta, "VrstaId", "Naziv", soba.VrstaID);
            return View(soba);
        }

        // GET: Sobas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Soba.FindAsync(id);
            if (soba == null)
            {
                return NotFound();
            }
            ViewData["VrstaID"] = new SelectList(_context.Vrsta, "VrstaId", "Naziv", soba.VrstaID);
            return View(soba);
        }

        // POST: Sobas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrojSobe,VrstaID")] Soba soba)
        {
            if (id != soba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soba);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SobaExists(soba.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
              
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("sta ima");
                    ModelState.AddModelError("Error", "Uneseni broj sobe je zazet!");
                    //return RedirectToAction(nameof(Edit));
                }
                //return RedirectToAction(nameof(Index));
            }


            ViewData["VrstaID"] = new SelectList(_context.Vrsta, "VrstaId", "Naziv", soba.VrstaID);
            return View(soba);
        }

        // GET: Sobas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Soba
                .Include(s => s.Vrsta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        // POST: Sobas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soba = await _context.Soba.FindAsync(id);
            _context.Soba.Remove(soba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SobaExists(int id)
        {
            return _context.Soba.Any(e => e.Id == id);
        }
    }
}
