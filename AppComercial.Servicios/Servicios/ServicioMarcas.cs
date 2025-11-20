using AppComercial.Datos.Interfaces;
using AppComercial.Entidades.Entidades;
using AppComercial.Servicios.DTOs;
using AppComercial.Servicios.Interfaces;
using AppComercial.Servicios.Mappers;

namespace AppComercial.Servicios.Servicios
{
    public class ServicioMarcas : IServicioMarcas
    {

        private readonly IRepositorioMarcas _repo;

        public ServicioMarcas(IRepositorioMarcas repo)
        {
            _repo = repo;
        }

        public void Agregar(MarcaEditDto marcaDto)
        {
            var marca = MarcaMapper.MapearMarca(marcaDto);
            _repo.AgregarMarca(marca);
        }

        public void Eliminar(MarcaListDto marcaDto)
        {
            var marca = new Marca { MarcaId = marcaDto.MarcaId, Descripcion = marcaDto.Descripcion };
            _repo.EliminarMarca(marca);
        }

        public void Editar(MarcaEditDto marcaDto)
        {
            var marca = MarcaMapper.MapearMarca(marcaDto);
            _repo.EditarMarca(marca);
        }

        public bool Existe(MarcaEditDto marcaDto)
        {
            var marca = MarcaMapper.MapearMarca(marcaDto);
            return _repo.Existe(marca);
        }

        public int ObtenerCantidad()
        {
            return _repo.ObtenerCantidad();
        }

        public MarcaEditDto ObtenerPorId(int id)
        {
            var marca = _repo.ObtenerMarcaPorId(id);
            return MarcaMapper.MapearEditDto(marca);
        }

        public List<MarcaListDto> ObtenerTodos()
        {
            var marcas = _repo.ObtenerMarcas();
            return MarcaMapper.MapearMarcaListDto(marcas);
        }
    }
}
