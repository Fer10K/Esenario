using Esenario.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Esenario.Repositorio
{
    public class RepositorioPedidos : IRepositorioPedidos
    {
        private readonly EsenarioDBContext _context;

        public RepositorioPedidos(EsenarioDBContext context)
        {
            _context = context;
        }

        public async Task<Pedido> Add(Pedido pedido)
        {
            foreach (var detalle in pedido.Detalles ?? new List<Detalle_Pedido>())
            {
                var producto = await _context.Productos.FindAsync(detalle.Id_Producto);
                if (producto != null)
                {
                    detalle.Subtotal = producto.Precio * detalle.Cantidad;
                }
            }
            pedido.Total = pedido.Detalles?.Sum(d => d.Subtotal) ?? 0;
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task UpDate(int id, Pedido pedido)
        {
            var actual = await _context.Pedidos
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.Id_Pedido == id);

            if (actual != null)
            {
                actual.Id_Cliente = pedido.Id_Cliente;
                actual.Fecha = pedido.Fecha;
                actual.Estado = pedido.Estado;

                // Eliminar detalles antiguos
                _context.Detalle_Pedidos.RemoveRange(actual.Detalles ?? new List<Detalle_Pedido>());

                // Recalcular y agregar nuevos detalles
                foreach (var detalle in pedido.Detalles ?? new List<Detalle_Pedido>())
                {
                    var producto = await _context.Productos.FindAsync(detalle.Id_Producto);
                    if (producto != null)
                    {
                        detalle.Subtotal = producto.Precio * detalle.Cantidad;
                    }
                    detalle.Pedido = actual;
                }
                actual.Detalles = pedido.Detalles;
                actual.Total = pedido.Detalles?.Sum(d => d.Subtotal) ?? 0;
                await _context.Detalle_Pedidos.AddRangeAsync(pedido.Detalles ?? new List<Detalle_Pedido>());
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.Id_Pedido == id);

            if (pedido != null)
            {
                if (pedido.Detalles != null)
                    _context.Detalle_Pedidos.RemoveRange(pedido.Detalles);

                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Pedido?> Get(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(p => p.Id_Pedido == id);
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .ToListAsync();
        }
    }
}