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
    public class AsignacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsignacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asignacion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asignaciones.Include(a => a.ArchivosEvaluacionFk).Include(a => a.GrupoFk).Include(a => a.MateriaFK).Include(a => a.PerdioEvaluacionFK);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Asignacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.ArchivosEvaluacionFk)
                .Include(a => a.GrupoFk)
                .Include(a => a.MateriaFK)
                .Include(a => a.PerdioEvaluacionFK)
                .FirstOrDefaultAsync(m => m.CodAsignacion == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: Asignacion/Create
        public IActionResult Create()
        {
            ViewData["ArchivoEvaluacion"] = new SelectList(_context.ArchivosEvaluacion, "CodArchivosEvaluacion", "ContentType");
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado");
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria");
            ViewData["PeriodoEvaluacion"] = new SelectList(_context.PeriodosEvaluaciones, "CodPeriodoEvaluacion", "CodPeriodoEvaluacion");
            return View();
        }

        // POST: Asignacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAsignacion,PeriodoEvaluacion,Materia,Grupo,ArchivoEvaluacion,NumeroEvaluacion,FechaAsignacion,FechaConclusion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArchivoEvaluacion"] = new SelectList(_context.ArchivosEvaluacion, "CodArchivosEvaluacion", "ContentType", asignacion.ArchivoEvaluacion);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", asignacion.Grupo);
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria", asignacion.Materia);
            ViewData["PeriodoEvaluacion"] = new SelectList(_context.PeriodosEvaluaciones, "CodPeriodoEvaluacion", "CodPeriodoEvaluacion", asignacion.PeriodoEvaluacion);
            return View(asignacion);
        }

        // GET: Asignacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["ArchivoEvaluacion"] = new SelectList(_context.ArchivosEvaluacion, "CodArchivosEvaluacion", "ContentType", asignacion.ArchivoEvaluacion);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", asignacion.Grupo);
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria", asignacion.Materia);
            ViewData["PeriodoEvaluacion"] = new SelectList(_context.PeriodosEvaluaciones, "CodPeriodoEvaluacion", "CodPeriodoEvaluacion", asignacion.PeriodoEvaluacion);
            return View(asignacion);
        }

        // POST: Asignacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAsignacion,PeriodoEvaluacion,Materia,Grupo,ArchivoEvaluacion,NumeroEvaluacion,FechaAsignacion,FechaConclusion")] Asignacion asignacion)
        {
            if (id != asignacion.CodAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.CodAsignacion))
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
            ViewData["ArchivoEvaluacion"] = new SelectList(_context.ArchivosEvaluacion, "CodArchivosEvaluacion", "ContentType", asignacion.ArchivoEvaluacion);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", asignacion.Grupo);
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria", asignacion.Materia);
            ViewData["PeriodoEvaluacion"] = new SelectList(_context.PeriodosEvaluaciones, "CodPeriodoEvaluacion", "CodPeriodoEvaluacion", asignacion.PeriodoEvaluacion);
            return View(asignacion);
        }

        // GET: Asignacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.ArchivosEvaluacionFk)
                .Include(a => a.GrupoFk)
                .Include(a => a.MateriaFK)
                .Include(a => a.PerdioEvaluacionFK)
                .FirstOrDefaultAsync(m => m.CodAsignacion == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignaciones.Any(e => e.CodAsignacion == id);
        }
    }
}
