using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface ICompras
    {
        Task<IEnumerable<Compras>> ListarCompras();
        IEnumerable<Compras> BuscarPorUsuario(int idUsuario);  //****
        IEnumerable<Compras> BuscarPorEvento(int idEvento);   //****
        Task<Compras> ObtenerCompraPorId(int id);
        bool RegistrarCompra(Compras compras);
        Task ActualizarCompra(Compras compras);
        Task EliminarCompra(int id);
    }
}
