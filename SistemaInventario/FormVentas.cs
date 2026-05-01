using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaInventario.Data;

namespace SistemaInventario
{
    public partial class FormVentas : Form
    {
        private DataTable dtDetalle;
        private DataTable dtProductos;

        public FormVentas()
        {
            InitializeComponent();

            btnAgregarDetalle.Click += BtnAgregarDetalle_Click;
            btnGuardarVenta.Click += BtnGuardarVenta_Click;
            btnCancelarVenta.Click += BtnCancelarVenta_Click;

            cbProducto.DrawMode = DrawMode.OwnerDrawFixed;
            cbProducto.ItemHeight = 18;
            cbProducto.DrawItem += CbProducto_DrawItem;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            InicializarDetalle();

            cbProducto.SelectedIndexChanged += CbProducto_SelectedIndexChanged;
            nudCantidad.ValueChanged += NudCantidad_ValueChanged;

            CargarPrecioProducto();
            ActualizarEstadoProductoSeleccionado();
            CalcularSubtotal();
        }

        private void CargarClientes()
        {
            var dt = ClienteRepository.GetAll();

            var dtCombo = new DataTable();
            dtCombo.Columns.Add("CodigoCliente", typeof(int));
            dtCombo.Columns.Add("NombreCompleto", typeof(string));

            foreach (DataRow r in dt.Rows)
            {
                var newRow = dtCombo.NewRow();
                newRow["CodigoCliente"] = r["CodigoCliente"];
                newRow["NombreCompleto"] = r["Nombres"].ToString() + " " + r["Apellidos"].ToString();
                dtCombo.Rows.Add(newRow);
            }

            cbCliente.DataSource = dtCombo;
            cbCliente.DisplayMember = "NombreCompleto";
            cbCliente.ValueMember = "CodigoCliente";

            cbCliente.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            dtProductos = ProductoRepository.GetAll();
            cbProducto.DataSource = dtProductos;
            cbProducto.DisplayMember = "Nombre";
            cbProducto.ValueMember = "Codigo";
        }

        private void CargarPrecioProducto()
        {
            if (cbProducto.SelectedItem is DataRowView drv &&
                drv["Precio"] != null && drv["Precio"] != DBNull.Value)
            {
                txtPrecio.Text = Convert.ToDecimal(drv["Precio"]).ToString("N2");
            }
            else
            {
                txtPrecio.Text = "0.00";
            }
        }

        private void CalcularSubtotal()
        {
            if (decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                decimal subtotal = precio * nudCantidad.Value;
                txtSubtotal.Text = subtotal.ToString("N2");
            }
            else
            {
                txtSubtotal.Text = "0.00";
            }
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in dtDetalle.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            lblTotal.Text = "Total: $" + total.ToString("N2");
            return total;
        }

        private void CbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPrecioProducto();
            ActualizarEstadoProductoSeleccionado();
            CalcularSubtotal();
        }

        private void NudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void InicializarDetalle()
        {
            dtDetalle = new DataTable();
            dtDetalle.Columns.Add("ProductoCodigo", typeof(int));
            dtDetalle.Columns.Add("Producto", typeof(string));
            dtDetalle.Columns.Add("Precio", typeof(decimal));
            dtDetalle.Columns.Add("Cantidad", typeof(int));
            dtDetalle.Columns.Add("Subtotal", typeof(decimal));
            dgvDetalleVenta.DataSource = dtDetalle;

            ConfigurarColumnasDetalle();
        }

