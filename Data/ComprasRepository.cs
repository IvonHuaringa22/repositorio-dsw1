using System.Text;
using Newtonsoft.Json;
using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data
{
    public class ComprasRepository : ICompras
    {
        private readonly IConfiguration _config;
        public ComprasRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<Compras>> ListarCompras()
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync("Compras");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Compras>>(data);
            }
        }
        public Task<Compras> ObtenerCompraPorId(int id)
        {
            throw new NotImplementedException();
        }
        public bool RegistrarCompra(Compras compra)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var contenido = new StringContent(JsonConvert.SerializeObject(compra), Encoding.UTF8, "application/json");
                var respuesta = clienteHttp.PostAsync("Compras", contenido).Result;
                return respuesta.IsSuccessStatusCode;
            }
        }
        public Task ActualizarCompra(Compras compras)
        {
            throw new NotImplementedException();
        }
        public Task EliminarCompra(int id)
        {
            throw new NotImplementedException();
        }

        // Obtener las zonas del evento**********************************
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

    }
}
