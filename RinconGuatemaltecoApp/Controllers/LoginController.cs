using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RinconGuatemaltecoApp.Data;
using RinconGuatemaltecoApp.Models;
using System.Linq;

namespace RinconGuatemaltecoApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly RinconGuatemaltecoContext _context;

        public LoginController(RinconGuatemaltecoContext context)
        {
            _context = context;
        }

        // Acción para mostrar el formulario de login
        public IActionResult Index()
        {
            return View();
        }

        // Acción para procesar el login
        [HttpPost]
        public IActionResult Index(string NombreUsuario, string Contraseña)
        {
            var usuario = _context.Set<Usuario>().FirstOrDefault(u =>
                u.NombreUsuario == NombreUsuario && u.Contraseña == Contraseña);

            if (usuario != null)
            {
                // Iniciar sesión (puedes usar cookies o sesiones)
                TempData["Usuario"] = usuario.NombreUsuario; // Solo como ejemplo
                return RedirectToAction("Index", "Home"); // Redirige a Home 
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        // Acción para cerrar sesión
        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }
    }
}
