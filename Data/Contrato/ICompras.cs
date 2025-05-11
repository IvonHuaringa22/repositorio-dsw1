using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface ICompras
    {
        IEnumerable<Compras> Listar();
        Compras ObtenerCompraPorId(int id);
        IEnumerable<Compras> BuscarPorUsuario(int idUsuario);
        IEnumerable<Compras> BuscarPorEvento(int idEvento);
        bool Registrar(Compras compra);
        bool Editar(Compras compra);
        bool Eliminar(int id);
    }
}
