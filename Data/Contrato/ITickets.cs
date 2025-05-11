using Proyecto_DSWI_GP3.Models;
using System.Net.Sockets;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface ITickets
    {
        IEnumerable<Tickets> Listar();
        Tickets ObtenerPorId(int id);
        IEnumerable<Tickets> ObtenerTicketsPorCompra(int idCompra);
        bool EliminarPorCompra(int idCompra);
    }
}
