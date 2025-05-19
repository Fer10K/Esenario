using Esenario.Modelo;
using Microsoft.EntityFrameworkCore;
namespace Esenario.Repositorio
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly EsenarioDBContext _context;
        public RepositorioClientes(EsenarioDBContext context)
        {
            _context = context;
        }
        public async Task<Cliente> Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Cliente>? Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task UpDate(int id, Cliente cliente)
        {
            var clienteactual = await _context.Clientes.FindAsync(id);
            if (clienteactual != null)
            {
                clienteactual.Nombre = cliente.Nombre;
                clienteactual.Telefono = cliente.Telefono;
                clienteactual.Direccion = cliente.Direccion;
                clienteactual.Correo = cliente.Correo;
                await _context.SaveChangesAsync();
            }
        }
    }
}
