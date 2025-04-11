using Microsoft.EntityFrameworkCore;
using prueba_base.Models;

namespace prueba_base.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        { 
        

        
        }
        public DbSet<AsientoDiarioDetalle> AsientoDiarioDetalles { get; set; }
        public DbSet<prueba_base.Models.Comprobante> Comprobante { get; set; } = default!;
        public DbSet<prueba_base.Models.OrdenCompraDetalle> OrdenCompraDetalle { get; set; } = default!;
        
        
    }
}
