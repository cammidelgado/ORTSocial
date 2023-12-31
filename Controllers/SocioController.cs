﻿using System;
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
    public class SocioController : Controller
    {
        private readonly ORTSocialContext _context;

        public SocioController(ORTSocialContext context)
        {
            _context = context;
        }

        // GET: Socio
        public async Task<IActionResult> Index()
        {
            var oRTSocialContext = _context.Socios.Include(s => s.GrupoFamiliar).Include(s => s.Plan);
            return View(await oRTSocialContext.ToListAsync());
        }

        // GET: Socio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.GrupoFamiliar)
                .Include(s => s.Plan)
                .FirstOrDefaultAsync(m => m.IdSocio == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // GET: Socio/Create
        public IActionResult Create()
        {
            ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "Nombre");
            ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "Nombre");
            return View();
        }

        // POST: Socio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSocio,Dni,Nombre,Apellido,Email,Telefono,Provincia,Ciudad,IdPlan,IdGrupoFamiliar")] Socio socio, string nuevoGrupoFamiliarNombre)
        {
            var grupoFamiliar1 = await _context.GruposFamiliares.FindAsync(socio.IdGrupoFamiliar);
            var plan = await _context.Planes.FindAsync(socio.IdPlan);
            socio.Plan = plan;
            socio.GrupoFamiliar = grupoFamiliar1;

            if (socio.IdGrupoFamiliar == 0)
            {
                GrupoFamiliar nuevoGrupoFamiliar = new()
                {
                    Nombre = nuevoGrupoFamiliarNombre,
                    Cantidad = 1
                };
                _context.Add(nuevoGrupoFamiliar);
                await _context.SaveChangesAsync();
                socio.IdGrupoFamiliar = nuevoGrupoFamiliar.IdGrupoFamiliar;
            } else
            {
                grupoFamiliar1.Cantidad++;
            }

           //if (ModelState.IsValid)
           //{
                _context.Add(socio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
          // ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "Nombre", socio.IdGrupoFamiliar);
           //ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "Nombre", socio.IdPlan);
          // return View(socio);
        }

        // GET: Socio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios.FindAsync(id);
            if (socio == null)
            {
                return NotFound();
            }
            TempData["OldGrupoFamiliarId"] = socio.IdGrupoFamiliar;
            ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "Nombre", socio.IdGrupoFamiliar);
            ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "Nombre", socio.IdPlan);
            return View(socio);
        }

        // POST: Socio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSocio,Dni,Nombre,Apellido,Email,Telefono,Provincia,Ciudad,IdPlan,IdGrupoFamiliar")] Socio socio, string nuevoGrupoFamiliarNombre)
        {
            if (id != socio.IdSocio)
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
                    if (socio.IdGrupoFamiliar == 0)
                    {
                        GrupoFamiliar nuevoGrupoFamiliar = new()
                        {
                            Nombre = nuevoGrupoFamiliarNombre,
                            Cantidad = 1
                        };

                        _context.Add(nuevoGrupoFamiliar);
                        await _context.SaveChangesAsync();

                        socio.IdGrupoFamiliar = nuevoGrupoFamiliar.IdGrupoFamiliar;
                    }
                    else
                    {
                        var newGrupoFamiliar = await _context.GruposFamiliares.FindAsync(socio.IdGrupoFamiliar);
                        if (newGrupoFamiliar != null)
                        {
                            newGrupoFamiliar.Cantidad++;
                            _context.Update(newGrupoFamiliar);
                        }
                    }
                    _context.Update(socio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocioExists(socio.IdSocio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           // }
            //ViewData["IdGrupoFamiliar"] = new SelectList(_context.GruposFamiliares, "IdGrupoFamiliar", "IdGrupoFamiliar", socio.IdGrupoFamiliar);
           //ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "IdPlan", socio.IdPlan);
           //return View(socio);
        }

        // GET: Socio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.GrupoFamiliar)
                .Include(s => s.Plan)
                .FirstOrDefaultAsync(m => m.IdSocio == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // POST: Socio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Socios == null)
            {
                return Problem("Entity set 'ORTSocialContext.Socios'  is null.");
            }
            var socio = await _context.Socios.FindAsync(id);
            if (socio != null)
            {
                var grupoFamiliar = await _context.GruposFamiliares.FindAsync(socio.IdGrupoFamiliar);
                if (grupoFamiliar != null)
                {
                    grupoFamiliar.Cantidad--;
                    _context.Update(grupoFamiliar);
                }
                _context.Socios.Remove(socio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocioExists(int id)
        {
          return (_context.Socios?.Any(e => e.IdSocio == id)).GetValueOrDefault();
        }
    }
}
