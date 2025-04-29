using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface ITickets
    {
        Task<IEnumerable<Tickets>> ListarTickets();
        Task<Tickets> ObtenerTicketPorId(int id);
        Task RegistrarTicket(Tickets tickets);
        Task ActualizarTicket(Tickets tickets);
        Task EliminarTicket(int id);
    }
}
