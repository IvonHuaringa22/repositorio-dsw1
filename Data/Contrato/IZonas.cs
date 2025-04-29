using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Data.Contrato
{
    public interface IZonas
    {
        Task<IEnumerable<Zonas>> ListarZonas();
        Task<Zonas> ObtenerZonaPorId(int id);
        Task RegistrarZona(Zonas zonas);
        Task ActualizarZona(Zonas zonas);
        Task EliminarZona(int id);
    }
}
