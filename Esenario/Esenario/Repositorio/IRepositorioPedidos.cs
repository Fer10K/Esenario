using Esenario.Modelo;
namespace Esenario.Repositorio
{
    public interface IRepositorioPedidos
    {
        Task<Pedidos> Add(Pedidos pedido);
        Task UpDate(int id, Pedidos pedido);
        Task Delete(int id);
        Task<Pedidos?> Get(int id);
        Task<List<Pedidos>> GetAll();
    }
}
