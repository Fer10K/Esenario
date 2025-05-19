using Esenario.Modelo;

namespace Esenario.Repositorio
{
    public interface IRepositorioPedidos
    {
        Task<Pedido> Add(Pedido pedido);
        Task UpDate(int id, Pedido pedido);
        Task Delete(int id);
        Task<Pedido?> Get(int id);
        Task<List<Pedido>> GetAll();
    }
}