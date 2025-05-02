using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class PanelClienteController : Controller
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public PanelClienteController(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _http = httpClientFactory.CreateClient();
            _config = config;
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
    }
}
