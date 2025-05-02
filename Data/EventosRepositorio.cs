using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.Scripting;
using System.Net.Http;

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
                var respuesta = await clienteHttp.GetAsync("Eventos/listar");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Eventos>>(data);
            }
        }
    }
}
