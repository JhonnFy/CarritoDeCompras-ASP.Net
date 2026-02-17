namespace CarritoDeCompras.Entities
{
    public class CLIENTE
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Reestablecer { get; set; }

        //Colección inversa
        public ICollection<CARRITO> CARRITO { get; set; }
        public ICollection<VENTA> VENTA { get; set; }

    }
}
