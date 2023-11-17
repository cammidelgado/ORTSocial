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
    public class CartillaMedicoController : Controller
    {
        private readonly ORTSocialContext _context;

        public CartillaMedicoController(ORTSocialContext context)
        {
            _context = context;
        }

        // GET: CartillaMedico
        public async Task<IActionResult> Index()
        {
            var oRTSocialContext = _context.CartillasMedicos.Include(c => c.Cartilla).Include(c => c.Medico);
            return View(await oRTSocialContext.ToListAsync());
        }

        // GET: CartillaMedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CartillasMedicos == null)
            {
                return NotFound();
            }

            var cartillaMedico = await _context.CartillasMedicos
                .Include(c => c.Cartilla)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(m => m.idCartillaMedico == id);
            if (cartillaMedico == null)
            {
                return NotFound();
            }

            return View(cartillaMedico);
        }

        // GET: CartillaMedico/Create
        public IActionResult Create()
        {
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "IdCartilla");
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico");
            return View();
        }

        // POST: CartillaMedico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCartillaMedico,IdCartilla,IdMedico")] CartillaMedico cartillaMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartillaMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "IdCartilla", cartillaMedico.IdCartilla);
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", cartillaMedico.IdMedico);
            return View(cartillaMedico);
        }

        // GET: CartillaMedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CartillasMedicos == null)
            {
                return NotFound();
            }

            var cartillaMedico = await _context.CartillasMedicos.FindAsync(id);
            if (cartillaMedico == null)
            {
                return NotFound();
            }
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "IdCartilla", cartillaMedico.IdCartilla);
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", cartillaMedico.IdMedico);
            return View(cartillaMedico);
        }

        // POST: CartillaMedico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCartillaMedico,IdCartilla,IdMedico")] CartillaMedico cartillaMedico)
        {
            if (id != cartillaMedico.idCartillaMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartillaMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartillaMedicoExists(cartillaMedico.idCartillaMedico))
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
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "IdCartilla", cartillaMedico.IdCartilla);
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", cartillaMedico.IdMedico);
            return View(cartillaMedico);
        }

        // GET: CartillaMedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CartillasMedicos == null)
            {
                return NotFound();
            }

            var cartillaMedico = await _context.CartillasMedicos
                .Include(c => c.Cartilla)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(m => m.idCartillaMedico == id);
            if (cartillaMedico == null)
            {
                return NotFound();
            }

            return View(cartillaMedico);
        }

        // POST: CartillaMedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CartillasMedicos == null)
            {
                return Problem("Entity set 'ORTSocialContext.CartillasMedicos'  is null.");
            }
            var cartillaMedico = await _context.CartillasMedicos.FindAsync(id);
            if (cartillaMedico != null)
            {
                _context.CartillasMedicos.Remove(cartillaMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartillaMedicoExists(int id)
        {
          return (_context.CartillasMedicos?.Any(e => e.idCartillaMedico == id)).GetValueOrDefault();
        }
    }
}
