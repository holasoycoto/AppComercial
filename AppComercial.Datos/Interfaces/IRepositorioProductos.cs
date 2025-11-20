using AppComercial.Entidades.Entidades;

namespace AppComercial.Datos.Interfaces
{
    public interface IRepositorioProductos
    {

        List<Producto> ObtenerProductos();
        List<Producto> ObtenerProductosPorMarca(int marcaId);
        int ObtenerCantidad();
        Producto? ObtenerProductoPorId(int id);
        bool Existe(Producto producto);
        void AgregarProducto(Producto producto);
        void EliminarProducto(Producto producto);
        bool ExisteRelacionMarca(int marcaId);
    }
}
