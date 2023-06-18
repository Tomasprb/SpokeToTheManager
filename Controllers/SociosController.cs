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
    public class SociosController : Controller
    {
        private readonly UserContext _context;

        public SociosController(UserContext context)
        {
            _context = context;
        }

        // GET: Socios
        public async Task<IActionResult> Index()
        {
            var userContext = _context.socios.Include(s => s.rubro);
            return View(await userContext.ToListAsync());
        }

        // GET: Socios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.socios == null)
            {
                return NotFound();
            }

            var socio = await _context.socios
                .Include(s => s.rubro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            ViewData["RubroId"] = new SelectList(_context.rubros, "Id", "Nombre");
            return View();
        }

        // POST: Socios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Telefono,RubroId")] Socio socio)
        {
            _context.Add(socio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.socios == null)
            {
                return NotFound();
            }

            var socio = await _context.socios.FindAsync(id);
            if (socio == null)
            {
                return NotFound();
            }
            ViewData["RubroId"] = new SelectList(_context.rubros, "Id", "Id", socio.RubroId);
            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Telefono,RubroId")] Socio socio)
        {
            if (id != socio.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(socio);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocioExists(socio.Id))
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

        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.socios == null)
            {
                return NotFound();
            }

            var socio = await _context.socios
                .Include(s => s.rubro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.socios == null)
            {
                return Problem("Entity set 'UserContext.socios'  is null.");
            }
            var socio = await _context.socios.FindAsync(id);
            if (socio != null)
            {
                _context.socios.Remove(socio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocioExists(int id)
        {
            return (_context.socios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
