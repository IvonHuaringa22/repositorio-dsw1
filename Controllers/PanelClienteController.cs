using Microsoft.AspNetCore.Mvc;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class PanelClienteController : Controller
    {
        public IActionResult Index()
        {
            return View("PanelCliente");
        }
    }
}
