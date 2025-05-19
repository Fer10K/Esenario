using Esenario.Modelo;

namespace Esenario.Repositorio
{
    public interface IRepositorioDetallePedidos
    {
        Task<Detalle_Pedido> Add(Detalle_Pedido detalle);
        Task UpDate(int id, Detalle_Pedido detalle);
        Task Delete(int id);
        Task<Detalle_Pedido?> Get(int id);
        Task<List<Detalle_Pedido>> GetAll();
        Task<List<Detalle_Pedido>> GetByPedido(int idPedido);
    }
}