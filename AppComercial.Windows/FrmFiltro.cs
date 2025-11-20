namespace AppComercial.Windows
{
    public partial class FrmFiltro : Form
    {
        private string _marcaSeleccionada = "";

        public FrmFiltro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _marcaSeleccionada = txtMarca.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public bool ValidarDatos()
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de marca.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
            }

            return valido;
        }

        public string ObtenerMarca()
        {
            return _marcaSeleccionada;
        }
    }
}
