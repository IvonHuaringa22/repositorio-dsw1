using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface IEventos
    {
        Task<IEnumerable<Eventos>> Listar();
    }
}
