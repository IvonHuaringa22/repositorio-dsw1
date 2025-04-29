using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_DSWI_GP3.Models
{
    public class Zonas
    {
        [Key]
        public int IdZona { get; set; }

        [Required]
        public int IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Eventos Eventos { get; set; }

        [Required]
        public string NombreZona { get; set; } = string.Empty;

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Capacidad { get; set; }
    }
}
