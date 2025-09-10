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
    public class ArchivoEvaluacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArchivoEvaluacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArchivoEvaluacion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ArchivosEvaluacion.Include(a => a.EvaluacionFK).Include(a => a.ProfesorFK);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ArchivoEvaluacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivoEvaluacion = await _context.ArchivosEvaluacion
                .Include(a => a.EvaluacionFK)
                .Include(a => a.ProfesorFK)
                .FirstOrDefaultAsync(m => m.CodArchivosEvaluacion == id);
            if (archivoEvaluacion == null)
            {
                return NotFound();
            }

            return View(archivoEvaluacion);
        }

        // GET: ArchivoEvaluacion/Create
        public IActionResult Create()
        {
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre");
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ArchivoEvaluacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodArchivosEvaluacion,Profesor,Evaluacion,Grado,RutaRelativa,NombreOriginal,ContentType,TamanoBytes")] ArchivoEvaluacion archivoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archivoEvaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre", archivoEvaluacion.Evaluacion);
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id", archivoEvaluacion.Profesor);
            return View(archivoEvaluacion);
        }

        // GET: ArchivoEvaluacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivoEvaluacion = await _context.ArchivosEvaluacion.FindAsync(id);
            if (archivoEvaluacion == null)
            {
                return NotFound();
            }
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre", archivoEvaluacion.Evaluacion);
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id", archivoEvaluacion.Profesor);
            return View(archivoEvaluacion);
        }

        // POST: ArchivoEvaluacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodArchivosEvaluacion,Profesor,Evaluacion,Grado,RutaRelativa,NombreOriginal,ContentType,TamanoBytes")] ArchivoEvaluacion archivoEvaluacion)
        {
            if (id != archivoEvaluacion.CodArchivosEvaluacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archivoEvaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchivoEvaluacionExists(archivoEvaluacion.CodArchivosEvaluacion))
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
            ViewData["Evaluacion"] = new SelectList(_context.Evaluaciones, "CodEvaluacion", "Nombre", archivoEvaluacion.Evaluacion);
            ViewData["Profesor"] = new SelectList(_context.Users, "Id", "Id", archivoEvaluacion.Profesor);
            return View(archivoEvaluacion);
        }

        // GET: ArchivoEvaluacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivoEvaluacion = await _context.ArchivosEvaluacion
                .Include(a => a.EvaluacionFK)
                .Include(a => a.ProfesorFK)
                .FirstOrDefaultAsync(m => m.CodArchivosEvaluacion == id);
            if (archivoEvaluacion == null)
            {
                return NotFound();
            }

            return View(archivoEvaluacion);
        }

        // POST: ArchivoEvaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archivoEvaluacion = await _context.ArchivosEvaluacion.FindAsync(id);
            if (archivoEvaluacion != null)
            {
                _context.ArchivosEvaluacion.Remove(archivoEvaluacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchivoEvaluacionExists(int id)
        {
            return _context.ArchivosEvaluacion.Any(e => e.CodArchivosEvaluacion == id);
        }
    }
}
