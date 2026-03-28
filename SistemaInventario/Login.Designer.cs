namespace SistemaInventario
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.labelusuario = new System.Windows.Forms.Label();
            this.labelContra = new System.Windows.Forms.Label();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.txtcontra = new System.Windows.Forms.TextBox();
            this.chkver = new System.Windows.Forms.CheckBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelusuario
            // 
            this.labelusuario.AutoSize = true;
            this.labelusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelusuario.Location = new System.Drawing.Point(242, 45);
            this.labelusuario.Name = "labelusuario";
            this.labelusuario.Size = new System.Drawing.Size(67, 20);
            this.labelusuario.TabIndex = 0;
            this.labelusuario.Text = "Usuario";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContra.Location = new System.Drawing.Point(241, 112);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(95, 20);
            this.labelContra.TabIndex = 1;
            this.labelContra.Text = "Contraseña";
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(348, 44);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(212, 22);
            this.txtusuario.TabIndex = 2;
            // 
            // txtcontra
            // 
            this.txtcontra.Location = new System.Drawing.Point(348, 112);
            this.txtcontra.Name = "txtcontra";
            this.txtcontra.Size = new System.Drawing.Size(212, 22);
            this.txtcontra.TabIndex = 3;
            // 
            // chkver
            // 
            this.chkver.AutoSize = true;
            this.chkver.Location = new System.Drawing.Point(348, 152);
            this.chkver.Name = "chkver";
            this.chkver.Size = new System.Drawing.Size(120, 20);
            this.chkver.TabIndex = 4;
            this.chkver.Text = "Ver contraseña";
            this.chkver.UseVisualStyleBackColor = true;
            this.chkver.CheckedChanged += new System.EventHandler(this.chkVer_CheckedChanged);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(262, 216);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(90, 37);
            this.btnEntrar.TabIndex = 5;
            this.btnEntrar.Text = "Guardar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(452, 216);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 37);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Cerrar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaInventario.Properties.Resources.Imagen_de_login_pers;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(608, 322);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.chkver);
            this.Controls.Add(this.txtcontra);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.labelusuario);
            this.Name = "Login";
            this.Text = "Sistema | Inventario";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelusuario;
        private System.Windows.Forms.Label labelContra;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.TextBox txtcontra;
        private System.Windows.Forms.CheckBox chkver;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

