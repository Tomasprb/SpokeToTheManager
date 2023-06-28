using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpokeToTheManager.Models;

namespace SpokeToTheManager.Controllers
{
    public class EgresoController : Controller
    {
        private readonly UserContext _context;

        public EgresoController(UserContext context)
        {
            _context = context;
        }

        // GET: Egreso
        public async Task<IActionResult> Index()
        {
              return _context.egresos != null ? 
                          View(await _context.egresos.ToListAsync()) :
                          Problem("Entity set 'UserContext.egresos'  is null.");
        }

        // GET: Egreso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.egresos == null)
            {
                return NotFound();
            }

            var egreso = await _context.egresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // GET: Egreso/Create
        public async Task<IActionResult> Create()
        {
            var tipos = await _context.tipo_ingresos.ToListAsync();
            ViewBag.tipos = new SelectList(tipos, "descripcion", "descripcion");
            return View();
        }

        // POST: Egreso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,valor,acreditado,observaciones,tipo")] Egreso egreso)
        {
            if (ModelState.IsValid)
            {
                egreso.fecha = DateTime.Now.Date;
                _context.Add(egreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(egreso);
        }

        // GET: Egreso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.egresos == null)
            {
                return NotFound();
            }

            var egreso = await _context.egresos.FindAsync(id);
            var tipos = await _context.tipo_egresos.ToListAsync();
            ViewBag.egreso = egreso;
            ViewBag.tipos = tipos;
            if (egreso == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Egreso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,valor,acreditado,observaciones,tipo")] Egreso egreso)
        {
            if (id != egreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgresoExists(egreso.Id))
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
            return View(egreso);
        }

        // GET: Egreso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.egresos == null)
            {
                return NotFound();
            }

            var egreso = await _context.egresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // POST: Egreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.egresos == null)
            {
                return Problem("Entity set 'UserContext.egresos'  is null.");
            }
            var egreso = await _context.egresos.FindAsync(id);
            if (egreso != null)
            {
                _context.egresos.Remove(egreso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgresoExists(int id)
        {
          return (_context.egresos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
