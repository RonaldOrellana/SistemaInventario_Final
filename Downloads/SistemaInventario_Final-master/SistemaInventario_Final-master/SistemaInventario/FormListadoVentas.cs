using System;
using System.Data;
using System.Windows.Forms;
using SistemaInventario.Data;

namespace SistemaInventario
{
    public partial class FormListadoVentas : Form
    {
        public FormListadoVentas()
        {
            InitializeComponent();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            dgvVentas.CellClick += DgvVentas_CellClick;
        }

        private void FormListadoVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
            ConfigurarColumnasVentas();
        }

        private void CargarVentas()
        {
            dgvVentas.DataSource = VentaRepository.GetAll();
            ConfigurarColumnasVentas();
            LimpiarDetalle();
        }

        private void ConfigurarColumnasVentas()
        {
            if (dgvVentas.Columns["Id"] != null)
            {
                dgvVentas.Columns["Id"].HeaderText = "N° Venta";
                dgvVentas.Columns["Id"].Width = 80;
            }
            if (dgvVentas.Columns["Fecha"] != null)
            {
                dgvVentas.Columns["Fecha"].HeaderText = "Fecha";
                dgvVentas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvVentas.Columns["Fecha"].Width = 160;
            }
            if (dgvVentas.Columns["Cliente"] != null)
            {
                dgvVentas.Columns["Cliente"].HeaderText = "Cliente";
                dgvVentas.Columns["Cliente"].Width = 200;
            }
            if (dgvVentas.Columns["Total"] != null)
            {
                dgvVentas.Columns["Total"].HeaderText = "Total";
                dgvVentas.Columns["Total"].DefaultCellStyle.Format = "N2";
                dgvVentas.Columns["Total"].Width = 100;
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                dgvVentas.DataSource = VentaRepository.GetAll();
            }
            else
            {
                dgvVentas.DataSource = VentaRepository.Search(filtro);
            }

            ConfigurarColumnasVentas();
            LimpiarDetalle();
        }

        private void DgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvVentas.Rows.Count)
                return;

            DataGridViewRow row = dgvVentas.Rows[e.RowIndex];
            object idValue = row.Cells["Id"].Value;

            if (idValue == null || idValue == DBNull.Value)
                return;

            int ventaId = Convert.ToInt32(idValue);
            CargarDetalle(ventaId);

            // Mostrar el total de la venta seleccionada
            object totalValue = row.Cells["Total"].Value;
            decimal total = totalValue != null && totalValue != DBNull.Value
                ? Convert.ToDecimal(totalValue)
                : 0m;
            lblTotalVenta.Text = "Total: $" + total.ToString("N2");
        }

        private void CargarDetalle(int ventaId)
        {
            dgvDetalle.DataSource = VentaRepository.GetDetalles(ventaId);
            ConfigurarColumnasDetalle();
        }

        private void ConfigurarColumnasDetalle()
        {
            if (dgvDetalle.Columns["Id"] != null)
                dgvDetalle.Columns["Id"].Visible = false;

            if (dgvDetalle.Columns["Producto"] != null)
            {
                dgvDetalle.Columns["Producto"].HeaderText = "Producto";
                dgvDetalle.Columns["Producto"].Width = 200;
            }
            if (dgvDetalle.Columns["Cantidad"] != null)
            {
                dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
                dgvDetalle.Columns["Cantidad"].Width = 80;
            }
            if (dgvDetalle.Columns["Precio"] != null)
            {
                dgvDetalle.Columns["Precio"].HeaderText = "Precio Unit.";
                dgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "N2";
                dgvDetalle.Columns["Precio"].Width = 100;
            }
            if (dgvDetalle.Columns["Subtotal"] != null)
            {
                dgvDetalle.Columns["Subtotal"].HeaderText = "Subtotal";
                dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
                dgvDetalle.Columns["Subtotal"].Width = 100;
            }
        }

        private void LimpiarDetalle()
        {
            dgvDetalle.DataSource = null;
            lblTotalVenta.Text = "Total: $0.00";
        }
    }
}