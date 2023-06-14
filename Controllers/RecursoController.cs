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
    public class RecursoController : Controller
    {
        private readonly UserContext _context;

        public RecursoController(UserContext context)
        {
            _context = context;
        }

        // GET: Recurso
        public async Task<IActionResult> Index()
        {
              return _context.Recurso != null ? 
                          View(await _context.Recurso.ToListAsync()) :
                          Problem("Entity set 'UserContext.Recurso'  is null.");
        }

        // GET: Recurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recurso == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // GET: Recurso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Stock,ValorXUnidad")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Recurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recurso == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }
            return View(recurso);
        }

        // POST: Recurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Stock,ValorXUnidad")] Recurso recurso)
        {
            if (id != recurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursoExists(recurso.Id))
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
            return View(recurso);
        }

        // GET: Recurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recurso == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // POST: Recurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recurso == null)
            {
                return Problem("Entity set 'UserContext.Recurso'  is null.");
            }
            var recurso = await _context.Recurso.FindAsync(id);
            if (recurso != null)
            {
                _context.Recurso.Remove(recurso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursoExists(int id)
        {
          return (_context.Recurso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
