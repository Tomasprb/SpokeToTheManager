using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpokeToTheManager.Models;

namespace SpokeToTheManager.Controllers
{
    public class RecursoController : Controller
    {
        private readonly UserContext _context;
        private readonly ILogger<RecursoController> _logger;

        public RecursoController(UserContext context,ILogger<RecursoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Recurso
        public async Task<IActionResult> Index()
        {
            var userContext = _context.recu.Include(s => s.Socio);
            return View(await userContext.ToListAsync());
        }

        // GET: Recurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.recu == null)
            {
                return NotFound();
            }

            var recurso = await _context.recu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // GET: Recurso/Create
       
        public async Task<IActionResult> Create()
        {
            var tipos = await _context.tipos_recursos.ToListAsync();
            ViewBag.tipos = new SelectList(tipos, "descripcion", "descripcion");
            ViewBag.socios = new SelectList(_context.socios, "Id", "Nombre");
            return View();
        }

        // POST: Recurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,tipo,stock,valor_unidad,SocioId")] Recurso recurso)
        {
            
            if (ModelState.IsValid)
            {
                bool isChecked = Request.Form.ContainsKey("IsChecked") && Request.Form["IsChecked"] == "on";
                if(isChecked)
                {
                    Egreso e = new Egreso();
                    e.valor = (recurso.stock * recurso.valor_unidad);
                    e.acreditado = true;
                    e.tipo = "egreso autogenerado";
                    e.observaciones = "Egreso generado con el recurso: "+ recurso.nombre;
                    e.fecha = DateTime.Now.Date;
                    _context.Add(e);
                }
                _context.Add(recurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                // Log or inspect validation errors
                var errors = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage);
                foreach(var er in errors)
                {
                    _logger.LogError(er);
                }
            }
            var tipos = await _context.tipos_recursos.ToListAsync();
            ViewBag.tipos = new SelectList(tipos, "descripcion", "descripcion");
            ViewBag.socios = new SelectList(_context.socios, "Id", "Nombre");
            return View(recurso);
        }

        // GET: Recurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.recu == null)
            {
                return NotFound();
            }

            var recurso = await _context.recu.FindAsync(id);
            var tipos = await _context.tipos_recursos.ToListAsync();
            ViewBag.tipos = new SelectList(tipos, "descripcion", "descripcion");
            ViewBag.socios = new SelectList(_context.socios, "Id", "Nombre");
            ViewBag.recurso = recurso;

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,tipo,stock,valor_unidad,SocioId")] Recurso recurso)
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
            if (id == null || _context.recu == null)
            {
                return NotFound();
            }

            var recurso = await _context.recu
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
            if (_context.recu == null)
            {
                return Problem("Entity set 'UserContext.recu'  is null.");
            }
            var recurso = await _context.recu.FindAsync(id);
            if (recurso != null)
            {
                _context.recu.Remove(recurso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursoExists(int id)
        {
          return (_context.recu?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
