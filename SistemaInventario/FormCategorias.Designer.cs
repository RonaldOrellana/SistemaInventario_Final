namespace SistemaInventario
{
    partial class FormCategorias
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
            this.ntnnuevo = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dgvcategorias = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // ntnnuevo
            // 
            this.ntnnuevo.Location = new System.Drawing.Point(26, 61);
            this.ntnnuevo.Name = "ntnnuevo";
            this.ntnnuevo.Size = new System.Drawing.Size(85, 40);
            this.ntnnuevo.TabIndex = 0;
            this.ntnnuevo.Text = "Nuevo";
            this.ntnnuevo.UseVisualStyleBackColor = true;
            // 
            // btnmodificar
            // 
            this.btnmodificar.Location = new System.Drawing.Point(134, 61);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(85, 40);
            this.btnmodificar.TabIndex = 1;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = true;
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(245, 61);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(85, 40);
            this.btneliminar.TabIndex = 2;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(71, 337);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(85, 40);
            this.btnguardar.TabIndex = 3;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(201, 337);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(85, 40);
            this.btncancelar.TabIndex = 4;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Codigo Categoria";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripcion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 159);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(166, 242);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(178, 22);
            this.textBox2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvcategorias);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(350, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 426);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de categorias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(129, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(232, 27);
            this.textBox3.TabIndex = 1;
            // 
            // dgvcategorias
            // 
            this.dgvcategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcategorias.Location = new System.Drawing.Point(23, 118);
            this.dgvcategorias.Name = "dgvcategorias";
            this.dgvcategorias.RowHeadersWidth = 51;
            this.dgvcategorias.RowTemplate.Height = 24;
            this.dgvcategorias.Size = new System.Drawing.Size(338, 286);
            this.dgvcategorias.TabIndex = 9;
            // 
            // FormCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(754, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.ntnnuevo);
            this.Name = "FormCategorias";
            this.Text = "Inventario | Categorias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ntnnuevo;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvcategorias;
    }
}