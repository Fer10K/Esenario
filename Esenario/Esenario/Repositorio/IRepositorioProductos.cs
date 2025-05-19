using Esenario.Modelo;

namespace Esenario.Repositorio
{
    public interface IRepositorioProductos
    {
        Task<Producto> Add(Producto producto);
        Task UpDate(int id, Producto producto);
        Task Delete(int id);
        Task<Producto?> Get(int id);
        Task<List<Producto>> GetAll();
    }
}