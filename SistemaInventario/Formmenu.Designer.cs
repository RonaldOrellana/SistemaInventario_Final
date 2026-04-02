namespace SistemaInventario
{
    partial class Formmenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formmenu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picVentas = new System.Windows.Forms.PictureBox();
            this.picClientes = new System.Windows.Forms.PictureBox();
            this.picProducto = new System.Windows.Forms.PictureBox();
            this.picCategoria = new System.Windows.Forms.PictureBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblcantpro = new System.Windows.Forms.Label();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblcantv = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltotal = new System.Windows.Forms.Label();
            this.Panel15 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.Panel12 = new System.Windows.Forms.Panel();
            this.btncreacuent = new System.Windows.Forms.Panel();
            this.btnlistacuenta = new System.Windows.Forms.Panel();
            this.Label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoria)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Categorias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Productos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(436, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clientes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(626, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ventas";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // picVentas
            // 
            this.picVentas.Image = global::SistemaInventario.Properties.Resources.Imagen_para_ventas;
            this.picVentas.Location = new System.Drawing.Point(630, 3);
            this.picVentas.Name = "picVentas";
            this.picVentas.Size = new System.Drawing.Size(136, 126);
            this.picVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVentas.TabIndex = 3;
            this.picVentas.TabStop = false;
            this.picVentas.Click += new System.EventHandler(this.picVentas_Click);
            // 
            // picClientes
            // 
            this.picClientes.Image = global::SistemaInventario.Properties.Resources.Imagen_para_clientes;
            this.picClientes.Location = new System.Drawing.Point(435, 3);
            this.picClientes.Name = "picClientes";
            this.picClientes.Size = new System.Drawing.Size(144, 126);
            this.picClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClientes.TabIndex = 2;
            this.picClientes.TabStop = false;
            this.picClientes.Click += new System.EventHandler(this.picClientes_Click);
            // 
            // picProducto
            // 
            this.picProducto.Image = global::SistemaInventario.Properties.Resources.Imagen_para_producto;
            this.picProducto.Location = new System.Drawing.Point(217, 3);
            this.picProducto.Name = "picProducto";
            this.picProducto.Size = new System.Drawing.Size(140, 126);
            this.picProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProducto.TabIndex = 1;
            this.picProducto.TabStop = false;
            this.picProducto.Click += new System.EventHandler(this.picProducto_Click);
            // 
            // picCategoria
            // 
            this.picCategoria.Image = global::SistemaInventario.Properties.Resources.Imagen_para_categorí1;
            this.picCategoria.Location = new System.Drawing.Point(3, 3);
            this.picCategoria.Name = "picCategoria";
            this.picCategoria.Size = new System.Drawing.Size(137, 126);
            this.picCategoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCategoria.TabIndex = 0;
            this.picCategoria.TabStop = false;
            this.picCategoria.Click += new System.EventHandler(this.picCategoria_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblcantpro);
            this.panel2.Controls.Add(this.Panel6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 122);
            this.panel2.TabIndex = 9;
            // 
            // lblcantpro
            // 
            this.lblcantpro.AutoSize = true;
            this.lblcantpro.Location = new System.Drawing.Point(183, 64);
            this.lblcantpro.Name = "lblcantpro";
            this.lblcantpro.Size = new System.Drawing.Size(48, 16);
            this.lblcantpro.TabIndex = 8;
            this.lblcantpro.Text = "Label9";
            // 
            // Panel6
            // 
            this.Panel6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel6.BackgroundImage")));
            this.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel6.Location = new System.Drawing.Point(3, 3);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(133, 116);
            this.Panel6.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(142, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "PRODUCTOS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblcantv);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(472, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 122);
            this.panel1.TabIndex = 10;
            // 
            // lblcantv
            // 
            this.lblcantv.AutoSize = true;
            this.lblcantv.Location = new System.Drawing.Point(193, 64);
            this.lblcantv.Name = "lblcantv";
            this.lblcantv.Size = new System.Drawing.Size(53, 16);
            this.lblcantv.TabIndex = 8;
            this.lblcantv.Text = "lblcantv";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(170, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "VENTAS";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbltotal);
            this.panel3.Controls.Add(this.Panel15);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(241, 368);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 122);
            this.panel3.TabIndex = 11;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(184, 74);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(55, 16);
            this.lbltotal.TabIndex = 10;
            this.lbltotal.Text = "Label10";
            // 
            // Panel15
            // 
            this.Panel15.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Panel15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel15.BackgroundImage")));
            this.Panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel15.Location = new System.Drawing.Point(-1, 0);
            this.Panel15.Name = "Panel15";
            this.Panel15.Size = new System.Drawing.Size(138, 119);
            this.Panel15.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(155, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "INGRESOS";
            // 
            // Panel12
            // 
            this.Panel12.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Panel12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel12.BackgroundImage")));
            this.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel12.Location = new System.Drawing.Point(471, 240);
            this.Panel12.Name = "Panel12";
            this.Panel12.Size = new System.Drawing.Size(159, 122);
            this.Panel12.TabIndex = 2;
            // 
            // btncreacuent
            // 
            this.btncreacuent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncreacuent.BackgroundImage")));
            this.btncreacuent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncreacuent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncreacuent.Location = new System.Drawing.Point(585, 144);
            this.btncreacuent.Name = "btncreacuent";
            this.btncreacuent.Size = new System.Drawing.Size(67, 49);
            this.btncreacuent.TabIndex = 13;
            this.btncreacuent.Click += new System.EventHandler(this.btncreacuent_Click);
            this.btncreacuent.Paint += new System.Windows.Forms.PaintEventHandler(this.btncreacuent_Paint);
            // 
            // btnlistacuenta
            // 
            this.btnlistacuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnlistacuenta.BackgroundImage")));
            this.btnlistacuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnlistacuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlistacuenta.Enabled = true;
            this.btnlistacuenta.Location = new System.Drawing.Point(698, 144);
            this.btnlistacuenta.Name = "btnlistacuenta";
            this.btnlistacuenta.Size = new System.Drawing.Size(67, 49);
            this.btnlistacuenta.TabIndex = 14;
            this.btnlistacuenta.Visible = false;
            this.btnlistacuenta.Click += new System.EventHandler(this.btnlistacuenta_Click);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label14.Location = new System.Drawing.Point(582, 196);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(82, 16);
            this.Label14.TabIndex = 16;
            this.Label14.Text = "Añadir venta";
            this.Label14.Visible = false;
            this.Label14.Click += new System.EventHandler(this.Label14_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Location = new System.Drawing.Point(695, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Listado de Ventas";
            this.label8.Visible = false;
            // 
            // Formmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.btnlistacuenta);
            this.Controls.Add(this.btncreacuent);
            this.Controls.Add(this.Panel12);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picVentas);
            this.Controls.Add(this.picClientes);
            this.Controls.Add(this.picProducto);
            this.Controls.Add(this.picCategoria);
            this.Name = "Formmenu";
            this.Text = "Formenu";
            ((System.ComponentModel.ISupportInitialize)(this.picVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoria)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCategoria;
        private System.Windows.Forms.PictureBox picProducto;
        private System.Windows.Forms.PictureBox picClientes;
        private System.Windows.Forms.PictureBox picVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Panel Panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Panel Panel12;
        internal System.Windows.Forms.Label lblcantpro;
        internal System.Windows.Forms.Label lblcantv;
        internal System.Windows.Forms.Label lbltotal;
        internal System.Windows.Forms.Panel Panel15;
        internal System.Windows.Forms.Panel btncreacuent;
        internal System.Windows.Forms.Panel btnlistacuenta;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label label8;
    }
}