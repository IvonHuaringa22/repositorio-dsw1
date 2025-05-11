using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_GP3.Data.Contrato;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class TicketController : Controller
    {
        ITickets repoTickets;

        public TicketController(ITickets repoTickets)
        {
            this.repoTickets = repoTickets;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaTickets()
        {
            var tickets = await repoTickets.ListarTickets();
            return View(tickets);
        }
        [HttpPost]
        public async Task<IActionResult> ListaTickets(int idCompra)
        {
            var tickets = await repoTickets.ObtenerTicketPorCompra(idCompra);
            return View(tickets);
        }
        public async Task<IActionResult> TicketsPorId(int id)
        {
            var tickets = await repoTickets.ObtenerTicketPorId(id);
            return View(tickets);
        }
        public async Task<IActionResult> Eliminar(int idCompra)
        {
            await repoTickets.EliminarTicket(idCompra);

            return RedirectToAction(nameof(ListaTickets));
        }
    }
}
