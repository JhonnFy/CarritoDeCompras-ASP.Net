
using CarritoDeCompras.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class CategoriaWM
    {
        public int IdCategoria { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
