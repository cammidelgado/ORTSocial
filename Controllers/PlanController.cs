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
    public class PlanController : Controller
    {
        private readonly ORTSocialContext _context;

        public PlanController(ORTSocialContext context)
        {
            _context = context;
        }

        // GET: Plan
        public async Task<IActionResult> Index()
        {
            var oRTSocialContext = _context.Planes.Include(p => p.Cartilla);
            return View(await oRTSocialContext.ToListAsync());
        }

        // GET: Plan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Planes == null)
            {
                return NotFound();
            }

            var plan = await _context.Planes
                .Include(p => p.Cartilla)
                .FirstOrDefaultAsync(m => m.IdPlan == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Plan/Create
        public IActionResult Create()
        {
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "Nombre");
            return View();
        }

      /*  public async Task<Cartilla> GetCartilla(int idCartilla)
        {
            var cartilla = await _context.Cartillas.FirstOrDefaultAsync(cartilla => cartilla.IdCartilla == idCartilla);
            return cartilla;
        }*/

        // POST: Plan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlan,Nombre,Costo,CantFamiliares,IdCartilla")] Plan plan)
        {
          
            if (ModelState.IsValid)
                
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "IdCartilla", plan.IdCartilla);
            return View(plan);
        }

        // GET: Plan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Planes == null)
            {
                return NotFound();
            }

            var plan = await _context.Planes.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "IdCartilla", plan.IdCartilla);
            return View(plan);
        }

        // POST: Plan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlan,Nombre,Costo,CantFamiliares,IdCartilla")] Plan plan)
        {
            if (id != plan.IdPlan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.IdPlan))
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
            ViewData["IdCartilla"] = new SelectList(_context.Cartillas, "IdCartilla", "IdCartilla", plan.IdCartilla);
            return View(plan);
        }

        // GET: Plan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Planes == null)
            {
                return NotFound();
            }

            var plan = await _context.Planes
                .Include(p => p.Cartilla)
                .FirstOrDefaultAsync(m => m.IdPlan == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Planes == null)
            {
                return Problem("Entity set 'ORTSocialContext.Planes'  is null.");
            }
            var plan = await _context.Planes.FindAsync(id);
            if (plan != null)
            {
                _context.Planes.Remove(plan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanExists(int id)
        {
          return (_context.Planes?.Any(e => e.IdPlan == id)).GetValueOrDefault();
        }
    }
}
