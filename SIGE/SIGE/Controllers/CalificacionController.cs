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
    public class CalificacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalificacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Calificacion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Calificaciones.Include(c => c.AsignacionFk).Include(c => c.EstudianteFk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Calificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificaciones
                .Include(c => c.AsignacionFk)
                .Include(c => c.EstudianteFk)
                .FirstOrDefaultAsync(m => m.CodCalificacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // GET: Calificacion/Create
        public IActionResult Create()
        {
            ViewData["Asignacion"] = new SelectList(_context.Asignaciones, "CodAsignacion", "CodAsignacion");
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1");
            return View();
        }

        // POST: Calificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCalificacion,Asignacion,Estudiante,Nota,FechaCalificacion,Observaciones")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Asignacion"] = new SelectList(_context.Asignaciones, "CodAsignacion", "CodAsignacion", calificacion.Asignacion);
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1", calificacion.Estudiante);
            return View(calificacion);
        }

        // GET: Calificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }
            ViewData["Asignacion"] = new SelectList(_context.Asignaciones, "CodAsignacion", "CodAsignacion", calificacion.Asignacion);
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1", calificacion.Estudiante);
            return View(calificacion);
        }

        // POST: Calificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodCalificacion,Asignacion,Estudiante,Nota,FechaCalificacion,Observaciones")] Calificacion calificacion)
        {
            if (id != calificacion.CodCalificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionExists(calificacion.CodCalificacion))
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
            ViewData["Asignacion"] = new SelectList(_context.Asignaciones, "CodAsignacion", "CodAsignacion", calificacion.Asignacion);
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1", calificacion.Estudiante);
            return View(calificacion);
        }

        // GET: Calificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificaciones
                .Include(c => c.AsignacionFk)
                .Include(c => c.EstudianteFk)
                .FirstOrDefaultAsync(m => m.CodCalificacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion != null)
            {
                _context.Calificaciones.Remove(calificacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificaciones.Any(e => e.CodCalificacion == id);
        }
    }
}
