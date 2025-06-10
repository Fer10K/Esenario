using Esenario.Modelo;
using Microsoft.EntityFrameworkCore;
namespace Esenario.Repositorio
{
    public class RepositorioPedidos :   IRepositorioPedidos
    {
        private readonly EsenarioDBContext _context;
        public RepositorioPedidos(EsenarioDBContext context)
        {
            _context = context;
        }
        public async Task<Pedidos> Add(Pedidos pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }
        public async Task UpDate(int id, Pedidos pedido)
        {
            var actual = await _context.Pedidos.FindAsync(id);
            if (actual != null)
            {
                actual.Fecha_Pedido = pedido.Fecha_Pedido;
                actual.Estado = pedido.Estado;
                actual.Total = pedido.Total;
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Pedidos?> Get(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }
        public async Task<List<Pedidos>> GetAll()
        {
            return await _context.Pedidos.ToListAsync();
        }
    }
}
