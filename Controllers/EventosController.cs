using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;
using System.Threading.Tasks;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventos _eventosRepositorio;

        public EventosController(IEventos eventosRepositorio)
        {
            _eventosRepositorio = eventosRepositorio;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            var eventos = await _eventosRepositorio.Listar();
            return View(eventos);
        }
    }
}
