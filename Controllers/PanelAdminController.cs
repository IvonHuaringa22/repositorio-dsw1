using Microsoft.AspNetCore.Mvc;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class PanelAdminController : Controller
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Rol") != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }
            return View("PanelAdmin");
        }


    }
}
