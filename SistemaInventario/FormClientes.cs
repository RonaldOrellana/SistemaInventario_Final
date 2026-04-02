using System;
using System.Data;
using System.Windows.Forms;
using SistemaInventario.Data;

namespace SistemaInventario
{
    public partial class FormClientes : Form
    {
        private enum Modo { Ninguno, Nuevo, Editar }
        private Modo modoActual = Modo.Ninguno;

        public FormClientes()
        {
            InitializeComponent();

            btnNuevo.Click += BtnNuevo_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            // btnGuardar.Click += BtnGuardar_Click; // ya está enlazado en el Designer
            btnCancelar.Click += BtnCancelar_Click;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            dgvClientes.CellClick += DgvClientes_CellClick;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            cbSexo.Items.Clear();
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Femenino");

            CargarClientes();
            Limpiar();
            EstablecerModo(Modo.Ninguno);
        }

        // ───────────────────── MODO ─────────────────────
        private void EstablecerModo(Modo modo)
        {
            modoActual = modo;
            bool enEdicion = (modo == Modo.Nuevo || modo == Modo.Editar);

            txtCodigoCliente.Enabled = false;
            txtNombres.Enabled = enEdicion;
            txtApellidos.Enabled = enEdicion;
            txtDni.Enabled = enEdicion;
            cbSexo.Enabled = enEdicion;
            txtDireccion.Enabled = enEdicion;
            txtTelefono.Enabled = enEdicion;

            btnGuardar.Enabled = enEdicion;
            btnCancelar.Enabled = enEdicion;

            btnNuevo.Enabled = !enEdicion;
            btnModificar.Enabled = !enEdicion;
            btnEliminar.Enabled = !enEdicion;
            dgvClientes.Enabled = !enEdicion;
        }

        // ───────────────────── CARGAR DATOS ─────────────────────
        private void CargarClientes()
        {
            string filtro = txtBuscar.Text.Trim();
            dgvClientes.DataSource = string.IsNullOrEmpty(filtro)
                ? ClienteRepository.GetAll()
                : ClienteRepository.Search(filtro);
        }

        // ───────────────────── LIMPIAR ─────────────────────
        private void Limpiar()
        {
            txtCodigoCliente.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDni.Clear();
            cbSexo.SelectedIndex = -1;
            txtDireccion.Clear();
            txtTelefono.Clear();
            dgvClientes.ClearSelection();
        }

        // ───────────────────── BOTONES ─────────────────────
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            EstablecerModo(Modo.Nuevo);
            txtNombres.Focus();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoCliente.Text))
            {
                MessageBox.Show("Seleccione un cliente para modificar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EstablecerModo(Modo.Editar);
            txtNombres.Focus();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoCliente.Text))
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Eliminar el cliente seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int codigo = int.Parse(txtCodigoCliente.Text);
                if (ClienteRepository.Delete(codigo))
                {
                    MessageBox.Show("Cliente eliminado.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    Limpiar();
                    EstablecerModo(Modo.Ninguno);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("No se puede eliminar porque el cliente tiene registros relacionados.\n" + ex.Message,
                    "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese los nombres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese los apellidos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingrese el DUI.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbSexo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el sexo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombres = txtNombres.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string dui = txtDni.Text.Trim();
                string sexo = cbSexo.SelectedItem.ToString();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (modoActual == Modo.Nuevo)
                {
                    ClienteRepository.Insert(nombres, apellidos, dui, sexo, direccion, telefono);
                    MessageBox.Show("Cliente guardado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modoActual == Modo.Editar)
                {
                    int codigo = int.Parse(txtCodigoCliente.Text);
                    ClienteRepository.Update(codigo, nombres, apellidos, dui, sexo, direccion, telefono);
                    MessageBox.Show("Cliente actualizado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarClientes();
                Limpiar();
                EstablecerModo(Modo.Ninguno);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            EstablecerModo(Modo.Ninguno);
        }

        // ───────────────────── EVENTOS GRID / BUSCAR ─────────────────────
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvClientes.Rows.Count)
                return;

            DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
            txtCodigoCliente.Text = row.Cells["CodigoCliente"].Value?.ToString() ?? string.Empty;
            txtNombres.Text = row.Cells["Nombres"].Value?.ToString() ?? string.Empty;
            txtApellidos.Text = row.Cells["Apellidos"].Value?.ToString() ?? string.Empty;
            txtDni.Text = row.Cells["Dui"].Value?.ToString() ?? string.Empty;
            txtDireccion.Text = row.Cells["Direccion"].Value?.ToString() ?? string.Empty;
            txtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? string.Empty;

            string sexo = row.Cells["Sexo"].Value?.ToString() ?? string.Empty;
            int idx = cbSexo.Items.IndexOf(sexo);
            cbSexo.SelectedIndex = idx >= 0 ? idx : -1;

            EstablecerModo(Modo.Ninguno);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
