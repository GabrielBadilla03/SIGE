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
    public class AsistenciaEstudianteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaEstudianteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AsistenciaEstudiante
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AsistenciasEstudiantes.Include(a => a.AsistenciaFk).Include(a => a.EstudianteFk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AsistenciaEstudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaEstudiante = await _context.AsistenciasEstudiantes
                .Include(a => a.AsistenciaFk)
                .Include(a => a.EstudianteFk)
                .FirstOrDefaultAsync(m => m.CodAsistenciaEstudiante == id);
            if (asistenciaEstudiante == null)
            {
                return NotFound();
            }

            return View(asistenciaEstudiante);
        }

        // GET: AsistenciaEstudiante/Create
        public IActionResult Create()
        {
            ViewData["Asistencia"] = new SelectList(_context.Asistencias, "CodAsistencia", "CodAsistencia");
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1");
            return View();
        }

        // POST: AsistenciaEstudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAsistenciaEstudiante,Asistencia,Estudiante,Asistio")] AsistenciaEstudiante asistenciaEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistenciaEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Asistencia"] = new SelectList(_context.Asistencias, "CodAsistencia", "CodAsistencia", asistenciaEstudiante.Asistencia);
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1", asistenciaEstudiante.Estudiante);
            return View(asistenciaEstudiante);
        }

        // GET: AsistenciaEstudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaEstudiante = await _context.AsistenciasEstudiantes.FindAsync(id);
            if (asistenciaEstudiante == null)
            {
                return NotFound();
            }
            ViewData["Asistencia"] = new SelectList(_context.Asistencias, "CodAsistencia", "CodAsistencia", asistenciaEstudiante.Asistencia);
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1", asistenciaEstudiante.Estudiante);
            return View(asistenciaEstudiante);
        }

        // POST: AsistenciaEstudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAsistenciaEstudiante,Asistencia,Estudiante,Asistio")] AsistenciaEstudiante asistenciaEstudiante)
        {
            if (id != asistenciaEstudiante.CodAsistenciaEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistenciaEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaEstudianteExists(asistenciaEstudiante.CodAsistenciaEstudiante))
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
            ViewData["Asistencia"] = new SelectList(_context.Asistencias, "CodAsistencia", "CodAsistencia", asistenciaEstudiante.Asistencia);
            ViewData["Estudiante"] = new SelectList(_context.Estudiantes, "CodEstudiante", "Apellido1", asistenciaEstudiante.Estudiante);
            return View(asistenciaEstudiante);
        }

        // GET: AsistenciaEstudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaEstudiante = await _context.AsistenciasEstudiantes
                .Include(a => a.AsistenciaFk)
                .Include(a => a.EstudianteFk)
                .FirstOrDefaultAsync(m => m.CodAsistenciaEstudiante == id);
            if (asistenciaEstudiante == null)
            {
                return NotFound();
            }

            return View(asistenciaEstudiante);
        }

        // POST: AsistenciaEstudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistenciaEstudiante = await _context.AsistenciasEstudiantes.FindAsync(id);
            if (asistenciaEstudiante != null)
            {
                _context.AsistenciasEstudiantes.Remove(asistenciaEstudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaEstudianteExists(int id)
        {
            return _context.AsistenciasEstudiantes.Any(e => e.CodAsistenciaEstudiante == id);
        }
    }
}
