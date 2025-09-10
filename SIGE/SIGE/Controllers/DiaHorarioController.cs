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
    public class DiaHorarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiaHorarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiaHorario
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DiasHorarios.Include(d => d.DiaSemanaFK).Include(d => d.GrupoFk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiaHorario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaHorario = await _context.DiasHorarios
                .Include(d => d.DiaSemanaFK)
                .Include(d => d.GrupoFk)
                .FirstOrDefaultAsync(m => m.CodDiaHorario == id);
            if (diaHorario == null)
            {
                return NotFound();
            }

            return View(diaHorario);
        }

        // GET: DiaHorario/Create
        public IActionResult Create()
        {
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre");
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado");
            return View();
        }

        // POST: DiaHorario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDiaHorario,TurnoEscolar,HoraInicio,HoraFin,DiaSemana,Grupo")] DiaHorario diaHorario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaHorario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre", diaHorario.DiaSemana);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", diaHorario.Grupo);
            return View(diaHorario);
        }

        // GET: DiaHorario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaHorario = await _context.DiasHorarios.FindAsync(id);
            if (diaHorario == null)
            {
                return NotFound();
            }
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre", diaHorario.DiaSemana);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", diaHorario.Grupo);
            return View(diaHorario);
        }

        // POST: DiaHorario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodDiaHorario,TurnoEscolar,HoraInicio,HoraFin,DiaSemana,Grupo")] DiaHorario diaHorario)
        {
            if (id != diaHorario.CodDiaHorario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaHorario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaHorarioExists(diaHorario.CodDiaHorario))
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
            ViewData["DiaSemana"] = new SelectList(_context.DiasSemana, "CodDiaSemana", "Nombre", diaHorario.DiaSemana);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodGrupo", "Grado", diaHorario.Grupo);
            return View(diaHorario);
        }

        // GET: DiaHorario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaHorario = await _context.DiasHorarios
                .Include(d => d.DiaSemanaFK)
                .Include(d => d.GrupoFk)
                .FirstOrDefaultAsync(m => m.CodDiaHorario == id);
            if (diaHorario == null)
            {
                return NotFound();
            }

            return View(diaHorario);
        }

        // POST: DiaHorario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaHorario = await _context.DiasHorarios.FindAsync(id);
            if (diaHorario != null)
            {
                _context.DiasHorarios.Remove(diaHorario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaHorarioExists(int id)
        {
            return _context.DiasHorarios.Any(e => e.CodDiaHorario == id);
        }
    }
}
