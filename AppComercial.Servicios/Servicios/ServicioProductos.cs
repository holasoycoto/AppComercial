using AppComercial.Datos.Interfaces;
using AppComercial.Entidades.Entidades;
using AppComercial.Servicios.DTOs;
using AppComercial.Servicios.Interfaces;
using AppComercial.Servicios.Mappers;

namespace AppComercial.Servicios.Servicios
{
    public class ServicioProductos : IServicioProductos
    {

        private readonly IRepositorioProductos _repo;

        public ServicioProductos(IRepositorioProductos repo)
        {
            _repo = repo;
        }

        public void Agregar(ProductoListDto producto)
        {
            var prod = new Producto
            {
                ProductoId = producto.ProductoId,
                Descripcion = producto.Descripcion,
                PrecioCompra = producto.PrecioCompra,
                PrecioVenta = producto.PrecioVenta,
                MarcaId = producto.MarcaId
            };
            _repo.AgregarProducto(prod);
        }

        public void Eliminar(ProductoListDto producto)
        {
            var prod = new Producto
            {
                ProductoId = producto.ProductoId,
                Descripcion = producto.Descripcion,
                PrecioCompra = producto.PrecioCompra,
                PrecioVenta = producto.PrecioVenta,
                MarcaId = producto.MarcaId
            };
            _repo.EliminarProducto(prod);
        }

        public bool ExisteRelacion(int marcaId)
        {
            return _repo.ExisteRelacionMarca(marcaId);
        }

        public int ObtenerCantidad()
        {
            return _repo.ObtenerCantidad();
        }

        public ProductoListDto ObtenerPorId(int id)
        {
            var producto = _repo.ObtenerProductoPorId(id);
            return ProductoMapper.MapearListDto(producto);
        }

        public List<ProductoListDto> ObtenerTodos()
        {
            var productos = _repo.ObtenerProductos();
            return ProductoMapper.MapearProductoListDto(productos);
        }

        public List<ProductoListDto> ObtenerPorMarca(int marcaId)
        {
            var productos = _repo.ObtenerProductosPorMarca(marcaId);
            return ProductoMapper.MapearProductoListDto(productos);
        }
    }
}
