using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_DSWI_GP3.Data.Contrato;

namespace Proyecto_DSWI_GP3.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }

        // Relación con Usuario
        public int IdUsuario { get; set; }
        public Usuarios Usuarios { get; set; }
        public string Correo { get; set; }
    }

}
