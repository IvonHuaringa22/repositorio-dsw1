using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface ICompras
    {
        Task<IEnumerable<Compras>> ListarCompras();
        Task<Compras> ObtenerCompraPorId(int id);
        Task RegistrarCompra(Compras compras);
        Task ActualizarCompra(Compras compras);
        Task EliminarCompra(int id);
    }
}
