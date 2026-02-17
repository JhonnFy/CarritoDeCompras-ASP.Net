namespace CarritoDeCompras.Entities
{
    public class PRODUCTO
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        //Mapas De Navegación
        public MARCA MARCA { get; set; }
        public CATEGORIA CATEGORIA { get; set; }

        //Colección inversa
        public ICollection<CARRITO> CARRITO { get; set; }
    }
}
