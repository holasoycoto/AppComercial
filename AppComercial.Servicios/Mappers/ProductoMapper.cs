using AppComercial.Entidades.Entidades;
using AppComercial.Servicios.DTOs;

namespace AppComercial.Servicios.Mappers
{
    public class ProductoMapper
    {
        public static ProductoListDto MapearListDto(Producto producto)
        {
            return new ProductoListDto
            {
                ProductoId = producto.ProductoId,
                Descripcion = producto.Descripcion,
                PrecioCompra = producto.PrecioCompra,
                PrecioVenta = producto.PrecioVenta,
                MarcaId = producto.MarcaId,
                MarcaDescripcion = producto.Marca?.Descripcion ?? "Sin marca"
            };
        }

        public static List<ProductoListDto> MapearProductoListDto(List<Producto> productos)
        {
            return productos.Select(p => MapearListDto(p)).ToList();
        }
    }
}
