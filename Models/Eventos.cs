using System.ComponentModel.DataAnnotations;

namespace Proyecto_DSWI_GP3.Models
{
    public class Eventos
    {
        [Key]
        public int IdEvento { get; set; }

        [Required]
        public string NombreEvento { get; set; }

        [Required]
        public string TipoEvento { get; set; }

        [Required]
        public string Lugar { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        public string Descripcion { get; set; }
    }
}
