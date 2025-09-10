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
    public class EvaluacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvaluacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evaluacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evaluaciones.ToListAsync());
        }

        // GET: Evaluacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluaciones
                .FirstOrDefaultAsync(m => m.CodEvaluacion == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // GET: Evaluacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evaluacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEvaluacion,Nombre,Valor")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluacion);
        }

        // GET: Evaluacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEvaluacion,Nombre,Valor")] Evaluacion evaluacion)
        {
            if (id != evaluacion.CodEvaluacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionExists(evaluacion.CodEvaluacion))
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
            return View(evaluacion);
        }

        // GET: Evaluacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluaciones
                .FirstOrDefaultAsync(m => m.CodEvaluacion == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // POST: Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion != null)
            {
                _context.Evaluaciones.Remove(evaluacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionExists(int id)
        {
            return _context.Evaluaciones.Any(e => e.CodEvaluacion == id);
        }
    }
}
