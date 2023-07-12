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
    public class IngresosController : Controller
    {
        private readonly UserContext _context;

        public IngresosController(UserContext context)
        {
            _context = context;
        }

        // GET: Ingresos
        public async Task<IActionResult> Index()
        {
            return _context.ingresos != null ? 
                          View(await _context.ingresos.ToListAsync()) :
                          Problem("Entity set 'UserContext.ingresos'  is null.");
        }

        // GET: Ingresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ingresos == null)
            {
                return NotFound();
            }

            var ingreso = await _context.ingresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

        // GET: Ingresos/Create
        public async Task<IActionResult> Create()
        {
           var tipos = await _context.tipo_ingresos.ToListAsync();
            ViewBag.tipos = new SelectList(tipos, "descripcion", "descripcion");
            return View();
           

        }


        // POST: Ingresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,valor,acreditado,observaciones,tipo,fecha")] Ingreso ingreso)
        {
          
            if (ModelState.IsValid)
            {
                if(ingreso.fecha==null)
                {
                    ingreso.fecha = DateTime.Now.Date;
                }
                _context.Add(ingreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var tipos = await _context.tipo_ingresos.ToListAsync();
            ViewBag.tipos = new SelectList(tipos, "descripcion", "descripcion");
            return View(ingreso);
        }

        // GET: Ingresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ingresos == null)
            {
                return NotFound();
            }

            var ingreso = await _context.ingresos.FindAsync(id);
            var tipos = await _context.tipo_ingresos.ToListAsync();
            ViewBag.tipos = new SelectList(tipos, "descripcion", "descripcion");
            ViewBag.ingreso = ingreso;
         
            if (ingreso == null)
            {
                return NotFound();
            }
            return View(ingreso);
        }

        // POST: Ingresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,valor,acreditado,observaciones,tipo")] Ingreso ingreso)
        {
            if (id != ingreso.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    var existente = _context.ingresos.Find(ingreso.Id);
                    if(existente != null)
                    {
                        existente.observaciones = ingreso.observaciones;
                        existente.acreditado = ingreso.acreditado;
                        existente.valor = ingreso.valor;
                        existente.tipo = ingreso.tipo;
                        existente.fecha = ingreso.fecha;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngresoExists(ingreso.Id))
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
            return View(ingreso);
        }

        // GET: Ingresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ingresos == null)
            {
                return NotFound();
            }

            var ingreso = await _context.ingresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ingresos == null)
            {
                return Problem("Entity set 'UserContext.ingresos'  is null.");
            }
            var ingreso = await _context.ingresos.FindAsync(id);
            if (ingreso != null)
            {
                _context.ingresos.Remove(ingreso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngresoExists(int id)
        {
          return (_context.ingresos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
