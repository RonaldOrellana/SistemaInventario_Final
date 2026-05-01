using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class Formmenu : Form
    {
        public Formmenu()
        {
            InitializeComponent();

            btncreacuent.Visible = false;
            Label14.Visible = false;
            btnlistacuenta.Visible = false;
            label8.Visible = false;

            label8.Click += label8_Click;
            this.Load += Formmenu_Load;
        }

        private void Formmenu_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Productos", cn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblcantpro.Text = (result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0).ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Ventas", cn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblcantv.Text = (result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0).ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Total),0) FROM Ventas", cn))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal totalIngresos = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0m;
                        lbltotal.Text = totalIngresos.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el panel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlternarOpcionesVentas()
        {
            bool mostrar = !Label14.Visible;

            btncreacuent.Visible = mostrar;
            Label14.Visible = mostrar;
            btnlistacuenta.Visible = mostrar;
            label8.Visible = mostrar;
        }

        private void picCategoria_Click(object sender, EventArgs e)
        {
            FormCategorias frm = new FormCategorias();
            frm.Show();
        }

        private void picProducto_Click(object sender, EventArgs e)
        {
            FormProductos frm = new FormProductos();
            frm.Show();
        }

        private void picClientes_Click(object sender, EventArgs e)
        {
            FormClientes frm = new FormClientes();
            frm.Show();
        }

        private void picVentas_Click(object sender, EventArgs e)
        {
            AlternarOpcionesVentas();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AlternarOpcionesVentas();
        }

        private void btncreacuent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btncreacuent_Click(object sender, EventArgs e)
        {
            FormVentas frm = new FormVentas();
            frm.Show();
        }

        private void btnlistacuenta_Click(object sender, EventArgs e)
        {
            FormListadoVentas frm = new FormListadoVentas();
            frm.Show();
        }

        private void Label14_Click(object sender, EventArgs e)
        {
            FormVentas frm = new FormVentas();
            frm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormListadoVentas frm = new FormListadoVentas();
            frm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void Formmenu_Load_1(object sender, EventArgs e)
        {

        }
    }
}