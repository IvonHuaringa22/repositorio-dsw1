using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_DSWI_GP3.Models
{
    public class Compras
    {
        [Key]
        public int IdCompra { get; set; }
        // Se especifica el nombre de la clave externa correspondiente  
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        [Required]
        public string MetodoPago { get; set; } = string.Empty;
        [Required]
        public string EstadoPago { get; set; } = string.Empty;
        [ForeignKey("Zona")]
        public int IdZona { get; set; }

        [ForeignKey("Evento")]
        public int IdEvento { get; set; }




    }
}
