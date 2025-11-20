using AppComercial.Servicios.DTOs;

namespace AppComercial.Servicios.Interfaces
{
    public interface IServicioProductos
    {

        List<ProductoListDto> ObtenerTodos();
        List<ProductoListDto> ObtenerPorMarca(int marcaId);
        int ObtenerCantidad();
        ProductoListDto ObtenerPorId(int id);
        void Agregar(ProductoListDto producto);
        void Eliminar(ProductoListDto producto);
        bool ExisteRelacion(int marcaId);
    }
}
