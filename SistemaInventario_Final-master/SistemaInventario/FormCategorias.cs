using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class FormCategorias : Form
    {
        private const string Tabla = "[dbo].[Categorias]";
        private const string ColCodigo = "[Codigo]";
        private const string ColDescripcion = "[Descripcion]";

        private enum Modo { Ninguno, Nuevo, Editar }
        private Modo modoActual = Modo.Ninguno;

        public FormCategorias()
        {
            InitializeComponent();

            btnnuevo.Click += btnnuevo_Click;
            btnguardar.Click += btnguardar_Click;
            btnmodificar.Click += btnmodificar_Click;
            btneliminar.Click += btneliminar_Click;
            btncancelar.Click += btncancelar_Click;
            dgvcategorias.CellClick += dgvcategorias_CellClick;
            textBox3.TextChanged += (s, e) => CargarCategorias(textBox3.Text.Trim());
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarCategorias("");
            EstablecerEstado(Modo.Ninguno);
        }

        private void EstablecerEstado(Modo modo)
        {
            modoActual = modo;

            switch (modo)
            {
                case Modo.Nuevo:
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label2.Visible = true;
                    textBox2.Visible = true;
                    textBox2.Enabled = true;

                    btnnuevo.Enabled = false;
                    btnguardar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnmodificar.Enabled = false;
                    btneliminar.Enabled = false;
                    dgvcategorias.Enabled = false;
                    textBox2.Focus();
                    break;

                case Modo.Editar:
                    label1.Visible = true;
                    textBox1.Visible = true;
                    textBox1.Enabled = false;
                    label2.Visible = true;
                    textBox2.Visible = true;
                    textBox2.Enabled = true;

                    btnnuevo.Enabled = false;
                    btnguardar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnmodificar.Enabled = false;
                    btneliminar.Enabled = false;
                    dgvcategorias.Enabled = false;
                    textBox2.Focus();
                    break;

                default:
                    label1.Visible = true;
                    textBox1.Visible = true;
                    textBox1.Enabled = false;
                    label2.Visible = true;
                    textBox2.Visible = true;
                    textBox2.Enabled = false;

                    btnnuevo.Enabled = true;
                    btnguardar.Enabled = false;
                    btncancelar.Enabled = false;
                    dgvcategorias.Enabled = true;

                    bool filaSeleccionada = dgvcategorias.SelectedRows != null && dgvcategorias.SelectedRows.Count > 0;
                    btnmodificar.Enabled = filaSeleccionada;
                    btneliminar.Enabled = filaSeleccionada;
                    break;
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstablecerEstado(Modo.Nuevo);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            var codigo = textBox1.Text.Trim();
            var descripcion = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Rellena la descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var cn = Conexion.GetConnection())
                {
                    cn.Open();

                    if (modoActual == Modo.Nuevo)
                    {
                        string sql = $"INSERT INTO {Tabla} ({ColDescripcion}) VALUES (@descripcion)";

                        using (var cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@descripcion", descripcion);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (modoActual == Modo.Editar)
                    {
                        if (string.IsNullOrWhiteSpace(codigo))
                        {
                            MessageBox.Show("Código inválido para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (var cmd = new SqlCommand(
                            $"UPDATE {Tabla} SET {ColDescripcion} = @descripcion WHERE {ColCodigo} = @codigo", cn))
                        {
                            cmd.Parameters.AddWithValue("@descripcion", descripcion);
                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                EstablecerEstado(Modo.Ninguno);
                CargarCategorias(textBox3.Text.Trim());
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error al guardar los datos (SQL): " + sqlEx.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (dgvcategorias.SelectedRows == null || dgvcategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una categoría para modificar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EstablecerEstado(Modo.Editar);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvcategorias.SelectedRows == null || dgvcategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una categoría para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvcategorias.SelectedRows[0];
            var codigo = row.Cells["Codigo"].Value?.ToString();
            var descripcion = row.Cells["Descripcion"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Código inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"¿Eliminar la categoría \"{descripcion}\"?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (var cn = Conexion.GetConnection())
                {
                    cn.Open();

                    using (var cmd = new SqlCommand($"DELETE FROM {Tabla} WHERE {ColCodigo} = @codigo", cn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Categoría eliminada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                EstablecerEstado(Modo.Ninguno);
                CargarCategorias(textBox3.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstablecerEstado(Modo.Ninguno);
        }

        private void dgvcategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvcategorias.Rows[e.RowIndex];
            textBox1.Text = row.Cells["Codigo"].Value?.ToString();
            textBox2.Text = row.Cells["Descripcion"].Value?.ToString();

            EstablecerEstado(Modo.Ninguno);
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void CargarCategorias(string filtro)
        {
            try
            {
                var dt = new DataTable();

                using (var cn = Conexion.GetConnection())
                {
                    string sql =
                        $"SELECT " +
                        $"ROW_NUMBER() OVER (ORDER BY {ColCodigo}) AS Nro, " +
                        $"{ColCodigo} AS Codigo, " +
                        $"{ColDescripcion} AS Descripcion " +
                        $"FROM {Tabla} " +
                        $"WHERE {ColDescripcion} LIKE @f OR CAST({ColCodigo} AS VARCHAR(50)) LIKE @f " +
                        $"ORDER BY {ColCodigo}";

                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@f", $"%{filtro}%");

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                dgvcategorias.DataSource = dt;

                if (dgvcategorias.Columns["Nro"] != null)
                {
                    dgvcategorias.Columns["Nro"].HeaderText = "N°";
                    dgvcategorias.Columns["Nro"].Width = 50;
                }

                if (dgvcategorias.Columns["Codigo"] != null)
                {
                    dgvcategorias.Columns["Codigo"].Visible = false;
                }

                bool tieneFilas = dt.Rows.Count > 0;
                btnmodificar.Enabled = tieneFilas;
                btneliminar.Enabled = tieneFilas;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error cargando categorías (SQL): " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}