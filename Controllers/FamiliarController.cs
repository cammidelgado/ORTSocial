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
    public class FamiliarController : Controller
    {
        private readonly ORTSocialContext _context;

        public FamiliarController(ORTSocialContext context)
        {
            _context = context;
        }

        // GET: Familiar
        public async Task<IActionResult> Index()
        {
            var oRTSocialContext = _context.Familiares.Include(f => f.GrupoFamiliar);
            return View(await oRTSocialContext.ToListAsync());
        }

        // GET: Familiar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Familiares == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiares
                .Include(f => f.GrupoFamiliar)
                .FirstOrDefaultAsync(m => m.IdFamiliar == id);
            if (familiar == null)
            {
                return NotFound();
            }

            return View(familiar);
        }

        // GET: Familiar/Create
        public IActionResult Create()
        {
            ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "Nombre");
            return View();
        }

        // POST: Familiar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFamiliar,Dni,Nombre,Apellido,IdGrupoFamiliar")] Familiar familiar)
        {
            var grupoFamiliar = await _context.GruposFamiliares.FindAsync(familiar.IdGrupoFamiliar);
            if (grupoFamiliar != null)
            {
                grupoFamiliar.Cantidad++;
                _context.Update(grupoFamiliar);
            }
            //if (ModelState.IsValid)
            //{
            _context.Add(familiar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
           // ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "Nombre", familiar.IdGrupoFamiliar);
           // return View(familiar);
        }

        // GET: Familiar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Familiares == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiares.FindAsync(id);
            if (familiar == null)
            {
                return NotFound();
            }
            TempData["OldGrupoFamiliarId"] = familiar.IdGrupoFamiliar;
            ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "Nombre", familiar.IdGrupoFamiliar);
            return View(familiar);
        }

        // POST: Familiar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFamiliar,Dni,Nombre,Apellido,IdGrupoFamiliar")] Familiar familiar)
        {
            if (id != familiar.IdFamiliar)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
           // {
                try
                {
                    var oldGrupoFamiliarId = (int)TempData["OldGrupoFamiliarId"];
                    var oldGrupoFamiliar = await _context.GruposFamiliares.FindAsync(oldGrupoFamiliarId);
                    if (oldGrupoFamiliar != null)
                    {
                        oldGrupoFamiliar.Cantidad--;
                        _context.Update(oldGrupoFamiliar);
                    }
                    var newGrupoFamiliar = await _context.GruposFamiliares.FindAsync(familiar.IdGrupoFamiliar);
                    if (newGrupoFamiliar != null)
                    {
                        newGrupoFamiliar.Cantidad++;
                        _context.Update(newGrupoFamiliar);
                    }

                    _context.Update(familiar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliarExists(familiar.IdFamiliar))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
          //  }
           // ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "Nombre", familiar.IdGrupoFamiliar);
          //  return View(familiar);
        }

        // GET: Familiar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Familiares == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiares
                .Include(f => f.GrupoFamiliar)
                .FirstOrDefaultAsync(m => m.IdFamiliar == id);
            if (familiar == null)
            {
                return NotFound();
            }

            return View(familiar);
        }

        // POST: Familiar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Familiares == null)
            {
                return Problem("Entity set 'ORTSocialContext.Familiares'  is null.");
            }
            var familiar = await _context.Familiares.FindAsync(id);
            if (familiar != null)
            {
                var grupoFamiliar = await _context.GruposFamiliares.FindAsync(familiar.IdGrupoFamiliar);
                if (grupoFamiliar != null)
                {
                    grupoFamiliar.Cantidad--;
                    _context.Update(grupoFamiliar);
                }

                _context.Familiares.Remove(familiar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliarExists(int id)
        {
          return (_context.Familiares?.Any(e => e.IdFamiliar == id)).GetValueOrDefault();
        }
    }
}
