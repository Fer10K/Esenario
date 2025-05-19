using Esenario.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Esenario.Repositorio
{
    public class RepositorioDetallePedidos : IRepositorioDetallePedidos
    {
        private readonly EsenarioDBContext _context;

        public RepositorioDetallePedidos(EsenarioDBContext context)
        {
            _context = context;
        }

        public async Task<Detalle_Pedido> Add(Detalle_Pedido detalle)
        {
            await _context.Detalle_Pedidos.AddAsync(detalle);
            await _context.SaveChangesAsync();
            return detalle;
        }

        public async Task UpDate(int id, Detalle_Pedido detalle)
        {
            var actual = await _context.Detalle_Pedidos.FindAsync(id);
            if (actual != null)
            {
                actual.Id_Pedido = detalle.Id_Pedido;
                actual.Id_Producto = detalle.Id_Producto;
                actual.Cantidad = detalle.Cantidad;
                actual.Subtotal = detalle.Subtotal;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var detalle = await _context.Detalle_Pedidos.FindAsync(id);
            if (detalle != null)
            {
                _context.Detalle_Pedidos.Remove(detalle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Detalle_Pedido?> Get(int id)
        {
            return await _context.Detalle_Pedidos
                .Include(d => d.Producto)
                .Include(d => d.Pedido)
                .FirstOrDefaultAsync(d => d.Id_Detalle == id);
        }

        public async Task<List<Detalle_Pedido>> GetAll()
        {
            return await _context.Detalle_Pedidos
                .Include(d => d.Producto)
                .Include(d => d.Pedido)
                .ToListAsync();
        }

        public async Task<List<Detalle_Pedido>> GetByPedido(int idPedido)
        {
            return await _context.Detalle_Pedidos
                .Include(d => d.Producto)
                .Where(d => d.Id_Pedido == idPedido)
                .ToListAsync();
        }
    }
}