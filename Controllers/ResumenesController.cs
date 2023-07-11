using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpokeToTheManager.Models;
using Microsoft.Extensions.Logging;

namespace SpokeToTheManager.Controllers
{
    public class ResumenesController : Controller
    {
        private readonly UserContext _context;
        private readonly ILogger<ResumenesController> _logger;

        public ResumenesController(UserContext context, ILogger<ResumenesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var mesAnterior = DateTime.Now.AddMonths(-1).Date;
            var hoy = DateTime.Now.Date;

            ViewBag.totalIngresos =  await getTotalIngresos(mesAnterior, hoy);
            ViewBag.totalEgresos =  await getTotalEgresos(mesAnterior, hoy);
            ViewBag.totalMes =  await getTotal(mesAnterior, hoy);
            ViewBag.mesAnterior = await getTotal(DateTime.Now.AddMonths(-2).Date, mesAnterior);
            ViewBag.diferencia = getDiferencia(ViewBag.mesAnterior,ViewBag.totalMes);
            ViewBag.porcentaje = getPorcentaje(ViewBag.mesAnterior,ViewBag.totalMes);

            ViewBag.usuarios = await _context.Usuarios.CountAsync();
            ViewBag.cantIngresos = await _context.ingresos.CountAsync();
            ViewBag.cantEgresos = await _context.egresos.CountAsync();
            ViewBag.ingMensual = await _context.ingresos.Where(i => i.fecha >= mesAnterior && i.fecha <= hoy).Where(i => i.acreditado == true).CountAsync();
            ViewBag.egMensual = await _context.egresos.Where(i => i.fecha >= mesAnterior && i.fecha <= hoy).Where(i => i.acreditado == true).CountAsync();
            ViewBag.recursos = await _context.recu.CountAsync();
            ViewBag.rubros = await _context.rubros.CountAsync();
            ViewBag.socios = await _context.socios.CountAsync();

            ResumenModel modelo = new ResumenModel
            {
                ingresos = await _context.ingresos.Where(e => e.fecha >= DateTime.Now.AddMonths(-2).Date && e.fecha <= hoy).ToListAsync(),
                egresos = await _context.egresos.Where(e => e.fecha >= DateTime.Now.AddMonths(-2).Date && e.fecha <= hoy).ToListAsync()
            };

            return View(modelo);
        }
        private  async Task<double> getTotal(DateTime fechaInicial, DateTime fechaFinal)
        {
            double totalIngresos =  await getTotalIngresos(fechaInicial, fechaFinal);
            double totalEgresos =  await getTotalEgresos(fechaInicial, fechaFinal);
            double totalMes =  totalIngresos -  totalEgresos;
            return totalMes;
        }
        private async Task<double> getTotalIngresos(DateTime fechaInicial, DateTime fechaFinal)
        {
            var totalIngresos = await _context.ingresos
                .Where(i => i.fecha >= fechaInicial && i.fecha <= fechaFinal).Where(i => i.acreditado == true)
                .SumAsync(i => i.valor);
            return totalIngresos;
        }
        private async Task<double> getTotalEgresos(DateTime fechaInicial, DateTime fechaFinal)
        {                
            var totalEgresos =  await _context.egresos
                .Where(e => e.fecha >= fechaInicial && e.fecha <= fechaFinal).Where(e => e.acreditado == true)
                .SumAsync(e => e.valor);
            return totalEgresos;
        }

        private double getDiferencia(double anterior, double actual)
        {
            return actual - anterior;
        }
        private double getPorcentaje(double anterior, double actual)
        {
            double porcentaje = 0;
            if (anterior == 0){return 0;}
            porcentaje = ((actual - anterior) / anterior) * 100;

            return Math.Round(porcentaje, 2);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}