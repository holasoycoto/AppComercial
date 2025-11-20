using AppComercial.Servicios.Interfaces;

namespace AppComercial.Windows
{
    public partial class FrmPrincipal : Form
    {

        private readonly IServicioMarcas _servicioMarcas;
        private readonly IServicioProductos _servicioProductos;

        public FrmPrincipal(IServicioMarcas servicioMarcas, IServicioProductos servicioProductos)
        {
            InitializeComponent();
            _servicioMarcas = servicioMarcas;
            _servicioProductos = servicioProductos;
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {

            FrmMarcas frm = new(_servicioMarcas, _servicioProductos) { Text = "Lista de Marcas" };

            frm.ShowDialog();

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {

            FrmProductos frm = new(_servicioProductos, _servicioMarcas) { Text = "Lista de Productos" };

            frm.ShowDialog();


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
