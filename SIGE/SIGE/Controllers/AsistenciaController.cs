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
    public class AsistenciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asistencia
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asistencias.Include(a => a.DiaSemanaFK).Include(a => a.GrupoFk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Asistencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias
                .Include(a => a.DiaSemanaFK)
                .Include(a => a.GrupoFk)
                .FirstOrDefaultAsync(m => m.CodAsistencia == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // GET: Asistencia/Create
        public IActionResult Create()
        {
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre");
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado");
            return View();
        }

        // POST: Asistencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAsistencia,Grupo,FechaAsistencia,DiaSemana")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre", asistencia.DiaSemana);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", asistencia.Grupo);
            return View(asistencia);
        }

        // GET: Asistencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre", asistencia.DiaSemana);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", asistencia.Grupo);
            return View(asistencia);
        }

        // POST: Asistencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAsistencia,Grupo,FechaAsistencia,DiaSemana")] Asistencia asistencia)
        {
            if (id != asistencia.CodAsistencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaExists(asistencia.CodAsistencia))
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
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre", asistencia.DiaSemana);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", asistencia.Grupo);
            return View(asistencia);
        }

        // GET: Asistencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias
                .Include(a => a.DiaSemanaFK)
                .Include(a => a.GrupoFk)
                .FirstOrDefaultAsync(m => m.CodAsistencia == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // POST: Asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia != null)
            {
                _context.Asistencias.Remove(asistencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaExists(int id)
        {
            return _context.Asistencias.Any(e => e.CodAsistencia == id);
        }
    }
}
