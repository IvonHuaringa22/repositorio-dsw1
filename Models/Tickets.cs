using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_DSWI_GP3.Models
{
    public class Tickets
    {
        [Key]
        public int IdTicket { get; set; }

        [ForeignKey("Compra")]
        public int IdCompra { get; set; }
        [ForeignKey("Zona")]
        public int IdZona { get; set; }
        [ForeignKey("Evento")]
        public int IdEvento { get; set; }

    }
}
