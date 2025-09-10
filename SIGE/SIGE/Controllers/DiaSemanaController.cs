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
    public class DiaSemanaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiaSemanaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiaSemana
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiasSemana.ToListAsync());
        }

        // GET: DiaSemana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiasSemana
                .FirstOrDefaultAsync(m => m.CodDiaSemana == id);
            if (diaSemana == null)
            {
                return NotFound();
            }

            return View(diaSemana);
        }

        // GET: DiaSemana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiaSemana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDiaSemana,Nombre,Nomenclatura")] DiaSemana diaSemana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaSemana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaSemana);
        }

        // GET: DiaSemana/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiasSemana.FindAsync(id);
            if (diaSemana == null)
            {
                return NotFound();
            }
            return View(diaSemana);
        }

        // POST: DiaSemana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodDiaSemana,Nombre,Nomenclatura")] DiaSemana diaSemana)
        {
            if (id != diaSemana.CodDiaSemana)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaSemana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaSemanaExists(diaSemana.CodDiaSemana))
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
            return View(diaSemana);
        }

        // GET: DiaSemana/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiasSemana
                .FirstOrDefaultAsync(m => m.CodDiaSemana == id);
            if (diaSemana == null)
            {
                return NotFound();
            }

            return View(diaSemana);
        }

        // POST: DiaSemana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaSemana = await _context.DiasSemana.FindAsync(id);
            if (diaSemana != null)
            {
                _context.DiasSemana.Remove(diaSemana);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaSemanaExists(int id)
        {
            return _context.DiasSemana.Any(e => e.CodDiaSemana == id);
        }
    }
}
