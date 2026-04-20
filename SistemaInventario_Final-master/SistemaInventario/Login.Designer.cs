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
            this.labelusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelusuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelusuario.Location = new System.Drawing.Point(96, 247);
            this.labelusuario.Name = "labelusuario";
            this.labelusuario.Size = new System.Drawing.Size(67, 20);
            this.labelusuario.TabIndex = 0;
            this.labelusuario.Text = "Usuario";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelContra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelContra.Location = new System.Drawing.Point(96, 316);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(95, 20);
            this.labelContra.TabIndex = 1;
            this.labelContra.Text = "Contraseña";
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(201, 245);
            this.txtusuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(212, 22);
            this.txtusuario.TabIndex = 2;
            // 
            // txtcontra
            // 
            this.txtcontra.Location = new System.Drawing.Point(203, 316);
            this.txtcontra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcontra.Name = "txtcontra";
            this.txtcontra.Size = new System.Drawing.Size(212, 22);
            this.txtcontra.TabIndex = 3;
            // 
            // chkver
            // 
            this.chkver.AutoSize = true;
            this.chkver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkver.Location = new System.Drawing.Point(201, 351);
            this.chkver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkver.Name = "chkver";
            this.chkver.Size = new System.Drawing.Size(120, 20);
            this.chkver.TabIndex = 4;
            this.chkver.Text = "Ver contraseña";
            this.chkver.UseVisualStyleBackColor = true;
            this.chkver.CheckedChanged += new System.EventHandler(this.chkVer_CheckedChanged);
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.Green;
            this.btnEntrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEntrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEntrar.Location = new System.Drawing.Point(100, 424);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(115, 37);
            this.btnEntrar.TabIndex = 5;
            this.btnEntrar.Text = "Iniciar Sesion";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalir.Location = new System.Drawing.Point(298, 424);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(115, 37);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Cerrar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaInventario.Properties.Resources.acceso__1_;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(159, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(506, 508);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.chkver);
            this.Controls.Add(this.txtcontra);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.labelusuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Inventario | Login";
            this.TopMost = true;
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

