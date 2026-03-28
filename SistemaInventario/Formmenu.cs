using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class Formmenu : Form
    {
        public Formmenu()
        {
            InitializeComponent();
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
            FormVentas frm = new FormVentas();
            frm.Show();
        }
    }
}
