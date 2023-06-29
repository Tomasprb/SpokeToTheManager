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
            ViewBag.porcentaje = getPorcentaje(ViewBag.mesAnterior,ViewBag.totalMes);
            
            return View();
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

        private double getPorcentaje(double anterior, double actual)
        {
            double porcentaje = 0;
            if (anterior == 0){return 0;}
            porcentaje = ((actual - anterior) / anterior) * 100;

            return porcentaje;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}