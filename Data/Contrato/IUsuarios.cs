using Proyecto_DSWI_GP3.Models;
namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface IUsuarios
    {
        Task<bool> Registrar(Usuarios usuarios);
        Task<bool> Actualizar(Usuarios usuarios);
        Task<bool> Eliminar(int id);
        Task<IEnumerable<Usuarios>> Listar();
        Task<Usuarios> ObtenerPorId(int id);
    }
}
