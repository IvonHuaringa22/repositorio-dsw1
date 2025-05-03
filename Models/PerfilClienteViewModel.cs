using Proyecto_DSWI_GP3.Data.Contrato;

namespace Proyecto_DSWI_GP3.Models
{
    public class PerfilClienteViewModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }

        // Datos de cuenta (Usuario)
        public int IdUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
