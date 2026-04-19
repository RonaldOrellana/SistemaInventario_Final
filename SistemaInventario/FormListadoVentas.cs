using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaInventario.Data;

namespace SistemaInventario
{
    public partial class FormListadoVentas : Form
    {
        private GroupBox groupBoxVentas;
        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnActualizar;
        private DataGridView dgvVentas;
        private GroupBox groupBoxDetalle;
        private DataGridView dgvDetalle;
        private Label lblTotalVenta;
        private System.ComponentModel.IContainer components = null;

        public FormListadoVentas()
        {
            InitializeComponent();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            dgvVentas.CellClick += DgvVentas_CellClick;
            btnActualizar.Click += BtnActualizar_Click;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListadoVentas));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.groupBoxVentas = new System.Windows.Forms.GroupBox();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.groupBoxVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(16, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Listado de Ventas";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(18, 51);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 16);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(76, 48);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(769, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(860, 44);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(200, 30);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // groupBoxVentas
            // 
            this.groupBoxVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVentas.Controls.Add(this.dgvVentas);
            this.groupBoxVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxVentas.Location = new System.Drawing.Point(10, 73);
            this.groupBoxVentas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxVentas.Name = "groupBoxVentas";
            this.groupBoxVentas.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxVentas.Size = new System.Drawing.Size(634, 203);
            this.groupBoxVentas.TabIndex = 1;
            this.groupBoxVentas.TabStop = false;
            this.groupBoxVentas.Text = "Ventas";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AllowUserToResizeRows = false;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(2, 18);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(630, 183);
            this.dgvVentas.TabIndex = 0;
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetalle.Controls.Add(this.dgvDetalle);
            this.groupBoxDetalle.Controls.Add(this.lblTotalVenta);
            this.groupBoxDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetalle.Location = new System.Drawing.Point(10, 286);
            this.groupBoxDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDetalle.Size = new System.Drawing.Size(632, 233);
            this.groupBoxDetalle.TabIndex = 2;
            this.groupBoxDetalle.TabStop = false;
            this.groupBoxDetalle.Text = "Detalle de la venta";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDetalle.Location = new System.Drawing.Point(2, 18);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(628, 183);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalVenta.Location = new System.Drawing.Point(12, 203);
            this.lblTotalVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(97, 17);
            this.lblTotalVenta.TabIndex = 1;
            this.lblTotalVenta.Text = "Total Venta:";
            // 
            // FormListadoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(654, 531);
            this.Controls.Add(this.groupBoxDetalle);
            this.Controls.Add(this.groupBoxVentas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormListadoVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de inventario | Listado_Ventas";
            this.Load += new System.EventHandler(this.FormListadoVentas_Load);
            this.groupBoxVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.groupBoxDetalle.ResumeLayout(false);
            this.groupBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        private void FormListadoVentas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarVentas();
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

            object totalValue = row.Cells["Total"].Value;
            decimal total = totalValue != null && totalValue != DBNull.Value
                ? Convert.ToDecimal(totalValue)
                : 0m;

            lblTotalVenta.Text = "Total Venta: $" + total.ToString("N2");
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
            lblTotalVenta.Text = "Total Venta: $0.00";
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
