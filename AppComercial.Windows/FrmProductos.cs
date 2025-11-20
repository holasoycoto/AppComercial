using AppComercial.Servicios.DTOs;
using AppComercial.Servicios.Interfaces;
using AppComercial.Windows.Helpers;

namespace AppComercial.Windows
{
    public partial class FrmProductos : Form
    {

        private readonly IServicioProductos _servicioProductos;
        private readonly IServicioMarcas _servicioMarcas;
        private List<ProductoListDto> listaProductos;
        private List<MarcaListDto> listaMarcas;
        private bool filtroActivo = false;
        private int marcaIdFiltro = 0;

        public FrmProductos(IServicioProductos servicioProductos, IServicioMarcas servicioMarcas)
        {
            InitializeComponent();
            _servicioProductos = servicioProductos;
            _servicioMarcas = servicioMarcas;
            listaMarcas = new();
            listaProductos = new();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

            try
            {
                listaMarcas = _servicioMarcas.ObtenerTodos();
                listaProductos = _servicioProductos.ObtenerTodos();
                MostrarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar abrir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MostrarDatos()
        {
            GridHelper.MostrarDatosEnGrilla<ProductoListDto>(listaProductos, dgvDatos);
            txtCantidad.Text = listaProductos.Count.ToString();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            FrmFiltro frm = new FrmFiltro();
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.Cancel) return;

            string marcaNombre = frm.ObtenerMarca();

            if (string.IsNullOrEmpty(marcaNombre))
            {
                MessageBox.Show("Debe ingresar un nombre de marca.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MarcaListDto? marca = listaMarcas.FirstOrDefault(m =>
                m.Descripcion == marcaNombre);

            if (marca is null)
            {
                MessageBox.Show($"Error: La marca '{marcaNombre}' no existe.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                listaProductos = _servicioProductos.ObtenerPorMarca(marca.MarcaId);
                filtroActivo = true;
                marcaIdFiltro = marca.MarcaId;

                if (listaProductos.Count == 0)
                {
                    MessageBox.Show($"No hay productos registrados para la marca '{marcaNombre}'.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar filtrar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                listaProductos = _servicioProductos.ObtenerTodos();
                filtroActivo = false;
                marcaIdFiltro = 0;
                MostrarDatos();

                MessageBox.Show("Se actualizo la lista de productos.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
