using Esenario.Modelo;
using Microsoft.EntityFrameworkCore;
namespace Esenario.Repositorio;

public class RepositorioDetallePedido : IRepositorioDetallePedido
{
    private readonly EsenarioDBContext _context;

    public RepositorioDetallePedido(EsenarioDBContext context)
    {
        _context = context;
    }

    public async Task<List<DetallePedido>> GetByPedidoId(int pedidoId)
    {
        return await _context.DetallePedidos
            .Include(d => d.Producto)
            .Where(d => d.PedidoId == pedidoId)
            .ToListAsync();
    }

    public async Task Add(int pedidoId, int productoId, int cantidad)
    {
        var producto = await _context.Productos.FindAsync(productoId);
        if (producto == null) throw new Exception("Producto no encontrado.");

        var subtotal = producto.Precio * cantidad;

        var detalle = new DetallePedido
        {
            PedidoId = pedidoId,
            ProductoId = productoId,
            Cantidad = cantidad,
            Subtotal = subtotal
        };

        _context.DetallePedidos.Add(detalle);
        await _context.SaveChangesAsync();

        await ActualizarTotalPedidoAsync(pedidoId);
    }

    public async Task Delete(int idDetalle)
    {
        var detalle = await _context.DetallePedidos.FindAsync(idDetalle);
        if (detalle == null) return;

        int pedidoId = detalle.PedidoId;

        _context.DetallePedidos.Remove(detalle);
        await _context.SaveChangesAsync();

        await ActualizarTotalPedidoAsync(pedidoId);
    }

    private async Task ActualizarTotalPedidoAsync(int pedidoId)
    {
        var total = await _context.DetallePedidos
            .Where(d => d.PedidoId == pedidoId)
            .SumAsync(d => d.Subtotal);

        var pedido = await _context.Pedidos.FindAsync(pedidoId);
        if (pedido != null)
        {
            pedido.Total = total;
            await _context.SaveChangesAsync();
        }
    }
}