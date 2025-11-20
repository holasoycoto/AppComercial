using AppComercial.Entidades.Entidades;
using AppComercial.Servicios.DTOs;

namespace AppComercial.Windows
{
    public partial class FrmMarcaAe : Form
    {

        private MarcaEditDto _marcaDto;

        public FrmMarcaAe()
        {
            InitializeComponent();
        }

        public MarcaEditDto MarcaEditDto
        {
            get => _marcaDto;
            set => _marcaDto = value;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_marcaDto is not null)
            {
                txtMarca.Text = _marcaDto.Descripcion;
            }

        }

        public MarcaEditDto? ObtenerMarcaDto()
        {
            return _marcaDto;
        }

        public void EstablecerMarca(Marca marca)
        {
            _marcaDto = new MarcaEditDto
            {
                MarcaId = marca.MarcaId,
                Descripcion = marca.Descripcion
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {

                if (_marcaDto is null)
                {
                    _marcaDto = new();
                }

                _marcaDto.Descripcion = txtMarca.Text;

                DialogResult = DialogResult.OK;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                valido = false;
                errorProvider1.SetError(txtMarca, "Ingrese un valor valido!");
            }

            if (int.TryParse(txtMarca.Text, out _))
            {
                valido = false;
                errorProvider1.SetError(txtMarca, "No puedes usar solo numeros!");
            }

            return valido;

        }

    }
}
