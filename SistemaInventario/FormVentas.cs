using System;
using System.Data;
using System.Windows.Forms;
using SistemaInventario.Data;

namespace SistemaInventario
{
    public partial class FormVentas : Form
    {
        private DataTable dtDetalle;

        public FormVentas()
        {
            InitializeComponent();

            btnAgregarDetalle.Click += BtnAgregarDetalle_Click;
            btnGuardarVenta.Click   += BtnGuardarVenta_Click;
            btnCancelarVenta.Click  += BtnCancelarVenta_Click;
        }

        // ───────────────────── LOAD ─────────────────────
        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            InicializarDetalle();

            // Conectar eventos DESPUÉS de cargar datos para evitar disparos prematuros
            cbProducto.SelectedIndexChanged += CbProducto_SelectedIndexChanged;
            nudCantidad.ValueChanged        += NudCantidad_ValueChanged;

            // Cargar precio del producto seleccionado por defecto
            CargarPrecioProducto();
            CalcularSubtotal();
        }

        // ───────────────────── CARGAR COMBOS ─────────────────────
        private void CargarClientes()
        {
            var dt = ClienteRepository.GetAll();

            var dtCombo = new DataTable();
            dtCombo.Columns.Add("CodigoCliente", typeof(int));
            dtCombo.Columns.Add("NombreCompleto", typeof(string));

            // Opción sin cliente
            var emptyRow = dtCombo.NewRow();
            emptyRow["CodigoCliente"] = DBNull.Value;
            emptyRow["NombreCompleto"] = "(Sin cliente)";
            dtCombo.Rows.Add(emptyRow);

            foreach (DataRow r in dt.Rows)
            {
                var newRow = dtCombo.NewRow();
                newRow["CodigoCliente"] = r["CodigoCliente"];
                newRow["NombreCompleto"] = r["Nombres"].ToString() + " " + r["Apellidos"].ToString();
                dtCombo.Rows.Add(newRow);
            }

            cbCliente.DataSource    = dtCombo;
            cbCliente.DisplayMember = "NombreCompleto";
            cbCliente.ValueMember   = "CodigoCliente";
        }

        private void CargarProductos()
        {
            var dt = ProductoRepository.GetAll();
            cbProducto.DataSource    = dt;
            cbProducto.DisplayMember = "Nombre";
            cbProducto.ValueMember   = "Codigo";
        }

        // ───────────────────── PRECIO / SUBTOTAL ─────────────────────
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

        // ───────────────────── EVENTOS COMBO / CANTIDAD ─────────────────────
        private void CbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPrecioProducto();
            CalcularSubtotal();
        }

        private void NudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        // ───────────────────── DETALLE ─────────────────────
        private void InicializarDetalle()
        {
            dtDetalle = new DataTable();
            dtDetalle.Columns.Add("ProductoCodigo", typeof(int));
            dtDetalle.Columns.Add("Producto",       typeof(string));
            dtDetalle.Columns.Add("Precio",          typeof(decimal));
            dtDetalle.Columns.Add("Cantidad",        typeof(int));
            dtDetalle.Columns.Add("Subtotal",        typeof(decimal));
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

        // ───────────────────── AGREGAR DETALLE ─────────────────────
        private void BtnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio no es válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = (DataRowView)cbProducto.SelectedItem;
            int productoCodigo   = Convert.ToInt32(drv["Codigo"]);
            string productoNombre = drv["Nombre"].ToString();
            decimal subtotal     = precio * cantidad;

            DataRow newRow = dtDetalle.NewRow();
            newRow["ProductoCodigo"] = productoCodigo;
            newRow["Producto"]       = productoNombre;
            newRow["Precio"]         = precio;
            newRow["Cantidad"]       = cantidad;
            newRow["Subtotal"]       = subtotal;
            dtDetalle.Rows.Add(newRow);

            ConfigurarColumnasDetalle();
            CalcularTotal();

            // Resetear cantidad
            nudCantidad.Value = 1;
        }

        // ───────────────────── GUARDAR VENTA ─────────────────────
        private void BtnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al detalle.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? clienteId = null;
            if (cbCliente.SelectedValue != null && cbCliente.SelectedValue != DBNull.Value)
            {
                clienteId = Convert.ToInt32(cbCliente.SelectedValue);
            }

            decimal total = CalcularTotal();

            try
            {
                // 1. Insertar cabecera de venta
                int ventaId = VentaRepository.InsertVenta(clienteId, total);

                // 2. Insertar cada línea de detalle
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

        // ───────────────────── CANCELAR ─────────────────────
        private void BtnCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }

        // ───────────────────── LIMPIAR ─────────────────────
        private void LimpiarVenta()
        {
            cbCliente.SelectedIndex = 0;
            if (cbProducto.Items.Count > 0)
                cbProducto.SelectedIndex = 0;

            txtPrecio.Text   = "0.00";
            txtSubtotal.Text = "0.00";
            nudCantidad.Value = 1;

            dtDetalle.Rows.Clear();
            lblTotal.Text = "Total: $0.00";

            CargarPrecioProducto();
            CalcularSubtotal();
        }
    }
}
