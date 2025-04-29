using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface IEventos
    {
        Task<IEnumerable<Eventos>> ListarEventos();
        Task<Eventos> ObtenerEventoPorId(int id);
        Task RegistrarEvento(Eventos eventos);
        Task ActualizarEvento(Eventos eventos);
        Task EliminarEvento(int id);
    }
}
