namespace CarritoDeCompras.Models
{
    public class UsuarioVM
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Reestablecer { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
