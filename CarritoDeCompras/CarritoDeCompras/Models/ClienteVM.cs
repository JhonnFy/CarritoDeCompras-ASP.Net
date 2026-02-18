
using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class ClienteVM
    {
        public int IdCliente { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Reestablecer { get; set; }

    }
}
