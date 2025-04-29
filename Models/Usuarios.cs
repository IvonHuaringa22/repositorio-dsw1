using System.ComponentModel.DataAnnotations;

namespace Proyecto_DSWI_GP3.Models
{
        public class Usuarios
        {
            [Key]
            public int IdUsuario { get; set; }

            [Required]
            public string Nombre { get; set; }

            [Required]
            public string Correo { get; set; }

            [Required]
            public string Contraseña { get; set; }

        [Required]
            public string TipoUsuario { get; set; } // "Cliente" o "Administrador"
        }
}
