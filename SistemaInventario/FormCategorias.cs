using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class FormCategorias : Form
    {
        // Usar nombres totalmente calificados / escapados para evitar problemas de esquema o mayúsculas
        private const string Tabla = "[dbo].[Categorias]";
        private const string ColCodigo = "[Codigo]";
        private const string ColDescripcion = "[Descripcion]";
        private const string ColEstado = "[Estado]"; // <-- añadido
        
        private enum Modo { Ninguno, Nuevo, Editar }
        private Modo modoActual = Modo.Ninguno;

        public FormCategorias()
        {
            InitializeComponent();

            // Suscribir eventos
            ntnnuevo.Click += ntnnuevo_Click;
            btnguardar.Click += btnguardar_Click;
            btnmodificar.Click += btnmodificar_Click;
            btneliminar.Click += btneliminar_Click;
            btncancelar.Click += btncancelar_Click;
            dgvcategorias.CellClick += dgvcategorias_CellClick;
            textBox3.TextChanged += (s, e) => CargarCategorias(textBox3.Text.Trim());

            // Estado inicial
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

                    ntnnuevo.Enabled = false;
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

                    ntnnuevo.Enabled = false;
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

                    ntnnuevo.Enabled = true;
                    btnguardar.Enabled = false;
                    btncancelar.Enabled = false;
                    dgvcategorias.Enabled = true;

                    bool filaSeleccionada = dgvcategorias.SelectedRows != null && dgvcategorias.SelectedRows.Count > 0;
                    btnmodificar.Enabled = filaSeleccionada;
                    btneliminar.Enabled = filaSeleccionada;
                    break;
            }
        }

        private void ntnnuevo_Click(object sender, EventArgs e)
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
                if (modoActual == Modo.Nuevo)
                {
                    string sql;
                    if (!string.IsNullOrWhiteSpace(codigo))
                        sql = $"INSERT INTO {Tabla} ({ColCodigo}, {ColDescripcion}) VALUES (@codigo, @descripcion)";
                    else
                        sql = $"INSERT INTO {Tabla} ({ColDescripcion}) VALUES (@descripcion)";
                        
using (var cn = Conexion.GetConnection())
{
    using (var cmd = new SqlCommand(sql, cn))
    {
        cmd.Parameters.AddWithValue("@descripcion", descripcion);
        if (!string.IsNullOrWhiteSpace(codigo))
            cmd.Parameters.AddWithValue("@codigo", codigo);

        if (cn.State != ConnectionState.Open) cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}
                }
                else if (modoActual == Modo.Editar)
                {
                    if (string.IsNullOrWhiteSpace(codigo))
                    {
                        MessageBox.Show("Código inválido para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var cmd = new SqlCommand($"UPDATE {Tabla} SET {ColDescripcion} = @descripcion WHERE {ColCodigo} = @codigo", Conexion.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        if (Conexion.GetConnection().State != ConnectionState.Open) Conexion.GetConnection().Open();
                        cmd.ExecuteNonQuery();
                        Conexion.GetConnection().Close();
                    }
                }

                MessageBox.Show("Guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                EstablecerEstado(Modo.Ninguno);
                CargarCategorias(textBox3.Text.Trim());
            }
            catch (SqlException sqlEx)
            {
                // Mostrar detalle de SQL para depuración
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
                using (var cmd = new SqlCommand($"DELETE FROM {Tabla} WHERE {ColCodigo} = @codigo", Conexion.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    if (Conexion.GetConnection().State != ConnectionState.Open) Conexion.GetConnection().Open();
                    cmd.ExecuteNonQuery();
                    Conexion.GetConnection().Close();
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
                using (var cmd = new SqlCommand(
                    $"SELECT {ColCodigo} AS Codigo, {ColDescripcion} AS Descripcion FROM {Tabla} " +
                    $"WHERE {ColDescripcion} LIKE @f OR CAST({ColCodigo} AS VARCHAR(50)) LIKE @f", Conexion.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@f", $"%{filtro}%");
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                dgvcategorias.DataSource = dt;

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

        private void label1_Click(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void FormCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}
