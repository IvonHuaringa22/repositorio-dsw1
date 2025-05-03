using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Proyecto_DSWI_GP3.Models;
using System.Text;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IConfiguration _config;
        public ClientesController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario == null)
            {
                return RedirectToAction("Login", "Cuenta");
            }

            PerfilClienteViewModel perfil = new();

            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(_config["Services:url"]);

                // Obtener cliente por IdUsuario
                var resp = await http.GetAsync($"Clientes/usuario/{idUsuario}");
                if (!resp.IsSuccessStatusCode)
                {
                    TempData["Error"] = "No se pudo obtener los datos del perfil.";
                    return View(perfil);
                }

                var json = await resp.Content.ReadAsStringAsync();
                perfil = JsonConvert.DeserializeObject<PerfilClienteViewModel>(json);

                perfil.Correo = perfil.Usuarios.Correo;
            }

            return View("Perfil", perfil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarPerfil(PerfilClienteViewModel perfil)
        {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(_config["Services:url"]);
                    var contenido = new StringContent(JsonConvert.SerializeObject(perfil), Encoding.UTF8, "application/json");
                    var respuesta = await http.PutAsync($"Clientes/actualizar/{perfil.IdCliente}", contenido);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        TempData["Success"] = "Tu perfil ha sido actualizado correctamente.";
                    // return RedirectToAction(nameof(Perfil));}
                    return RedirectToAction("Index", "PanelCliente");
                }
                    else
                    {
                        TempData["Error"] = "No se pudo actualizar el perfil. Intenta nuevamente.";
                    }
                }
            return View(perfil);
        }

    }

}
