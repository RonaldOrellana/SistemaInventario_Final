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
            this.picVentas = new System.Windows.Forms.PictureBox();
            this.picClientes = new System.Windows.Forms.PictureBox();
            this.picProducto = new System.Windows.Forms.PictureBox();
            this.picCategoria = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // picVentas
            // 
            this.picVentas.Image = global::SistemaInventario.Properties.Resources.Imagen_para_ventas;
            this.picVentas.Location = new System.Drawing.Point(659, 3);
            this.picVentas.Name = "picVentas";
            this.picVentas.Size = new System.Drawing.Size(107, 105);
            this.picVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVentas.TabIndex = 3;
            this.picVentas.TabStop = false;
            this.picVentas.Click += new System.EventHandler(this.picVentas_Click);
            // 
            // picClientes
            // 
            this.picClientes.Image = global::SistemaInventario.Properties.Resources.Imagen_para_clientes;
            this.picClientes.Location = new System.Drawing.Point(462, 3);
            this.picClientes.Name = "picClientes";
            this.picClientes.Size = new System.Drawing.Size(107, 105);
            this.picClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClientes.TabIndex = 2;
            this.picClientes.TabStop = false;
            this.picClientes.Click += new System.EventHandler(this.picClientes_Click);
            // 
            // picProducto
            // 
            this.picProducto.Image = global::SistemaInventario.Properties.Resources.Imagen_para_producto;
            this.picProducto.Location = new System.Drawing.Point(244, 3);
            this.picProducto.Name = "picProducto";
            this.picProducto.Size = new System.Drawing.Size(107, 105);
            this.picProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProducto.TabIndex = 1;
            this.picProducto.TabStop = false;
            this.picProducto.Click += new System.EventHandler(this.picProducto_Click);
            // 
            // picCategoria
            // 
            this.picCategoria.Image = global::SistemaInventario.Properties.Resources.Imagen_para_categorí1;
            this.picCategoria.Location = new System.Drawing.Point(29, 3);
            this.picCategoria.Name = "picCategoria";
            this.picCategoria.Size = new System.Drawing.Size(107, 105);
            this.picCategoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCategoria.TabIndex = 0;
            this.picCategoria.TabStop = false;
            this.picCategoria.Click += new System.EventHandler(this.picCategoria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Categorias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Productos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(458, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clientes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(655, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ventas";
            // 
            // Formmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 502);
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
    }
}