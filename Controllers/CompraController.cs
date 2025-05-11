using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_GP3.Data.Contrato;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class CompraController : Controller
    {

        ICompras repoCompras;

        public CompraController(ICompras repoCompras)
        {
            this.repoCompras = repoCompras;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListaComprasAdmin()
        {
            var eventos = await repoCompras.ListarCompras();
            return View(eventos);
        }
    }
}
