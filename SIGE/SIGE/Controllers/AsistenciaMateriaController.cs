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
    public class AsistenciaMateriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaMateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AsistenciaMateria
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AsistenciasMaterias.Include(a => a.AsistenciaEstudianteFk).Include(a => a.MatPorDiaHorarioFK);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AsistenciaMateria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaMateria = await _context.AsistenciasMaterias
                .Include(a => a.AsistenciaEstudianteFk)
                .Include(a => a.MatPorDiaHorarioFK)
                .FirstOrDefaultAsync(m => m.CodAsistenciaMateria == id);
            if (asistenciaMateria == null)
            {
                return NotFound();
            }

            return View(asistenciaMateria);
        }

        // GET: AsistenciaMateria/Create
        public IActionResult Create()
        {
            ViewData["AsistenciaEstudiante"] = new SelectList(_context.AsistenciasEstudiantes, "CodAsistenciaEstudiante", "CodAsistenciaEstudiante");
            ViewData["MatPorDiaHorario"] = new SelectList(_context.MatsPorDiaHorario, "CodMatPorDiaHorario", "CodMatPorDiaHorario");
            return View();
        }

        // POST: AsistenciaMateria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAsistenciaMateria,MatPorDiaHorario,AsistenciaEstudiante,Asistio")] AsistenciaMateria asistenciaMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistenciaMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsistenciaEstudiante"] = new SelectList(_context.AsistenciasEstudiantes, "CodAsistenciaEstudiante", "CodAsistenciaEstudiante", asistenciaMateria.AsistenciaEstudiante);
            ViewData["MatPorDiaHorario"] = new SelectList(_context.MatsPorDiaHorario, "CodMatPorDiaHorario", "CodMatPorDiaHorario", asistenciaMateria.MatPorDiaHorario);
            return View(asistenciaMateria);
        }

        // GET: AsistenciaMateria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaMateria = await _context.AsistenciasMaterias.FindAsync(id);
            if (asistenciaMateria == null)
            {
                return NotFound();
            }
            ViewData["AsistenciaEstudiante"] = new SelectList(_context.AsistenciasEstudiantes, "CodAsistenciaEstudiante", "CodAsistenciaEstudiante", asistenciaMateria.AsistenciaEstudiante);
            ViewData["MatPorDiaHorario"] = new SelectList(_context.MatsPorDiaHorario, "CodMatPorDiaHorario", "CodMatPorDiaHorario", asistenciaMateria.MatPorDiaHorario);
            return View(asistenciaMateria);
        }

        // POST: AsistenciaMateria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAsistenciaMateria,MatPorDiaHorario,AsistenciaEstudiante,Asistio")] AsistenciaMateria asistenciaMateria)
        {
            if (id != asistenciaMateria.CodAsistenciaMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistenciaMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaMateriaExists(asistenciaMateria.CodAsistenciaMateria))
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
            ViewData["AsistenciaEstudiante"] = new SelectList(_context.AsistenciasEstudiantes, "CodAsistenciaEstudiante", "CodAsistenciaEstudiante", asistenciaMateria.AsistenciaEstudiante);
            ViewData["MatPorDiaHorario"] = new SelectList(_context.MatsPorDiaHorario, "CodMatPorDiaHorario", "CodMatPorDiaHorario", asistenciaMateria.MatPorDiaHorario);
            return View(asistenciaMateria);
        }

        // GET: AsistenciaMateria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaMateria = await _context.AsistenciasMaterias
                .Include(a => a.AsistenciaEstudianteFk)
                .Include(a => a.MatPorDiaHorarioFK)
                .FirstOrDefaultAsync(m => m.CodAsistenciaMateria == id);
            if (asistenciaMateria == null)
            {
                return NotFound();
            }

            return View(asistenciaMateria);
        }

        // POST: AsistenciaMateria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistenciaMateria = await _context.AsistenciasMaterias.FindAsync(id);
            if (asistenciaMateria != null)
            {
                _context.AsistenciasMaterias.Remove(asistenciaMateria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaMateriaExists(int id)
        {
            return _context.AsistenciasMaterias.Any(e => e.CodAsistenciaMateria == id);
        }
    }
}
