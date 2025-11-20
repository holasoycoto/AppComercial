using AppComercial.Datos.Interfaces;
using AppComercial.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AppComercial.Datos.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {

        private readonly ComercialDbContext _db;

        public RepositorioProductos(ComercialDbContext db)
        {
            _db = db;
        }

        public void AgregarProducto(Producto producto)
        {
            _db.Productos.Add(producto);
            _db.SaveChanges();
        }

        public void EliminarProducto(Producto producto)
        {
            if (!Existe(producto)) return;

            _db.Productos.Remove(producto);
            _db.SaveChanges();
        }

        public bool Existe(Producto producto)
        {
            return _db.Productos.Any(p => p.ProductoId == producto.ProductoId || p.Descripcion == producto.Descripcion);
        }

        public bool ExisteRelacionMarca(int marcaId)
        {
            return _db.Productos
                .Any(p => p.MarcaId == marcaId);
        }

        public int ObtenerCantidad()
        {
            return _db.Productos.Count();
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            return _db.Productos.Include(p => p.Marca).FirstOrDefault(p => p.ProductoId == id);
        }

        public List<Producto> ObtenerProductos()
        {
            return _db.Productos.Include(p => p.Marca).ToList();
        }

        public List<Producto> ObtenerProductosPorMarca(int marcaId)
        {
            return _db.Productos
                .Include(p => p.Marca)
                .Where(p => p.MarcaId == marcaId)
                .ToList();
        }

    }
}
