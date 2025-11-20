using AppComercial.Servicios.DTOs;
using AppComercial.Servicios.Interfaces;
using AppComercial.Windows.Helpers;

namespace AppComercial.Windows
{
    public partial class FrmMarcas : Form
    {

        private readonly IServicioMarcas _servicioMarcas;
        private readonly IServicioProductos _servicioProductos;
        private List<MarcaListDto> listaMarcas;

        public FrmMarcas(IServicioMarcas servicioMarcas, IServicioProductos servicioProductos)
        {
            InitializeComponent();
            _servicioMarcas = servicioMarcas;
            _servicioProductos = servicioProductos;
            listaMarcas = new();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            try
            {

                listaMarcas = _servicioMarcas.ObtenerTodos();
                MostrarDatos();

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrio un error al intentar abrir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void MostrarDatos()
        {

            GridHelper.MostrarDatosEnGrilla<MarcaListDto>(listaMarcas, dgvDatos);
            txtCantidad.Text = listaMarcas.Count.ToString();

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            FrmMarcaAe frm = new() { Name = "Agregar Marca" };
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.Cancel) return;

            MarcaEditDto? marcaDto = frm.ObtenerMarcaDto();

            if (marcaDto is null) return;

            if (_servicioMarcas.Existe(marcaDto))
            {
                MessageBox.Show($"Error: Esta marca ya se encuentra registrada.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _servicioMarcas.Agregar(marcaDto);
                MessageBox.Show($"¡Se agrego la marca '{marcaDto.Descripcion}' correctamente!",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listaMarcas = _servicioMarcas.ObtenerTodos();
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar agregar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count == 0) return;

            var r = dgvDatos.SelectedRows[0];
            MarcaListDto? marca = (MarcaListDto)r.Tag!;

            DialogResult dr = MessageBox.Show($"¿Estas seguro de eliminar la marca '{marca.Descripcion}?",
                "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Cancel) return;

            if (_servicioProductos.ExisteRelacion(marca.MarcaId))
            {
                MessageBox.Show($"Error: Esta marca posee productos relacionados y no es posible eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                _servicioMarcas.Eliminar(marca);
                MessageBox.Show($"¡Se elimino la marca '{marca.Descripcion}' correctamente!",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listaMarcas = _servicioMarcas.ObtenerTodos();
                MostrarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
