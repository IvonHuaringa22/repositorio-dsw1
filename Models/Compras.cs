using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_DSWI_GP3.Models
{
    public class Compras
    {
        [Key]
        public int IdCompra { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios Usuarios { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; } = DateTime.Now;

        [Required]
        public string MetodoPago { get; set; }

        [Required]
        public string EstadoPago { get; set; }

        [ForeignKey("Zona")]   //*************
        public int IdZona { get; set; }

        [ForeignKey("Evento")]
        public int IdEvento { get; set; }
    }
}
