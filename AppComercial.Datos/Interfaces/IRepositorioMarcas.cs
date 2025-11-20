using AppComercial.Entidades.Entidades;

namespace AppComercial.Datos.Interfaces
{
    public interface IRepositorioMarcas
    {

        List<Marca> ObtenerMarcas();
        int ObtenerCantidad();
        Marca? ObtenerMarcaPorId(int id);
        bool Existe(Marca marca);
        void AgregarMarca(Marca marca);
        void EliminarMarca(Marca marca);
        void EditarMarca(Marca marca);
    }
}
