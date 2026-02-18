using System;
using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class MarcaVM
    {
        public int IdMarca { get; set; }
       
        [Required]
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
