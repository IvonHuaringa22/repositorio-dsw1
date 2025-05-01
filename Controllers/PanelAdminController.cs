using Microsoft.AspNetCore.Mvc;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class PanelAdminController : Controller
    {
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
