using Esenario.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Esenario.Repositorio
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly EsenarioDBContext _context;

        public RepositorioProductos(EsenarioDBContext context)
        {
            _context = context;
        }

        public async Task<Producto> Add(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task UpDate(int id, Producto producto)
        {
            var actual = await _context.Productos.FindAsync(id);
            if (actual != null)
            {
                actual.Nombre = producto.Nombre;
                actual.Precio = producto.Precio;
                actual.Disponibilidad = producto.Disponibilidad;
                actual.Categoria = producto.Categoria;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Producto?> Get(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }
    }
}