using Esenario.Modelo;

namespace Esenario.Repositorio
{
    public interface IRepositorioClientes
    {
        Task<Cliente> Add(Cliente cliente);
        Task UpDate(int id, Cliente cliente);
        Task Delete(int id);
        Task<Cliente?> Get(int id);
        Task<List<Cliente>> GetAll();
    }
}
