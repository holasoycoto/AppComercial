using AppComercial.Entidades.Entidades;
using AppComercial.Servicios.DTOs;

namespace AppComercial.Servicios.Mappers
{
    public class MarcaMapper
    {
        public static MarcaListDto MapearListDto(Marca marca)
        {
            return new MarcaListDto
            {
                MarcaId = marca.MarcaId,
                Descripcion = marca.Descripcion
            };
        }

        public static MarcaEditDto MapearEditDto(Marca marca)
        {
            return new MarcaEditDto
            {
                MarcaId = marca.MarcaId,
                Descripcion = marca.Descripcion
            };
        }

        public static Marca MapearMarca(MarcaEditDto dto)
        {
            return new Marca
            {
                MarcaId = dto.MarcaId,
                Descripcion = dto.Descripcion
            };
        }

        public static List<MarcaListDto> MapearMarcaListDto(List<Marca> marcas)
        {
            return marcas.Select(m => MapearListDto(m)).ToList();
        }
    }
}
