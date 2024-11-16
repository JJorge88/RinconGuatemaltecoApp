using Microsoft.AspNetCore.Mvc;

namespace RinconGuatemaltecoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (TempData["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
