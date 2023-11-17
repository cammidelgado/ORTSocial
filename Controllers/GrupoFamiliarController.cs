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
    public class GrupoFamiliarController : Controller
    {
        private readonly ORTSocialContext _context;

        public GrupoFamiliarController(ORTSocialContext context)
        {
            _context = context;
        }

        // GET: GrupoFamiliar
        public async Task<IActionResult> Index()
        {
              return _context.GruposFamiliares != null ? 
                          View(await _context.GruposFamiliares.ToListAsync()) :
                          Problem("Entity set 'ORTSocialContext.GruposFamiliares'  is null.");
        }

        // GET: GrupoFamiliar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GruposFamiliares == null)
            {
                return NotFound();
            }

            var grupoFamiliar = await _context.GruposFamiliares
                .FirstOrDefaultAsync(m => m.IdGrupoFamiliar == id);
            if (grupoFamiliar == null)
            {
                return NotFound();
            }

            return View(grupoFamiliar);
        }

        // GET: GrupoFamiliar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoFamiliar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupoFamiliar,Nombre,Cantidad")] GrupoFamiliar grupoFamiliar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoFamiliar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoFamiliar);
        }

        // GET: GrupoFamiliar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GruposFamiliares == null)
            {
                return NotFound();
            }

            var grupoFamiliar = await _context.GruposFamiliares.FindAsync(id);
            if (grupoFamiliar == null)
            {
                return NotFound();
            }
            return View(grupoFamiliar);
        }

        // POST: GrupoFamiliar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupoFamiliar,Nombre,Cantidad")] GrupoFamiliar grupoFamiliar)
        {
            if (id != grupoFamiliar.IdGrupoFamiliar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoFamiliar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoFamiliarExists(grupoFamiliar.IdGrupoFamiliar))
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
            return View(grupoFamiliar);
        }

        // GET: GrupoFamiliar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GruposFamiliares == null)
            {
                return NotFound();
            }

            var grupoFamiliar = await _context.GruposFamiliares
                .FirstOrDefaultAsync(m => m.IdGrupoFamiliar == id);
            if (grupoFamiliar == null)
            {
                return NotFound();
            }

            return View(grupoFamiliar);
        }

        // POST: GrupoFamiliar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GruposFamiliares == null)
            {
                return Problem("Entity set 'ORTSocialContext.GruposFamiliares'  is null.");
            }
            var grupoFamiliar = await _context.GruposFamiliares.FindAsync(id);
            if (grupoFamiliar != null)
            {
                _context.GruposFamiliares.Remove(grupoFamiliar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoFamiliarExists(int id)
        {
          return (_context.GruposFamiliares?.Any(e => e.IdGrupoFamiliar == id)).GetValueOrDefault();
        }
    }
}
