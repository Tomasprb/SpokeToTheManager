using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpokeToTheManager.Models;
using System.Diagnostics;

namespace SpokeToTheManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;

        public HomeController(ILogger<HomeController> logger , UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
   
        public IActionResult Login(string email, string password)
        {
           
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Contrasenia == password);

            if (user != null)
            {
                
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Las credenciales proporcionadas no son válidas.");
                return View();
            }
        }

        public IActionResult RegistroUsuario()
        {
            return PartialView();
        }
        public IActionResult ingresoesController()
        {
            return PartialView();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}