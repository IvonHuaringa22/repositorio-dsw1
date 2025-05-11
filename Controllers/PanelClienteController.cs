using System.Security.Policy;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_DSWI_GP3.Data;
using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class PanelClienteController : Controller
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;
        private readonly ICompras _repo;

        public PanelClienteController(IHttpClientFactory httpClientFactory, IConfiguration config, ICompras repo)
        {
            _http = httpClientFactory.CreateClient();
            _config = config;
            _repo = repo;
        }

        public async Task<IActionResult> Eventos()
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync("Eventos");
                var data = await respuesta.Content.ReadAsStringAsync();

                var eventos = JsonConvert.DeserializeObject<List<Eventos>>(data);

                // Pasar los datos a la vista
                return View(eventos);
            }
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Rol") != "Cliente")
                return RedirectToAction("Login", "Login");

            return View("PanelCliente");
        }

        public async Task<IActionResult> Detalle(int id)
        {
            Eventos? evento = null;
            List<Zonas>? zonas = null;

            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);

                // Obtener el evento
                var eventoResp = await clienteHttp.GetAsync($"Eventos/{id}");
                var eventoJson = await eventoResp.Content.ReadAsStringAsync();
                evento = JsonConvert.DeserializeObject<Eventos>(eventoJson);

                // Obtener zonas del evento
                var zonasResp = await clienteHttp.GetAsync($"Zonas/eventos/{id}");
                var zonasJson = await zonasResp.Content.ReadAsStringAsync();
                zonas = JsonConvert.DeserializeObject<List<Zonas>>(zonasJson);
            }

            // Validar zonas
            if (zonas == null || zonas.Count == 0)
            {
                TempData["Error"] = "No se encontraron zonas para este evento.";
            }

            var viewModel = new DetalleEventoViewModel
            {
                Eventos = evento,
                Zonas = zonas
            };

            return View("Detalle", viewModel);
        }
        private int ObtenerUsuarioActual()
        {
            return HttpContext.Session.GetInt32("IdUsuario") ?? 0;
        }

        [HttpPost]
        public IActionResult Comprar(int idEvento)
        {
            var idUsuario = ObtenerUsuarioActual();

            if (idUsuario == 0) // Verifica si el usuario ha iniciado sesión
                return RedirectToAction("Login", "LoginController");

            var compra = new Compras
            {
                IdUsuario = idUsuario,
                IdEvento = idEvento,
                MetodoPago = "Tarjeta", // Método de pago fijo
                EstadoPago = "Pendiente",
                IdZona = 1 // Zona predeterminada
            };

            var exito = _repo.Registrar(compra);

            if (exito)
            {
                TempData["CompraExitosa"] = "¡Compra realizada correctamente!";
                return RedirectToAction("Detalle", new { id = idEvento }); // Redirige de nuevo a la página del evento
            }

            TempData["CompraError"] = "Hubo un problema al procesar la compra.";
            return RedirectToAction("Detalle", new { id = idEvento }); // Redirige a la misma página con mensaje de error
        }




    }
}
