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
            var eventos = await _eventosRepositorio.ListarEventos();
            return View(eventos);
        }

        // GET: Eventos/Details
        public async Task<IActionResult> Details(int id)
        {
            var eventos = await _eventosRepositorio.ObtenerEventoPorId(id);
            if (eventos == null)
            {
                return NotFound();
            }
            return View(eventos);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                await _eventosRepositorio.RegistrarEvento(eventos);
                return RedirectToAction(nameof(Index));
            }
            return View(eventos);
        }

        // GET: Eventos/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var eventos = await _eventosRepositorio.ObtenerEventoPorId(id);
            if (eventos == null)
            {
                return NotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Eventos eventos)
        {
            if (id != eventos.IdEvento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _eventosRepositorio.ActualizarEvento(eventos);
                return RedirectToAction(nameof(Index));
            }
            return View(eventos);
        }

        // GET: Eventos/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var eventos = await _eventosRepositorio.ObtenerEventoPorId(id);
            if (eventos == null)
            {
                return NotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventosRepositorio.EliminarEvento(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
