using Esenario.Modelo;
using Microsoft.AspNetCore.Identity;
namespace Esenario.Repositorio
{
    public interface IRepositorioClientes
    {
        Task<List<Cliente>> GetAll();
        
        Task<Cliente> Get(int id);

        Task<Cliente> Add(Cliente cliente);

        Task UpDate(int id, Cliente cliente);
        Task Delete(int id);
    }
}
