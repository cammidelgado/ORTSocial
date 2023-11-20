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
    public class TurnoMedicoController : Controller
    {
        private readonly ORTSocialContext _context;

        public TurnoMedicoController(ORTSocialContext context)
        {
            _context = context;
        }

        // GET: TurnoMedico
        public async Task<IActionResult> Index()
        {
            var oRTSocialContext = _context.TurnosMedicos.Include(t => t.Medico).Include(t => t.Socio);
            return View(await oRTSocialContext.ToListAsync());
        }

        // GET: TurnoMedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TurnosMedicos == null)
            {
                return NotFound();
            }

            var turnoMedico = await _context.TurnosMedicos
                .Include(t => t.Medico)
                .Include(t => t.Socio)
                .FirstOrDefaultAsync(m => m.idTurno == id);
            if (turnoMedico == null)
            {
                return NotFound();
            }

            return View(turnoMedico);
        }

        // GET: TurnoMedico/Create
        private async Task<Medico> GetMedico(int idMedico)
        { 
            return await _context.Medicos.FirstOrDefaultAsync(m => m.IdMedico == idMedico);
        }
        public IActionResult Create()
        {
          // ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Especialidad");
           ViewData["IdSocio"] = new SelectList(_context.Socios, "IdSocio", "Dni");
            return View();
        }

        // POST: TurnoMedico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTurno,Fecha,IdMedico,IdSocio")] TurnoMedico turnoMedico)
        {
            /* Medico medico = await GetMedico(turnoMedico.IdMedico);
             turnoMedico.Medico = medico;
             Socio socio = await _context.Socios.FirstOrDefaultAsync(m => m.IdSocio == turnoMedico.IdSocio);
             turnoMedico.Socio = socio;*/

           // if (ModelState.IsValid)
           //{
                _context.Add(turnoMedico);
                await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
            //}

            //ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Especialidad", turnoMedico.IdMedico);
            //var medicosEnCartilla = await ObtenerMedicosPorCartillaAsync(turnoMedico.IdSocio);
           // ViewData["IdMedico"] = new SelectList(medicosEnCartilla, "IdMedico", "Especialidad", turnoMedico.IdMedico);

            //return View(turnoMedico);
        }

        [HttpGet]
        public JsonResult GetMedicosBySocio(int idSocio)
        {
            var medicosEnCartilla = ObtenerMedicosPorCartillaAsync(idSocio).Result;

            return Json(medicosEnCartilla.Select(m => new { value = m.IdMedico, especialidad = m.Especialidad }));
        }

        private async Task<List<Medico>> ObtenerMedicosPorCartillaAsync(int idSocio)
        {
            var socio = await _context.Socios.Include(s => s.Plan).FirstOrDefaultAsync(s => s.IdSocio == idSocio);
            var cartillaId = socio.Plan.IdCartilla;

            var medicosEnCartilla = await _context.CartillasMedicos
                .Where(cm => cm.IdCartilla == cartillaId)
                .Select(cm => cm.Medico)
                .ToListAsync();

            return medicosEnCartilla;
        }

        // GET: TurnoMedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TurnosMedicos == null)
            {
                return NotFound();
            }

            var turnoMedico = await _context.TurnosMedicos.FindAsync(id);
            if (turnoMedico == null)
            {
                return NotFound();
            }
            // ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Especialidad", turnoMedico.IdMedico);
            // ViewData["IdSocio"] = new SelectList(_context.Socios, "IdSocio", "Dni", turnoMedico.IdSocio);

            var socio = await _context.Socios.Include(s => s.Plan).FirstOrDefaultAsync(s => s.IdSocio == turnoMedico.IdSocio);
            var cartillaId = socio.Plan.IdCartilla;
            var medicosEnCartilla = await _context.CartillasMedicos
                .Where(cm => cm.IdCartilla == cartillaId)
                .Select(cm => cm.Medico)
                .ToListAsync();

            ViewData["IdMedico"] = new SelectList(medicosEnCartilla, "IdMedico", "Especialidad", turnoMedico.IdMedico);
            ViewData["IdSocio"] = new SelectList(_context.Socios, "IdSocio", "Dni", turnoMedico.IdSocio);
            return View(turnoMedico);
        }

        // POST: TurnoMedico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTurno,Fecha,IdMedico,IdSocio")] TurnoMedico turnoMedico)
        {
            if (id != turnoMedico.idTurno)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                var socio = await _context.Socios.Include(s => s.Plan).FirstOrDefaultAsync(s => s.IdSocio == turnoMedico.IdSocio);
                var cartillaId = socio.Plan.IdCartilla;

                var medicosEnCartilla = await _context.CartillasMedicos
                    .Where(cm => cm.IdCartilla == cartillaId)
                    .Select(cm => cm.Medico)
                    .ToListAsync();
                ViewData["IdMedico"] = new SelectList(medicosEnCartilla, "IdMedico", "Especialidad", turnoMedico.IdMedico);

                _context.Update(turnoMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoMedicoExists(turnoMedico.idTurno))
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
           // ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Especialidad", turnoMedico.IdMedico);
           // ViewData["IdSocio"] = new SelectList(_context.Socios, "IdSocio", "Dni", turnoMedico.IdSocio);
           // return View(turnoMedico);
        }

        // GET: TurnoMedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TurnosMedicos == null)
            {
                return NotFound();
            }

            var turnoMedico = await _context.TurnosMedicos
                .Include(t => t.Medico)
                .Include(t => t.Socio)
                .FirstOrDefaultAsync(m => m.idTurno == id);
            if (turnoMedico == null)
            {
                return NotFound();
            }

            return View(turnoMedico);
        }

        // POST: TurnoMedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TurnosMedicos == null)
            {
                return Problem("Entity set 'ORTSocialContext.TurnosMedicos'  is null.");
            }
            var turnoMedico = await _context.TurnosMedicos.FindAsync(id);
            if (turnoMedico != null)
            {
                _context.TurnosMedicos.Remove(turnoMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoMedicoExists(int id)
        {
          return (_context.TurnosMedicos?.Any(e => e.idTurno == id)).GetValueOrDefault();
        }
    }
}
