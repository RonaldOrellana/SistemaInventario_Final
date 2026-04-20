using System;
using System.Data;
using System.Drawing;
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
            if (!string.IsNullOrEmpty(txtusuario.Text) && !string.IsNullOrEmpty(txtcontra.Text))
            {
                    DataTable dtusuario = validar_usuario(txtusuario.Text, txtcontra.Text);

                if (dtusuario.Rows.Count != 0)
                {
                    string nivel = dtusuario.Rows[0]["tipo_usuario"].ToString();

                    if (nivel.Equals("Administrador"))
                    {
                        MessageBox.Show("Bienvenido " + txtusuario.Text);

                        this.Hide();
                        txtusuario.Clear();
                        txtcontra.Clear();

                        Formmenu frm = new Formmenu();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error al entrar");
                    }
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

        /// <summary>
        /// Método local de validación de ejemplo.
        /// Reemplázalo por la lógica real de acceso a datos (BD).
        /// Devuelve un DataTable con la columna "tipo_usuario" cuando las credenciales son válidas.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contra"></param>
        /// <returns></returns>
        private DataTable validar_usuario(string usuario, string contra)
        {
            var dt = new DataTable();
            dt.Columns.Add("tipo_usuario", typeof(string));

            // Credenciales de ejemplo actualizadas:
            // admin / 123456  => Administrador
            // user  / user    => Usuario (ejemplo)
            if (usuario == "admin" && contra == "123456")
            {
                var row = dt.NewRow();
                row["tipo_usuario"] = "Administrador";
                dt.Rows.Add(row);
            }
            else if (usuario == "user" && contra == "user")
            {
                var row = dt.NewRow();
                row["tipo_usuario"] = "Usuario";
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}

