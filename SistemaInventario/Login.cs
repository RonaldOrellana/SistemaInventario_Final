using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class Login : Form
    {
        int ex, ey;
        bool Arrastre = false;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtusuario.Clear();
            txtcontra.Clear();
            txtcontra.UseSystemPasswordChar = true;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ex = e.X;
            ey = e.Y;
            Arrastre = true;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (Arrastre)
            {
                this.Location = this.PointToScreen(new Point(
                    Control.MousePosition.X - this.Location.X - ex,
                    Control.MousePosition.Y - this.Location.Y - ey
                ));
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            Arrastre = false;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtusuario.Text) && !string.IsNullOrWhiteSpace(txtcontra.Text))
            {
                DataTable dtusuario = validar_usuario(txtusuario.Text.Trim(), txtcontra.Text);

                if (dtusuario.Rows.Count != 0)
                {
                    string nivel = dtusuario.Rows[0]["Rol"].ToString();

                    MessageBox.Show("Bienvenido " + txtusuario.Text + "\nRol: " + nivel, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    txtusuario.Clear();
                    txtcontra.Clear();

                    Formmenu frm = new Formmenu(nivel);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            else
            {
                MessageBox.Show("Completa todos los campos");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkVer_CheckedChanged(object sender, EventArgs e)
        {
            txtcontra.UseSystemPasswordChar = !chkver.Checked;
        }

        private DataTable validar_usuario(string usuario, string contra)
        {
            var dt = new DataTable();
            dt.Columns.Add("Rol", typeof(string));

            using (SqlConnection cn = Conexion.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 Usuario, Clave, Rol FROM Usuarios WHERE Usuario = @Usuario AND Clave = @Clave", cn))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Clave", contra);

                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var row = dt.NewRow();
                        row["Rol"] = reader["Rol"] != DBNull.Value ? reader["Rol"].ToString() : string.Empty;
                        dt.Rows.Add(row);
                    }
                }
            }

            return dt;
        }
    }
}

