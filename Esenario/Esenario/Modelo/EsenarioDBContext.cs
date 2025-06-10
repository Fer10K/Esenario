using Microsoft.EntityFrameworkCore;

namespace Esenario.Modelo
{
    public class EsenarioDBContext : DbContext
    {
        public EsenarioDBContext(DbContextOptions<EsenarioDBContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
    }
}
