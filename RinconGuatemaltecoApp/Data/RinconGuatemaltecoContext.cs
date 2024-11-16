using Microsoft.EntityFrameworkCore;
using RinconGuatemaltecoApp.Models;

namespace RinconGuatemaltecoApp.Data
{
    public class RinconGuatemaltecoContext : DbContext
    {
        public RinconGuatemaltecoContext(DbContextOptions<RinconGuatemaltecoContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Despacho> Despachos { get; set; }
        public DbSet<DetalleDespacho> DetalleDespachos { get; set; }
    }
}
