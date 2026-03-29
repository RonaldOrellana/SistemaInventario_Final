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
        // Variable booleana para controlar si las opciones de ventas están visibles
        private bool ventasMenuAbierto = false;

        public Formmenu()
        {
            InitializeComponent();
            this.Load += Formmenu_Load;
        }

        private void Formmenu_Load(object sender, EventArgs e)
        {
            // Ocultar las opciones de ventas al iniciar el formulario
            OcultarOpcionesVentas();
        }

        /// <summary>
        /// Oculta los botones y etiquetas de "Añadir venta" y "Listado de Ventas"
        /// </summary>
        private void OcultarOpcionesVentas()
        {
            btncreacuent.Visible = false;
            Label14.Visible = false;       // Etiqueta "Añadir venta"
            btnlistacuenta.Visible = false;
            btnlistacuenta.Enabled = true;  // Asegurar que esté habilitado
            label8.Visible = false;         // Etiqueta "Listado de Ventas"
            ventasMenuAbierto = false;
        }

        /// <summary>
        /// Muestra los botones y etiquetas de "Añadir venta" y "Listado de Ventas"
        /// </summary>
        private void MostrarOpcionesVentas()
        {
            btncreacuent.Visible = true;
            Label14.Visible = true;
            btnlistacuenta.Visible = true;
            btnlistacuenta.Enabled = true;
            label8.Visible = true;
            ventasMenuAbierto = true;
        }

        /// <summary>
        /// Toggle: al hacer clic en la imagen de Ventas, muestra u oculta las opciones
        /// </summary>
        private void picVentas_Click(object sender, EventArgs e)
        {
            if (ventasMenuAbierto)
            {
                OcultarOpcionesVentas();
            }
            else
            {
                MostrarOpcionesVentas();
            }
        }

        /// <summary>
        /// Clic en el panel "Añadir venta" → abre FormVentas
        /// </summary>
        private void btncreacuent_Click(object sender, EventArgs e)
        {
            FormVentas frm = new FormVentas();
            frm.Show();
        }

        /// <summary>
        /// Clic en la etiqueta "Añadir venta" → abre FormVentas
        /// </summary>
        private void Label14_Click(object sender, EventArgs e)
        {
            FormVentas frm = new FormVentas();
            frm.Show();
        }

        /// <summary>
        /// Clic en el panel "Listado de Ventas" → abre FormVentas
        /// </summary>
        private void btnlistacuenta_Click(object sender, EventArgs e)
        {
            FormListadoVentas frm = new FormListadoVentas();
            frm.Show();
        }

        /// <summary>
        /// Clic en la etiqueta "Listado de Ventas" → abre FormVentas
        /// </summary>
        private void label8_Click(object sender, EventArgs e)
        {
            FormListadoVentas frm = new FormListadoVentas();
            frm.Show();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btncreacuent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
