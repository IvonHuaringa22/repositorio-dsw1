using Newtonsoft.Json;
using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;
using System.Text;

namespace Proyecto_DSWI_GP3.Data
{
    public class IComprasRepositorio : ICompras
    {
        private readonly IConfiguration _config;

        public IComprasRepositorio(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<Compras> BuscarPorEvento(int idEvento)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = clienteHttp.GetAsync($"Compras/Evento/{idEvento}").Result;
                var data = respuesta.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Compras>>(data);
            }
        }

        public IEnumerable<Compras> BuscarPorUsuario(int idUsuario)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = clienteHttp.GetAsync($"Compras/Usuario/{idUsuario}").Result;
                var data = respuesta.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Compras>>(data);
            }
        }

        public bool Editar(Compras compra)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var contenido = new StringContent(JsonConvert.SerializeObject(compra), Encoding.UTF8, "application/json");
                var respuesta = clienteHttp.PutAsync("Compras", contenido).Result;
                return respuesta.IsSuccessStatusCode;
            }
        }

        public bool Eliminar(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = clienteHttp.DeleteAsync($"Compras/{id}").Result;
                return respuesta.IsSuccessStatusCode;
            }
        }

        public IEnumerable<Compras> Listar()
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = clienteHttp.GetAsync("Compras").Result;
                var data = respuesta.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Compras>>(data);
            }
        }

        public Compras ObtenerCompraPorId(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = clienteHttp.GetAsync($"Compras/{id}").Result;
                var data = respuesta.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Compras>(data);
            }
        }

        public bool Registrar(Compras compra)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var contenido = new StringContent(JsonConvert.SerializeObject(compra), Encoding.UTF8, "application/json");
                var respuesta = clienteHttp.PostAsync("Compras", contenido).Result;
                return respuesta.IsSuccessStatusCode;
            }
        }
    }
}
