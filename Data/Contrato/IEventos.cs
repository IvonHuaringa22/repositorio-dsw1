using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface IEventos
    {
        Task<IEnumerable<Eventos>> Listar();
        Task<bool> Registrar(Eventos eventos);
        Task<bool> Actualizar(Eventos eventos);
        Task<bool> Eliminar(int id);
        Task<Eventos> ObtenerPorId(int id);
        Task<List<Eventos>> BuscarPorNombre(string nombre);
    }
}
