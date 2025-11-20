namespace AppComercial.Entidades.Entidades
{
    public class Producto
    {

        public int ProductoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; } = null!;

    }
}
