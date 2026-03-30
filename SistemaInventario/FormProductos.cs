using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaInventario.Data;

namespace SistemaInventario
{
    public partial class FormProductos : Form
    {
        private enum Modo { Ninguno, Nuevo, Editar }
        private Modo modoActual = Modo.Ninguno;

        public FormProductos()
        {
            InitializeComponent();

            btnnuevo.Click += BtnNuevo_Click;
            btnmodificar.Click += BtnModificar_Click;
            btneliminar.Click += BtnEliminar_Click;
            btnguardar.Click += BtnGuardar_Click;
            btncancelar.Click += BtnCancelar_Click;
            txtbuscar.TextChanged += TxtBuscar_TextChanged;
            dgvproducto.CellClick += DgvProductos_CellClick;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            ConfigurarColumnas();
            Limpiar();
            EstablecerModo(Modo.Ninguno);
            CargarCategorias();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void ConfigurarColumnas()
        {
            if (dgvproducto.Columns["Codigo"] != null)
            {
                    dgvproducto.Columns["Codigo"].HeaderText = "Código";
                dgvproducto.Columns["Codigo"].Width = 70;
                dgvproducto.Columns["Codigo"].ReadOnly = true;
            }
            if (dgvproducto.Columns["Nombre"] != null)
            {
                dgvproducto.Columns["Nombre"].HeaderText = "Nombre";
                dgvproducto.Columns["Nombre"].Width = 200;
            }
            if (dgvproducto.Columns["Precio"] != null)
            {
                dgvproducto.Columns["Precio"].HeaderText = "Precio";
                dgvproducto.Columns["Precio"].DefaultCellStyle.Format = "N2";
                dgvproducto.Columns["Precio"].Width = 80;
            }
            if (dgvproducto.Columns["Stock"] != null)
            {
                dgvproducto.Columns["Stock"].HeaderText = "Stock";
                dgvproducto.Columns["Stock"].Width = 60;
            }
            if (dgvproducto.Columns["Categoria"] != null)
            {
                dgvproducto.Columns["Categoria"].HeaderText = "Categoría";
                dgvproducto.Columns["Categoria"].Width = 150;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            EstablecerModo(Modo.Nuevo);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigo.Text))
            {
                MessageBox.Show("Seleccione un producto para modificar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EstablecerModo(Modo.Editar);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigo.Text))
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Eliminar el producto seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int codigo = int.Parse(txtcodigo.Text);
                if (ProductoRepository.Delete(codigo))
                {
                    MessageBox.Show("Producto eliminado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstablecerModo(Modo modo)
        {
            modoActual = modo;

            bool enEdicion = (modo == Modo.Nuevo || modo == Modo.Editar);

            txtcodigo.Enabled = false;
            txtnombre.Enabled = enEdicion;
            txtprecio.Enabled = enEdicion;
            txtstock.Enabled = enEdicion;
            cbcategoria.Enabled = enEdicion;

            btnguardar.Enabled = enEdicion;
            btncancelar.Enabled = enEdicion;

            btnnuevo.Enabled = !enEdicion;
            btnmodificar.Enabled = !enEdicion;
            btneliminar.Enabled = !enEdicion;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
        }

        private void Limpiar()
        {
            txtcodigo.Text = string.Empty;
            txtnombre.Text = string.Empty;
            txtprecio.Text = string.Empty;
            txtstock.Value = 0;
            cbcategoria.Text = string.Empty;
            dgvproducto.ClearSelection();
        }

        private void CargarProductos()
        {
            dgvproducto.DataSource = ProductoRepository.GetAll();
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvproducto.Rows.Count > e.RowIndex)
            {
                DataGridViewRow row = dgvproducto.Rows[e.RowIndex];
                txtcodigo.Text = row.Cells["Codigo"].Value?.ToString() ?? string.Empty;
                txtnombre.Text = row.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                txtprecio.Text = row.Cells["Precio"].Value?.ToString() ?? string.Empty;

                // Cargar stock con Value (NumericUpDown)
                int stockValue = 0;
                if (row.Cells["Stock"].Value != null && row.Cells["Stock"].Value != DBNull.Value)
                {
                    int.TryParse(row.Cells["Stock"].Value.ToString(), out stockValue);
                }
                txtstock.Value = stockValue;

                cbcategoria.Text = row.Cells["Categoria"].Value?.ToString() ?? string.Empty;
                EstablecerModo(Modo.Ninguno);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtprecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stock = (int)txtstock.Value;

            int? categoriaCodigo = CategoriaRepository.GetSelectedValue(cbcategoria.SelectedValue);

            try
            {
                if (modoActual == Modo.Nuevo)
                {
                    ProductoRepository.Insert(txtnombre.Text.Trim(), precio, stock, categoriaCodigo);
                    MessageBox.Show("Producto guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modoActual == Modo.Editar)
                {
                    int codigo = int.Parse(txtcodigo.Text);
                    ProductoRepository.Update(codigo, txtnombre.Text.Trim(), precio, stock, categoriaCodigo);
                    MessageBox.Show("Producto actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarProductos();
            Limpiar();
            EstablecerModo(Modo.Ninguno);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            EstablecerModo(Modo.Ninguno);
        }

        private void CargarCategorias()
        {
            var dt = CategoriaRepository.GetAll();

            // Fila vacía para permitir "sin categoría"
            var row = dt.NewRow();
            row["Codigo"] = DBNull.Value;
            row["Descripcion"] = "(Sin categoría)";
            dt.Rows.InsertAt(row, 0);

            cbcategoria.DataSource = dt;
            cbcategoria.DisplayMember = "Descripcion";
            cbcategoria.ValueMember = "Codigo";
        }
    }
}
