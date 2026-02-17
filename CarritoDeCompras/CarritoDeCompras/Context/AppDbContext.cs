
using Microsoft.EntityFrameworkCore;
using CarritoDeCompras.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarritoDeCompras.Context
{
    public class AppDbContext : DbContext
    {

        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Estructura De Las Tablas
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<CATEGORIA> CATEGORIA { get; set; }
        public DbSet<MARCA> MARCA { get; set; }
        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<CARRITO> CARRITO { get; set; }
        public DbSet<CLIENTE> CLIENTE { get; set; }
        public DbSet<VENTA> VENTA { get; set; }
        public DbSet<DETALLE_VENTA> DETALLE_VENTA { get; set; }

        //Modelado De Tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(a =>
            {
                a.HasKey("IdUsuario");
                a.Property("IdUsuario").ValueGeneratedOnAdd();
                a.Property("Nombres");
                a.Property("Apellidos");
                a.Property("Correo");
                a.Property("Clave");
                a.Property("Reestablecer");
                a.Property("Activo");
                a.Property("FechaRegistro");
            });

            modelBuilder.Entity<Distrito>(b =>
            {
                b.HasKey("IdDistrito");
                b.Property("IdDistrito").ValueGeneratedOnAdd();
                b.Property("Descripcion");
                b.Property("IdProvincia");
                b.Property("IdDepartamento");
            });

            modelBuilder.Entity<Provincia>(c =>
            {
                c.HasKey("IdProvincia");
                c.Property("IdProvincia").ValueGeneratedOnAdd();
                c.Property("Descripcion");
                c.Property("IdDepartamento");
            });

            modelBuilder.Entity<Departamento>(d =>
            {
                d.HasKey("IdDepartamento");
                d.Property("IdDepartamento").ValueGeneratedOnAdd();
                d.Property("Descripcion");
            });

            modelBuilder.Entity<CATEGORIA>(e =>
            {
                e.HasKey("IdCategoria");
                e.Property("IdCategoria").ValueGeneratedOnAdd();
                e.Property("Descripcion");
                e.Property("Activo");
                e.Property("FechaRegistro");
            });

            modelBuilder.Entity<MARCA>(f =>
            {
                f.HasKey("IdMarca");
                f.Property("IdMarca").ValueGeneratedOnAdd();
                f.Property("Descripcion");
                f.Property("Activo");
                f.Property("FechaRegistro");
            });

            modelBuilder.Entity<PRODUCTO>(g =>
            {
                g.HasKey("IdProducto");
                g.Property("IdProducto").ValueGeneratedOnAdd();
                g.Property("Nombre");
                g.Property("Descripcion");
                g.Property("IdMarca"); /*Fk*/
                g.Property("IdCategoria"); /*Fk*/
                g.Property(x => x.Precio).HasPrecision(18, 2);
                g.Property("Stock");
                g.Property("RutaImagen");
                g.Property("NombreImagen");
                g.Property("Activo");
                g.Property("FechaRegistro");

                g.HasOne(g => g.MARCA).WithMany().HasForeignKey(g => g.IdMarca)
                .OnDelete(DeleteBehavior.Restrict);

                g.HasOne(g => g.CATEGORIA).WithMany().HasForeignKey(g => g.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<DETALLE_VENTA>(h =>
            {
                h.HasKey("IdDetalleVenta");
                h.Property("IdDetalleVenta").ValueGeneratedOnAdd();
                h.Property("IdVenta"); /*Fk*/
                h.Property("IdProducto"); /*Fk*/
                h.Property("Cantidad");
                h.Property("Total");

                h.HasOne(h => h.VENTA).WithMany().HasForeignKey(h => h.IdVenta)
                .OnDelete(DeleteBehavior.Restrict);

                h.HasOne(h => h.PRODUCTO).WithMany().HasForeignKey(h => h.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<VENTA>(i =>
            {
                i.HasKey("IdVenta");
                i.Property("IdVenta").ValueGeneratedOnAdd();
                i.Property("IdCliente"); /*Fk*/
                i.Property("TotalProducto");
                i.Property(x => x.MontoTotal).HasPrecision(18, 2);
                i.Property("Contacto");
                i.Property("IdDistrito");
                i.Property("Telefono");
                i.Property("Direccion");
                i.Property("FechaVenta");
                i.Property("IdTransaccion");

                i.HasOne(v => v.CLIENTE)
                .WithMany(cl => cl.VENTA) //Colección Inversa
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<CLIENTE>(j =>
            {
                j.HasKey("IdCliente");
                j.Property("IdCliente").ValueGeneratedOnAdd();
                j.Property("Nombres");
                j.Property("Apellidos");
                j.Property("Correo");
                j.Property("Clave");
                j.Property("FechaRegistro");
                j.Property("Reestablecer");
            });

            modelBuilder.Entity<CARRITO>(k =>
            {
                k.HasKey("IdCarrito");
                k.Property("IdCarrito").ValueGeneratedOnAdd();
                k.Property("IdCliente"); /*Fk*/
                k.Property("IdProducto"); /*Fk*/
                k.Property("Cantidad");

                // Relación con PRODUCTO
                k.HasOne(c => c.PRODUCTO)
                 .WithMany(p => p.CARRITO)  // Colección inversa en PRODUCTO
                 .HasForeignKey(c => c.IdProducto)
                 .OnDelete(DeleteBehavior.Restrict);

                k.HasOne(c => c.Cliente)
                .WithMany(cl => cl.CARRITO) //Colección Inversa
                .HasForeignKey(c=> c.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
