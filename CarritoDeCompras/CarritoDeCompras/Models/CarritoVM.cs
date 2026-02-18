using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class CarritoVM
    {
        public int IdCarrito { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
