using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIGE.Data;
using SIGE.Models;

namespace SIGE.Controllers
{
    public class PeriodoEvaluacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeriodoEvaluacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PeriodoEvaluacion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PeriodosEvaluaciones.Include(p => p.EvaluacionFK).Include(p => p.PeriodoFK);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PeriodoEvaluacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoEvaluacion = await _context.PeriodosEvaluaciones
                .Include(p => p.EvaluacionFK)
                .Include(p => p.PeriodoFK)
                .FirstOrDefaultAsync(m => m.CodPeriodoEvaluacion == id);
            if (periodoEvaluacion == null)
            {
                return NotFound();
            }

            return View(periodoEvaluacion);
        }

        // GET: PeriodoEvaluacion/Create
        public IActionResult Create()
        {
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre");
            ViewData["Periodo"] = new SelectList(_context.Periodos, "CodPeriodo", "Nombre");
            return View();
        }

        // POST: PeriodoEvaluacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodPeriodoEvaluacion,Evaluacion,Periodo")] PeriodoEvaluacion periodoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodoEvaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre", periodoEvaluacion.Evaluacion);
            ViewData["Periodo"] = new SelectList(_context.Periodos, "CodPeriodo", "Nombre", periodoEvaluacion.Periodo);
            return View(periodoEvaluacion);
        }

        // GET: PeriodoEvaluacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoEvaluacion = await _context.PeriodosEvaluaciones.FindAsync(id);
            if (periodoEvaluacion == null)
            {
                return NotFound();
            }
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre", periodoEvaluacion.Evaluacion);
            ViewData["Periodo"] = new SelectList(_context.Periodos, "CodPeriodo", "Nombre", periodoEvaluacion.Periodo);
            return View(periodoEvaluacion);
        }

        // POST: PeriodoEvaluacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodPeriodoEvaluacion,Evaluacion,Periodo")] PeriodoEvaluacion periodoEvaluacion)
        {
            if (id != periodoEvaluacion.CodPeriodoEvaluacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodoEvaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoEvaluacionExists(periodoEvaluacion.CodPeriodoEvaluacion))
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
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre", periodoEvaluacion.Evaluacion);
            ViewData["Periodo"] = new SelectList(_context.Periodos, "CodPeriodo", "Nombre", periodoEvaluacion.Periodo);
            return View(periodoEvaluacion);
        }

        // GET: PeriodoEvaluacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoEvaluacion = await _context.PeriodosEvaluaciones
                .Include(p => p.EvaluacionFK)
                .Include(p => p.PeriodoFK)
                .FirstOrDefaultAsync(m => m.CodPeriodoEvaluacion == id);
            if (periodoEvaluacion == null)
            {
                return NotFound();
            }

            return View(periodoEvaluacion);
        }

        // POST: PeriodoEvaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periodoEvaluacion = await _context.PeriodosEvaluaciones.FindAsync(id);
            if (periodoEvaluacion != null)
            {
                _context.PeriodosEvaluaciones.Remove(periodoEvaluacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoEvaluacionExists(int id)
        {
            return _context.PeriodosEvaluaciones.Any(e => e.CodPeriodoEvaluacion == id);
        }
    }
}
