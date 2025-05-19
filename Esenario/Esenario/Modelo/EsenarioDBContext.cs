using Microsoft.EntityFrameworkCore;

namespace Esenario.Modelo
{
    public class EsenarioDBContext : DbContext
    {
        public EsenarioDBContext(DbContextOptions<EsenarioDBContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Detalle_Pedido> Detalle_Pedidos { get; set; }
    }
}
