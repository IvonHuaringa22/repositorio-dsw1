using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class EventosController : Controller
    {

        IEventos repoEventos;

        public EventosController(IEventos eventosRepositorio)
        {
            repoEventos = eventosRepositorio;
        }

        // GET: Eventos


        public async Task<IActionResult> ListaEventosAdmin()
        {
            var eventos = await repoEventos.Listar();
            return View(eventos);
        }

        // POST: Eventos /Buscar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ListaEventosAdmin(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            if(searchString == null)
            {
                var eventos = await repoEventos.Listar();

                return View("ListaEventosAdmin", eventos);
            }
            else
            {
                var eventos = await repoEventos.BuscarPorNombre(searchString);
                return View("ListaEventosAdmin", eventos);
            }
        }

        // GET: Eventos/Details
        public async Task<IActionResult> DetalleEventoAdmin(int id)
        {
            var eventos = await repoEventos.ObtenerPorId(id);
            if (eventos == null)
            {
                return NotFound();
            }
            return View(eventos);
        }

        public IActionResult CrearEventoAdmin()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEventoAdmin(Eventos evento)
        {
            if (ModelState.IsValid)
            {
                await repoEventos.Registrar(evento);
                return RedirectToAction(nameof(ListaEventosAdmin));
            }
            return View(evento);
        }

        // GET: Eventos/Edit
        public async Task<IActionResult> EditEventoAdmin(int id)
        {
            var evento = await repoEventos.ObtenerPorId(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEventoAdmin(int id, Eventos evento)
        {
            if (id != evento.IdEvento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await repoEventos.Actualizar(evento);
                return RedirectToAction(nameof(DetalleEventoAdmin), new { id = evento.IdEvento });
            }
            return View(evento);
        }

        // GET: Eventos/Delete
        public async Task<IActionResult> EliminarEventoAdmin(int id)
        {
            var evento = await repoEventos.ObtenerPorId(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repoEventos.Eliminar(id);
            return RedirectToAction(nameof(ListaEventosAdmin));
        }
    }
}
