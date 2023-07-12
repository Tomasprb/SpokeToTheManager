using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SpokeToTheManager.Models;


namespace SpokeToTheManager.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ILogger<AccesoController> _logger;
        private readonly UserContext _context;

        public AccesoController(ILogger<AccesoController> logger,UserContext context)
        {
            _logger = logger;
            _context = context;
            
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if(claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var existente = _context.Usuarios.FirstOrDefault(u => u.Email == user.Email);
            if (existente != null && existente.Contrasenia == user.Contrasenia)
            {
                List<Claim> claims = new List<Claim>(){
                    new Claim(ClaimTypes.NameIdentifier,user.Email),
                    new Claim("OtherProperties","Example Role")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties(){
                    AllowRefresh = true,
                    IsPersistent = user.mantenerLoggeado
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),properties);
                return RedirectToAction("Index","Home");
            }
            ViewData["ValidacionMensaje"] = "Usuario no encontrado";
            return PartialView(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return PartialView("Error!");
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(User user) { 
            if (ModelState.IsValid) {
                _context.Add(user);
                await _context.SaveChangesAsync();
                await this.Login(user);
                return RedirectToAction("Index","Home");
            }
            return View(user);
        }
        public IActionResult Registrar()
        {
            return PartialView();
        }
    }
}