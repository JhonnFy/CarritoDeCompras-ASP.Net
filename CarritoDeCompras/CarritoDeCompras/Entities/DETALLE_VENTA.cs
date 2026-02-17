namespace CarritoDeCompras.Entities
{
    public class DETALLE_VENTA
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int total { get; set; }

        //Mapa De Navegación
        public VENTA VENTA { get; set; }
        public PRODUCTO PRODUCTO { get; set; }

    }
}
