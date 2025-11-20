using AppComercial.Servicios.DTOs;

namespace AppComercial.Windows.Helpers
{
    public static class GridHelper
    {
        public static void MostrarDatosEnGrilla<T>(List<T> lista, DataGridView grid)
        {
            LimpiarGrilla(grid);
            foreach (T item in lista)
            {
                var r = ConstruirFila(grid);
                SetearFila(r, item!);
                AgregarFila(r, grid);
            }
        }
        /// <summary>
        /// Método estático para limpiar una grilla
        /// </summary>
        /// <param name="grid">Grilla que se desea limpiar</param>
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
        /// <summary>
        /// Método estático para construir una nueva fila
        /// de la grilla que me pasan
        /// </summary>
        /// <param name="grid">Grilla a la cual le creo la fila</param>
        /// <returns>Fila de la grilla resultante</returns>
        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }
        /// <summary>
        /// Método estático para setear la fila de la grilla
        /// con el contenido del objeto que me pasan
        /// </summary>
        /// <param name="r">Fila a popular</param>
        /// <param name="chocolate">objeto que se muestra</param>
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                /*
                 * Completar con sus clases
                 */
                case MarcaListDto marca:
                    r.Cells[0].Value = marca.MarcaId;
                    r.Cells[1].Value = marca.Descripcion;
                    break;
                case ProductoListDto producto:
                    r.Cells[0].Value = producto.ProductoId;
                    r.Cells[1].Value = producto.Descripcion;
                    r.Cells[2].Value = producto.MarcaDescripcion;
                    r.Cells[3].Value = producto.PrecioCompra;
                    r.Cells[4].Value = producto.PrecioVenta;
                    break;

            }

            r.Tag = obj;
        }
        /// <summary>
        /// Método estático para agregar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a agregar</param>
        /// <param name="grid">Grilla en la cual se agrega la fila</param>
        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }
        /// <summary>
        /// Método estático para eliminar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a eliminar</param>
        /// <param name="grid">Grilla en la cual se desea quitar la fila</param>
        public static void QuitarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }

    }
}
