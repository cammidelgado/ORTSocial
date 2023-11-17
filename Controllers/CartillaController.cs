using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORTSocial.Context;
using ORTSocial.Models;

namespace ORTSocial.Controllers
{
    public class CartillaController : Controller
    {
        private readonly ORTSocialContext _context;

        public CartillaController(ORTSocialContext context)
        {
            _context = context;
        }

        // GET: Cartilla
        public async Task<IActionResult> Index()
        {
              return _context.Cartillas != null ? 
                          View(await _context.Cartillas.ToListAsync()) :
                          Problem("Entity set 'ORTSocialContext.Cartillas'  is null.");
        }

        // GET: Cartilla/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cartillas == null)
            {
                return NotFound();
            }

            var cartilla = await _context.Cartillas
                .FirstOrDefaultAsync(m => m.IdCartilla == id);
            if (cartilla == null)
            {
                return NotFound();
            }

            return View(cartilla);
        }

        // GET: Cartilla/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartilla/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCartilla,Nombre")] Cartilla cartilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartilla);
        }

        // GET: Cartilla/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cartillas == null)
            {
                return NotFound();
            }

            var cartilla = await _context.Cartillas.FindAsync(id);
            if (cartilla == null)
            {
                return NotFound();
            }
            return View(cartilla);
        }

        // POST: Cartilla/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCartilla,Nombre")] Cartilla cartilla)
        {
            if (id != cartilla.IdCartilla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartillaExists(cartilla.IdCartilla))
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
            return View(cartilla);
        }

        // GET: Cartilla/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cartillas == null)
            {
                return NotFound();
            }

            var cartilla = await _context.Cartillas
                .FirstOrDefaultAsync(m => m.IdCartilla == id);
            if (cartilla == null)
            {
                return NotFound();
            }

            return View(cartilla);
        }

        // POST: Cartilla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cartillas == null)
            {
                return Problem("Entity set 'ORTSocialContext.Cartillas'  is null.");
            }
            var cartilla = await _context.Cartillas.FindAsync(id);
            if (cartilla != null)
            {
                _context.Cartillas.Remove(cartilla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartillaExists(int id)
        {
          return (_context.Cartillas?.Any(e => e.IdCartilla == id)).GetValueOrDefault();
        }
    }
}
