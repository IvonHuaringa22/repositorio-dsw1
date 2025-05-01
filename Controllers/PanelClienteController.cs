using Microsoft.AspNetCore.Mvc;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class PanelClienteController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Rol") != "Cliente")
            {
                return RedirectToAction("Login", "Login");
            }
            return View("PanelCliente");
        }
    }
}