        private void ConfigurarColumnasDetalle()
        {
            if (dgvDetalleVenta.Columns["ProductoCodigo"] != null)
            {
                dgvDetalleVenta.Columns["ProductoCodigo"].HeaderText = "Código";
                dgvDetalleVenta.Columns["ProductoCodigo"].Width = 65;
            }
            if (dgvDetalleVenta.Columns["Producto"] != null)
            {
                dgvDetalleVenta.Columns["Producto"].HeaderText = "Producto";
                dgvDetalleVenta.Columns["Producto"].Width = 180;
            }
            if (dgvDetalleVenta.Columns["Precio"] != null)
            {
                dgvDetalleVenta.Columns["Precio"].HeaderText = "Precio";
                dgvDetalleVenta.Columns["Precio"].DefaultCellStyle.Format = "N2";
                dgvDetalleVenta.Columns["Precio"].Width = 80;
            }
            if (dgvDetalleVenta.Columns["Cantidad"] != null)
            {
                dgvDetalleVenta.Columns["Cantidad"].HeaderText = "Cantidad";
                dgvDetalleVenta.Columns["Cantidad"].Width = 70;
            }
            if (dgvDetalleVenta.Columns["Subtotal"] != null)
            {
                dgvDetalleVenta.Columns["Subtotal"].HeaderText = "Subtotal";
                dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
                dgvDetalleVenta.Columns["Subtotal"].Width = 90;
            }
        }

        private void BtnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = (DataRowView)cbProducto.SelectedItem;
            int productoCodigo = Convert.ToInt32(drv["Codigo"]);
            string productoNombre = drv["Nombre"].ToString();
            int stockDisponible = ObtenerStockProductoSeleccionado();
            int cantidadYaAgregada = ObtenerCantidadEnDetalle(productoCodigo);
            int cantidadTotalSolicitada = cantidadYaAgregada + cantidad;

            if (stockDisponible <= 0)
            {
                MessageBox.Show("No se puede guardar la venta por que el producto no tiene stock", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidadTotalSolicitada > stockDisponible)
            {
                MessageBox.Show("La cantidad solicitada supera el stock disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow filaExistente = ObtenerFilaDetalle(productoCodigo);
            decimal subtotal = precio * cantidadTotalSolicitada;

            if (filaExistente != null)
            {
                filaExistente["Cantidad"] = cantidadTotalSolicitada;
                filaExistente["Subtotal"] = precio * cantidadTotalSolicitada;
            }
            else
            {
                DataRow newRow = dtDetalle.NewRow();
                newRow["ProductoCodigo"] = productoCodigo;
                newRow["Producto"] = productoNombre;
                newRow["Precio"] = precio;
                newRow["Cantidad"] = cantidad;
                newRow["Subtotal"] = subtotal;
                dtDetalle.Rows.Add(newRow);
            }

            ConfigurarColumnasDetalle();
            CalcularTotal();

            nudCantidad.Value = 1;
            ActualizarEstadoProductoSeleccionado();
        }

        private void BtnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex < 0 ||
                cbCliente.SelectedValue == null ||
                cbCliente.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Debe seleccionar un cliente para poder guardar la venta.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al detalle.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarStockAntesDeGuardar())
                return;

            int clienteId = Convert.ToInt32(cbCliente.SelectedValue);
            decimal total = CalcularTotal();

            try
            {
                int ventaId = VentaRepository.InsertVenta(clienteId, total);

                foreach (DataRow row in dtDetalle.Rows)
                {
                    VentaRepository.InsertDetalle(
                        ventaId,
                        Convert.ToInt32(row["ProductoCodigo"]),
                        Convert.ToInt32(row["Cantidad"]),
                        Convert.ToDecimal(row["Precio"]),
                        Convert.ToDecimal(row["Subtotal"])
                    );
                }

                MessageBox.Show("Venta guardada correctamente.\nN° Venta: " + ventaId,
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }

        private void LimpiarVenta()
        {
            cbCliente.SelectedIndex = -1;

            if (cbProducto.Items.Count > 0)
                cbProducto.SelectedIndex = 0;
            else
                cbProducto.SelectedIndex = -1;

            txtPrecio.Text = "0.00";
            txtSubtotal.Text = "0.00";
            nudCantidad.Value = 1;

            dtDetalle.Rows.Clear();
            lblTotal.Text = "Total: $0.00";

            CargarPrecioProducto();
            ActualizarEstadoProductoSeleccionado();
            CalcularSubtotal();
        }

        private int ObtenerCodigoProductoSeleccionado()
        {
            if (cbProducto.SelectedItem is DataRowView drv && drv["Codigo"] != DBNull.Value)
            {
                return Convert.ToInt32(drv["Codigo"]);
            }

            return 0;
        }

        private int ObtenerStockProductoSeleccionado()
        {
            if (cbProducto.SelectedItem is DataRowView drv && drv["Stock"] != DBNull.Value)
            {
                int stock;
                if (int.TryParse(drv["Stock"].ToString(), out stock))
                    return stock;
            }

            return 0;
        }

        private int ObtenerCantidadEnDetalle(int productoCodigo)
        {
            int total = 0;

            foreach (DataRow row in dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["ProductoCodigo"]) == productoCodigo)
                {
                    total += Convert.ToInt32(row["Cantidad"]);
                }
            }

            return total;
        }

