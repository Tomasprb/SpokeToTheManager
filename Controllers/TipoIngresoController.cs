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
    public class TipoIngresoController : Controller
    {
        private readonly UserContext _context;

        public TipoIngresoController(UserContext context)
        {
            _context = context;
        }

        // GET: TipoIngreso
        public async Task<IActionResult> Index()
        {
              return _context.tipo_ingresos != null ? 
                          View(await _context.tipo_ingresos.ToListAsync()) :
                          Problem("Entity set 'UserContext.tipo_ingresos'  is null.");
        }

        // GET: TipoIngreso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipo_ingresos == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.tipo_ingresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // GET: TipoIngreso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIngreso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] TipoIngreso tipoIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIngreso);
        }

        // GET: TipoIngreso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipo_ingresos == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.tipo_ingresos.FindAsync(id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }
            return View(tipoIngreso);
        }

        // POST: TipoIngreso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] TipoIngreso tipoIngreso)
        {
            if (id != tipoIngreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIngresoExists(tipoIngreso.Id))
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
            return View(tipoIngreso);
        }

        // GET: TipoIngreso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipo_ingresos == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.tipo_ingresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // POST: TipoIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tipo_ingresos == null)
            {
                return Problem("Entity set 'UserContext.tipo_ingresos'  is null.");
            }
            var tipoIngreso = await _context.tipo_ingresos.FindAsync(id);
            if (tipoIngreso != null)
            {
                _context.tipo_ingresos.Remove(tipoIngreso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIngresoExists(int id)
        {
          return (_context.tipo_ingresos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
