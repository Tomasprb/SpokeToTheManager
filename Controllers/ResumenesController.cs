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
            var startDate = DateTime.Now.AddMonths(-1).Date;
            var endDate = DateTime.Now.Date;
            var totalIngresos = await _context.ingresos
                .Where(i => i.fecha >= startDate && i.fecha <= endDate).Where(i=>i.acreditado==true)
                .SumAsync(i => i.valor);

            var totalEgresos = await _context.egresos
                .Where(e => e.fecha >= startDate && e.fecha <= endDate).Where(e=>e.acreditado==true)
                .SumAsync(e => e.valor);
            var totalMes = totalIngresos - totalEgresos;
            ViewBag.totalIngresos = totalIngresos;
            ViewBag.totalEgresos = totalEgresos;
            ViewBag.totalMes = totalMes;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}