        private DataRow ObtenerFilaDetalle(int productoCodigo)
        {
            foreach (DataRow row in dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["ProductoCodigo"]) == productoCodigo)
                    return row;
            }

            return null;
        }

        private void ActualizarEstadoProductoSeleccionado()
        {
            int productoCodigo = ObtenerCodigoProductoSeleccionado();
            int stockDisponible = ObtenerStockProductoSeleccionado();

            if (productoCodigo > 0)
            {
                int yaAgregado = ObtenerCantidadEnDetalle(productoCodigo);
                stockDisponible -= yaAgregado;
            }

            bool habilitar = stockDisponible > 0;

            nudCantidad.Enabled = habilitar;
            btnAgregarDetalle.Enabled = productoCodigo > 0;

            if (habilitar)
            {
                nudCantidad.Maximum = stockDisponible;
                if (nudCantidad.Value < nudCantidad.Minimum)
                    nudCantidad.Value = nudCantidad.Minimum;
                if (nudCantidad.Value > nudCantidad.Maximum)
                    nudCantidad.Value = nudCantidad.Maximum;
            }
            else
            {
                nudCantidad.Value = 1;
            }
        }

        private bool ValidarStockAntesDeGuardar()
        {
            if (dtProductos == null)
                return true;

            var stockPorProducto = new Dictionary<int, int>();
            foreach (DataRow row in dtProductos.Rows)
            {
                int codigo = Convert.ToInt32(row["Codigo"]);
                int stock = 0;

                if (row["Stock"] != DBNull.Value)
                    int.TryParse(row["Stock"].ToString(), out stock);

                stockPorProducto[codigo] = stock;
            }

            var solicitadoPorProducto = new Dictionary<int, int>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                int codigo = Convert.ToInt32(row["ProductoCodigo"]);
                int cantidad = Convert.ToInt32(row["Cantidad"]);

                if (solicitadoPorProducto.ContainsKey(codigo))
                    solicitadoPorProducto[codigo] += cantidad;
                else
                    solicitadoPorProducto[codigo] = cantidad;
            }

            foreach (var item in solicitadoPorProducto)
            {
                int stockDisponible = 0;
                stockPorProducto.TryGetValue(item.Key, out stockDisponible);

                if (stockDisponible <= 0)
                {
                    MessageBox.Show("No se puede guardar la venta por que el producto no tiene stock", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (item.Value > stockDisponible)
                {
                    MessageBox.Show("No se puede guardar la venta porque la cantidad supera el stock disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void CbProducto_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0)
            {
                e.DrawFocusRectangle();
                return;
            }

            var item = cbProducto.Items[e.Index] as DataRowView;
            if (item == null)
            {
                e.DrawFocusRectangle();
                return;
            }

            string nombre = item["Nombre"].ToString();
            int stock = 0;
            if (item["Stock"] != DBNull.Value)
                int.TryParse(item["Stock"].ToString(), out stock);

            Color fondo;
            if (stock <= 0)
                fondo = Color.LightCoral;
            else if (stock <= 2)
                fondo = Color.Khaki;
            else
                fondo = cbProducto.BackColor;

            using (var brush = new SolidBrush(fondo))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                nombre + " - Stock: " + stock,
                e.Font,
                e.Bounds,
                Color.Black,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            e.DrawFocusRectangle();
        }
    }
}
