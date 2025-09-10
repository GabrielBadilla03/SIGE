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
    public class TiempoLibreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiempoLibreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiempoLibre
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiemposLibres.ToListAsync());
        }

        // GET: TiempoLibre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiempoLibre = await _context.TiemposLibres
                .FirstOrDefaultAsync(m => m.CodTiempoLibre == id);
            if (tiempoLibre == null)
            {
                return NotFound();
            }

            return View(tiempoLibre);
        }

        // GET: TiempoLibre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiempoLibre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTiempoLibre,Nombre,HoraInicio,HoraFin")] TiempoLibre tiempoLibre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiempoLibre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiempoLibre);
        }

        // GET: TiempoLibre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiempoLibre = await _context.TiemposLibres.FindAsync(id);
            if (tiempoLibre == null)
            {
                return NotFound();
            }
            return View(tiempoLibre);
        }

        // POST: TiempoLibre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodTiempoLibre,Nombre,HoraInicio,HoraFin")] TiempoLibre tiempoLibre)
        {
            if (id != tiempoLibre.CodTiempoLibre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiempoLibre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiempoLibreExists(tiempoLibre.CodTiempoLibre))
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
            return View(tiempoLibre);
        }

        // GET: TiempoLibre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiempoLibre = await _context.TiemposLibres
                .FirstOrDefaultAsync(m => m.CodTiempoLibre == id);
            if (tiempoLibre == null)
            {
                return NotFound();
            }

            return View(tiempoLibre);
        }

        // POST: TiempoLibre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiempoLibre = await _context.TiemposLibres.FindAsync(id);
            if (tiempoLibre != null)
            {
                _context.TiemposLibres.Remove(tiempoLibre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiempoLibreExists(int id)
        {
            return _context.TiemposLibres.Any(e => e.CodTiempoLibre == id);
        }
    }
}
