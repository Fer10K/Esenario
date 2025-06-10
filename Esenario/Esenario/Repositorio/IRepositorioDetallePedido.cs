using Esenario.Modelo;

namespace Esenario.Repositorio
{
    public interface IRepositorioDetallePedido
    {
        Task<List<DetallePedido>> GetByPedidoId(int pedidoId);
        Task Add(int pedidoId, int productoId, int cantidad);
        Task Delete(int idDetalle);
    }

}
