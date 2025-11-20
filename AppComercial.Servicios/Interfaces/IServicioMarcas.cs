using AppComercial.Servicios.DTOs;

namespace AppComercial.Servicios.Interfaces
{
    public interface IServicioMarcas
    {

        List<MarcaListDto> ObtenerTodos();
        int ObtenerCantidad();
        MarcaEditDto ObtenerPorId(int id);
        void Agregar(MarcaEditDto marcaDto);
        void Eliminar(MarcaListDto marcaDto);
        void Editar(MarcaEditDto marcaDto);
        bool Existe(MarcaEditDto marcaDto);
    }
}
