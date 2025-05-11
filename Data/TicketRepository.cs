using Newtonsoft.Json;
using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data
{
    public class TicketRepository : ITickets
    {
        private readonly IConfiguration _config;
        public TicketRepository(IConfiguration config)
        {
            _config = config;
        }


        public async Task EliminarTicket(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.DeleteAsync("Tickets/eliminar/" + id);
                var data = await respuesta.Content.ReadAsStringAsync();
            }
        }

        public async Task<IEnumerable<Tickets>> ListarTickets()
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync("Tickets");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Tickets>>(data);
            }
        }

        public async Task<IEnumerable<Tickets>> ObtenerTicketPorCompra(int idCompra)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync("Tickets/compra/" + idCompra);
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Tickets>>(data);
            }
        }

        public async Task<Tickets> ObtenerTicketPorId(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync("Tickets/" + id);
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tickets>(data);
            }
        }

    }
}
