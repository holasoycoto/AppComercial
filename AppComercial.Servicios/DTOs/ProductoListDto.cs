namespace AppComercial.Servicios.DTOs
{
    public class ProductoListDto
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int MarcaId { get; set; }
        public string MarcaDescripcion { get; set; } = null!;
    }
}
