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
    public class RubroController : Controller
    {
        private readonly UserContext _context;

        public RubroController(UserContext context)
        {
            _context = context;
        }

        // GET: Rubro
        public async Task<IActionResult> Index()
        {
              return _context.rubros != null ? 
                          View(await _context.rubros.ToListAsync()) :
                          Problem("Entity set 'UserContext.rubros'  is null.");
        }

        // GET: Rubro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.rubros == null)
            {
                return NotFound();
            }

            var rubro = await _context.rubros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rubro == null)
            {
                return NotFound();
            }

            return View(rubro);
        }

        // GET: Rubro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rubro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Rubro rubro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rubro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rubro);
        }

        // GET: Rubro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.rubros == null)
            {
                return NotFound();
            }

            var rubro = await _context.rubros.FindAsync(id);
            if (rubro == null)
            {
                return NotFound();
            }
            return View(rubro);
        }

        // POST: Rubro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Rubro rubro)
        {
            if (id != rubro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rubro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RubroExists(rubro.Id))
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
            return View(rubro);
        }

        // GET: Rubro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.rubros == null)
            {
                return NotFound();
            }

            var rubro = await _context.rubros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rubro == null)
            {
                return NotFound();
            }

            return View(rubro);
        }

        // POST: Rubro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.rubros == null)
            {
                return Problem("Entity set 'UserContext.rubros'  is null.");
            }
            var rubro = await _context.rubros.FindAsync(id);
            if (rubro != null)
            {
                _context.rubros.Remove(rubro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RubroExists(int id)
        {
          return (_context.rubros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
