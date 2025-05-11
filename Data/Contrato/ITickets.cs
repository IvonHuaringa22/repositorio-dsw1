using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface ITickets
    {
        Task<IEnumerable<Tickets>> ListarTickets();
        Task<Tickets> ObtenerTicketPorId(int id);
        Task<IEnumerable<Tickets>> ObtenerTicketPorCompra(int idCompra);
        Task EliminarTicket(int id);
    }
}
