using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.Scripting;

namespace Proyecto_DSWI_GP3.Data
{
    public class UsuariosRepositorio : IUsuarios
    {
        private readonly IConfiguration _config;
        public UsuariosRepositorio(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<Usuarios>> Listar()
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync("Usuarios");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuarios>>(data);
            }
        }
        public async Task<bool> Registrar(Usuarios usuarios)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                usuarios.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuarios.Contraseña);

                var contenido = new StringContent(JsonConvert.SerializeObject(usuarios), System.Text.Encoding.UTF8, "application/json");
                var respuesta = await clienteHttp.PostAsync("Usuarios", contenido);
                var data = await respuesta.Content.ReadAsStringAsync();

                return bool.Parse(data);
            }
        }
        public async Task<bool> Actualizar(Usuarios usuarios)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var contenido = new StringContent(JsonConvert.SerializeObject(usuarios), System.Text.Encoding.UTF8, "application/json");
                var respuesta = await clienteHttp.PutAsync("Usuarios", contenido);
                var data = await respuesta.Content.ReadAsStringAsync();
                return bool.Parse(data);
            }
        }
        public async Task<bool> Eliminar(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.DeleteAsync($"Usuarios/{id}");
                var data = await respuesta.Content.ReadAsStringAsync();
                return bool.Parse(data);
            }
        }
        public async Task<Usuarios> ObtenerPorId(int id)
        {
            using (var clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri(_config["Services:url"]);
                var respuesta = await clienteHttp.GetAsync($"Usuarios/{id}");
                var data = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usuarios>(data);
            }
        }
    }
}