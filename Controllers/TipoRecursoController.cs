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
    public class TipoRecursoController : Controller
    {
        private readonly UserContext _context;

        public TipoRecursoController(UserContext context)
        {
            _context = context;
        }

        // GET: TipoRecurso
        public async Task<IActionResult> Index()
        {
              return _context.tipos_recursos != null ? 
                          View(await _context.tipos_recursos.ToListAsync()) :
                          Problem("Entity set 'UserContext.tipos_recursos'  is null.");
        }

        // GET: TipoRecurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipos_recursos == null)
            {
                return NotFound();
            }

            var tipoRecurso = await _context.tipos_recursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoRecurso == null)
            {
                return NotFound();
            }

            return View(tipoRecurso);
        }

        // GET: TipoRecurso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRecurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,descripcion")] TipoRecurso tipoRecurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRecurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRecurso);
        }

        // GET: TipoRecurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipos_recursos == null)
            {
                return NotFound();
            }

            var tipoRecurso = await _context.tipos_recursos.FindAsync(id);
            if (tipoRecurso == null)
            {
                return NotFound();
            }
            return View(tipoRecurso);
        }

        // POST: TipoRecurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,descripcion")] TipoRecurso tipoRecurso)
        {
            if (id != tipoRecurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRecurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRecursoExists(tipoRecurso.Id))
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
            return View(tipoRecurso);
        }

        // GET: TipoRecurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipos_recursos == null)
            {
                return NotFound();
            }

            var tipoRecurso = await _context.tipos_recursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoRecurso == null)
            {
                return NotFound();
            }

            return View(tipoRecurso);
        }

        // POST: TipoRecurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tipos_recursos == null)
            {
                return Problem("Entity set 'UserContext.tipos_recursos'  is null.");
            }
            var tipoRecurso = await _context.tipos_recursos.FindAsync(id);
            if (tipoRecurso != null)
            {
                _context.tipos_recursos.Remove(tipoRecurso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRecursoExists(int id)
        {
          return (_context.tipos_recursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
