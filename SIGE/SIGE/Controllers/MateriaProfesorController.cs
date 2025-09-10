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
    public class MateriaProfesorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriaProfesorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MateriaProfesor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MateriasProfesores.Include(m => m.AulaFK).Include(m => m.MateriaFK).Include(m => m.ProfesorFK);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MateriaProfesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaProfesor = await _context.MateriasProfesores
                .Include(m => m.AulaFK)
                .Include(m => m.MateriaFK)
                .Include(m => m.ProfesorFK)
                .FirstOrDefaultAsync(m => m.CodMateriaProfesor == id);
            if (materiaProfesor == null)
            {
                return NotFound();
            }

            return View(materiaProfesor);
        }

        // GET: MateriaProfesor/Create
        public IActionResult Create()
        {
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula");
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria");
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: MateriaProfesor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodMateriaProfesor,Materia,Profesor,Aula")] MateriaProfesor materiaProfesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula", materiaProfesor.Aula);
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria", materiaProfesor.Materia);
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id", materiaProfesor.Profesor);
            return View(materiaProfesor);
        }

        // GET: MateriaProfesor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaProfesor = await _context.MateriasProfesores.FindAsync(id);
            if (materiaProfesor == null)
            {
                return NotFound();
            }
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula", materiaProfesor.Aula);
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria", materiaProfesor.Materia);
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id", materiaProfesor.Profesor);
            return View(materiaProfesor);
        }

        // POST: MateriaProfesor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodMateriaProfesor,Materia,Profesor,Aula")] MateriaProfesor materiaProfesor)
        {
            if (id != materiaProfesor.CodMateriaProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaProfesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaProfesorExists(materiaProfesor.CodMateriaProfesor))
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
            ViewData["Aula"] = new SelectList(_context.Aulas, "CodAula", "NomAula", materiaProfesor.Aula);
            ViewData["Materia"] = new SelectList(_context.Materias, "CodMateria", "NomMateria", materiaProfesor.Materia);
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id", materiaProfesor.Profesor);
            return View(materiaProfesor);
        }

        // GET: MateriaProfesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaProfesor = await _context.MateriasProfesores
                .Include(m => m.AulaFK)
                .Include(m => m.MateriaFK)
                .Include(m => m.ProfesorFK)
                .FirstOrDefaultAsync(m => m.CodMateriaProfesor == id);
            if (materiaProfesor == null)
            {
                return NotFound();
            }

            return View(materiaProfesor);
        }

        // POST: MateriaProfesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaProfesor = await _context.MateriasProfesores.FindAsync(id);
            if (materiaProfesor != null)
            {
                _context.MateriasProfesores.Remove(materiaProfesor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaProfesorExists(int id)
        {
            return _context.MateriasProfesores.Any(e => e.CodMateriaProfesor == id);
        }
    }
}
