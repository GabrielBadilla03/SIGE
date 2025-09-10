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
    public class HorarioTiempoLibreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorarioTiempoLibreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HorarioTiempoLibre
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HorariosTiemposLibres.Include(h => h.DiaHorarioFK).Include(h => h.TiempoLibreFK);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HorarioTiempoLibre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioTiempoLibre = await _context.HorariosTiemposLibres
                .Include(h => h.DiaHorarioFK)
                .Include(h => h.TiempoLibreFK)
                .FirstOrDefaultAsync(m => m.CodHorarioTiempoLibre == id);
            if (horarioTiempoLibre == null)
            {
                return NotFound();
            }

            return View(horarioTiempoLibre);
        }

        // GET: HorarioTiempoLibre/Create
        public IActionResult Create()
        {
            ViewData["DiaHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar");
            ViewData["TiempoLibre"] = new SelectList(_context.TiemposLibres, "CodTiempoLibre", "Nombre");
            return View();
        }

        // POST: HorarioTiempoLibre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodHorarioTiempoLibre,DiaHorario,TiempoLibre")] HorarioTiempoLibre horarioTiempoLibre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horarioTiempoLibre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiaHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar", horarioTiempoLibre.DiaHorario);
            ViewData["TiempoLibre"] = new SelectList(_context.TiemposLibres, "CodTiempoLibre", "Nombre", horarioTiempoLibre.TiempoLibre);
            return View(horarioTiempoLibre);
        }

        // GET: HorarioTiempoLibre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioTiempoLibre = await _context.HorariosTiemposLibres.FindAsync(id);
            if (horarioTiempoLibre == null)
            {
                return NotFound();
            }
            ViewData["DiaHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar", horarioTiempoLibre.DiaHorario);
            ViewData["TiempoLibre"] = new SelectList(_context.TiemposLibres, "CodTiempoLibre", "Nombre", horarioTiempoLibre.TiempoLibre);
            return View(horarioTiempoLibre);
        }

        // POST: HorarioTiempoLibre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodHorarioTiempoLibre,DiaHorario,TiempoLibre")] HorarioTiempoLibre horarioTiempoLibre)
        {
            if (id != horarioTiempoLibre.CodHorarioTiempoLibre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horarioTiempoLibre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioTiempoLibreExists(horarioTiempoLibre.CodHorarioTiempoLibre))
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
            ViewData["DiaHorario"] = new SelectList(_context.DiasHorarios, "CodDiaHorario", "TurnoEscolar", horarioTiempoLibre.DiaHorario);
            ViewData["TiempoLibre"] = new SelectList(_context.TiemposLibres, "CodTiempoLibre", "Nombre", horarioTiempoLibre.TiempoLibre);
            return View(horarioTiempoLibre);
        }

        // GET: HorarioTiempoLibre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioTiempoLibre = await _context.HorariosTiemposLibres
                .Include(h => h.DiaHorarioFK)
                .Include(h => h.TiempoLibreFK)
                .FirstOrDefaultAsync(m => m.CodHorarioTiempoLibre == id);
            if (horarioTiempoLibre == null)
            {
                return NotFound();
            }

            return View(horarioTiempoLibre);
        }

        // POST: HorarioTiempoLibre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horarioTiempoLibre = await _context.HorariosTiemposLibres.FindAsync(id);
            if (horarioTiempoLibre != null)
            {
                _context.HorariosTiemposLibres.Remove(horarioTiempoLibre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioTiempoLibreExists(int id)
        {
            return _context.HorariosTiemposLibres.Any(e => e.CodHorarioTiempoLibre == id);
        }
    }
}
