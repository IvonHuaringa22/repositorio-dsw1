using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Proyecto_DSWI_GP3.Data
{
    public class EventosRepositorio : IEventos
    {
        private readonly IConfiguration _config;
        public EventosRepositorio(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<Eventos>> Listar()
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync("Eventos");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Eventos>>(data);
            }
        }

        public async Task<List<Eventos>> BuscarPorNombre(string nombre)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync($"Eventos/buscar?nombre={nombre}");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Eventos>>(data);
            }
        }

        public async Task<bool> Registrar(Eventos eventos)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);

                var contenido = new StringContent(JsonConvert.SerializeObject(eventos),System.Text.Encoding.UTF8,"application/json");
                var respuesta = await clienteHttp.PostAsync("Eventos", contenido);
                var data = await respuesta.Content.ReadAsStringAsync();

                return bool.TryParse(data, out bool resultado) && resultado;
            }
        }
        public async Task<bool> Actualizar(Eventos eventos)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var contenido = new StringContent(JsonConvert.SerializeObject(eventos), System.Text.Encoding.UTF8, "application/json");
                var respuesta = await clienteHttp.PutAsync("Eventos", contenido);
                var data = await respuesta.Content.ReadAsStringAsync();
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
        public async Task<bool> Eliminar(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.DeleteAsync($"Eventos/{id}");
                return respuesta.IsSuccessStatusCode;
            }
        }
        public async Task<Eventos> ObtenerPorId(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync($"Eventos/{id}");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Eventos>(data);
            }
        }
    }
}
