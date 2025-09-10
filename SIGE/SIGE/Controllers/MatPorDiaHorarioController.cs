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
    public class MatPorDiaHorarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatPorDiaHorarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MatPorDiaHorario
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MatsPorDiaHorario.Include(m => m.AulaFK).Include(m => m.DiasHorarioFK).Include(m => m.HorasMateriaFK).Include(m => m.MateriaProfesorFK);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MatPorDiaHorario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matPorDiaHorario = await _context.MatsPorDiaHorario
                .Include(m => m.AulaFK)
                .Include(m => m.DiasHorarioFK)
                .Include(m => m.HorasMateriaFK)
                .Include(m => m.MateriaProfesorFK)
                .FirstOrDefaultAsync(m => m.CodMatPorDiaHorario == id);
            if (matPorDiaHorario == null)
            {
                return NotFound();
            }

            return View(matPorDiaHorario);
        }

        // GET: MatPorDiaHorario/Create
        public IActionResult Create()
        {
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula");
            ViewData["DiasHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar");
            ViewData["HorasMateria"] = new SelectList(_context.HorasMaterias, "CodHorasMateria", "CodHorasMateria");
            ViewData["MateriaProfesor"] = new SelectList(_context.MateriasProfesores, "CodMateriaProfesor", "Profesor");
            return View();
        }

        // POST: MatPorDiaHorario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodMatPorDiaHorario,MateriaProfesor,DiasHorario,HorasMateria,Aula")] MatPorDiaHorario matPorDiaHorario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matPorDiaHorario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula", matPorDiaHorario.Aula);
            ViewData["DiasHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar", matPorDiaHorario.DiasHorario);
            ViewData["HorasMateria"] = new SelectList(_context.HorasMaterias, "CodHorasMateria", "CodHorasMateria", matPorDiaHorario.HorasMateria);
            ViewData["MateriaProfesor"] = new SelectList(_context.MateriasProfesores, "CodMateriaProfesor", "Profesor", matPorDiaHorario.MateriaProfesor);
            return View(matPorDiaHorario);
        }

        // GET: MatPorDiaHorario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matPorDiaHorario = await _context.MatsPorDiaHorario.FindAsync(id);
            if (matPorDiaHorario == null)
            {
                return NotFound();
            }
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula", matPorDiaHorario.Aula);
            ViewData["DiasHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar", matPorDiaHorario.DiasHorario);
            ViewData["HorasMateria"] = new SelectList(_context.HorasMaterias, "CodHorasMateria", "CodHorasMateria", matPorDiaHorario.HorasMateria);
            ViewData["MateriaProfesor"] = new SelectList(_context.MateriasProfesores, "CodMateriaProfesor", "Profesor", matPorDiaHorario.MateriaProfesor);
            return View(matPorDiaHorario);
        }

        // POST: MatPorDiaHorario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodMatPorDiaHorario,MateriaProfesor,DiasHorario,HorasMateria,Aula")] MatPorDiaHorario matPorDiaHorario)
        {
            if (id != matPorDiaHorario.CodMatPorDiaHorario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matPorDiaHorario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatPorDiaHorarioExists(matPorDiaHorario.CodMatPorDiaHorario))
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
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula", matPorDiaHorario.Aula);
            ViewData["DiasHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar", matPorDiaHorario.DiasHorario);
            ViewData["HorasMateria"] = new SelectList(_context.HorasMaterias, "CodHorasMateria", "CodHorasMateria", matPorDiaHorario.HorasMateria);
            ViewData["MateriaProfesor"] = new SelectList(_context.MateriasProfesores, "CodMateriaProfesor", "Profesor", matPorDiaHorario.MateriaProfesor);
            return View(matPorDiaHorario);
        }

        // GET: MatPorDiaHorario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matPorDiaHorario = await _context.MatsPorDiaHorario
                .Include(m => m.AulaFK)
                .Include(m => m.DiasHorarioFK)
                .Include(m => m.HorasMateriaFK)
                .Include(m => m.MateriaProfesorFK)
                .FirstOrDefaultAsync(m => m.CodMatPorDiaHorario == id);
            if (matPorDiaHorario == null)
            {
                return NotFound();
            }

            return View(matPorDiaHorario);
        }

        // POST: MatPorDiaHorario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matPorDiaHorario = await _context.MatsPorDiaHorario.FindAsync(id);
            if (matPorDiaHorario != null)
            {
                _context.MatsPorDiaHorario.Remove(matPorDiaHorario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatPorDiaHorarioExists(int id)
        {
            return _context.MatsPorDiaHorario.Any(e => e.CodMatPorDiaHorario == id);
        }
    }
}
