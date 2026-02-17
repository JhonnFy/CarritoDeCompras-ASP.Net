using System.Runtime.CompilerServices;

namespace CarritoDeCompras.Entities
{
    public class VENTA
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int TotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public string Contacto { get; set; }
        public int IdDistrito { get; set; }
        public string Telefono { get; set; } 
        public string Direccion { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdTransaccion { get; set; }

        //Mapa De Navegación
        public CLIENTE CLIENTE { get; set; }
    }
}
