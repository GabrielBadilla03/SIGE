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
    public class HorasMateriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorasMateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HorasMateria
        public async Task<IActionResult> Index()
        {
            return View(await _context.HorasMaterias.ToListAsync());
        }

        // GET: HorasMateria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasMateria = await _context.HorasMaterias
                .FirstOrDefaultAsync(m => m.CodHorasMateria == id);
            if (horasMateria == null)
            {
                return NotFound();
            }

            return View(horasMateria);
        }

        // GET: HorasMateria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HorasMateria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodHorasMateria,HoraInicio,HoraFin")] HorasMateria horasMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horasMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horasMateria);
        }

        // GET: HorasMateria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasMateria = await _context.HorasMaterias.FindAsync(id);
            if (horasMateria == null)
            {
                return NotFound();
            }
            return View(horasMateria);
        }

        // POST: HorasMateria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodHorasMateria,HoraInicio,HoraFin")] HorasMateria horasMateria)
        {
            if (id != horasMateria.CodHorasMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horasMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorasMateriaExists(horasMateria.CodHorasMateria))
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
            return View(horasMateria);
        }

        // GET: HorasMateria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasMateria = await _context.HorasMaterias
                .FirstOrDefaultAsync(m => m.CodHorasMateria == id);
            if (horasMateria == null)
            {
                return NotFound();
            }

            return View(horasMateria);
        }

        // POST: HorasMateria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horasMateria = await _context.HorasMaterias.FindAsync(id);
            if (horasMateria != null)
            {
                _context.HorasMaterias.Remove(horasMateria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorasMateriaExists(int id)
        {
            return _context.HorasMaterias.Any(e => e.CodHorasMateria == id);
        }
    }
}
