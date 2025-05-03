using Proyecto_DSWI_GP3.Models;
namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface IZonas
    {
        Task<IEnumerable<Zonas>> Listar();
        Task<Zonas> ObtenerPorId(int id);
        Task Registrar(Zonas zonas);
        Task Actualizar(Zonas zonas);
        Task Eliminar(int id);
    }
}
