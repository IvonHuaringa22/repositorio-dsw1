using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_DSWI_GP3.Models
{
    public class Tickets
    {
        [Key]
        public int IdTicket { get; set; }

        [Required]
        public int IdCompra { get; set; }

        [ForeignKey("IdCompra")]
        public Compras Compras { get; set; }

        [Required]
        public int IdZona { get; set; }

        [ForeignKey("IdZona")]
        public Zonas Zonas { get; set; }

        [ForeignKey("Evento")]  //*******
        public int IdEvento { get; set; }
    }
}
