//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;

namespace VentaAPI
{
    using Microsoft.EntityFrameworkCore;

    public class VentaDbContext : DbContext
    {
        public VentaDbContext(DbContextOptions<VentaDbContext> options) : base(options) { }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<ItemVenta> ItemVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }



}
