namespace Vistas
{
    partial class MainOperador
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnGestionPagos = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnVerPrestamos = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logout
            // 
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(41, 20);
            this.logout.Text = "Salir";
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnGestionPagos);
            this.groupBox6.Location = new System.Drawing.Point(405, 40);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(173, 74);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pagos";
            // 
            // btnGestionPagos
            // 
            this.btnGestionPagos.Location = new System.Drawing.Point(20, 29);
            this.btnGestionPagos.Name = "btnGestionPagos";
            this.btnGestionPagos.Size = new System.Drawing.Size(128, 30);
            this.btnGestionPagos.TabIndex = 1;
            this.btnGestionPagos.Text = "Gestion de Pagos";
            this.btnGestionPagos.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnVerPrestamos);
            this.groupBox5.Controls.Add(this.btnAlta);
            this.groupBox5.Location = new System.Drawing.Point(208, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(173, 130);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Prestamos";
            // 
            // btnVerPrestamos
            // 
            this.btnVerPrestamos.Location = new System.Drawing.Point(20, 79);
            this.btnVerPrestamos.Name = "btnVerPrestamos";
            this.btnVerPrestamos.Size = new System.Drawing.Size(128, 30);
            this.btnVerPrestamos.TabIndex = 2;
            this.btnVerPrestamos.Text = "Ver Prestamos";
            this.btnVerPrestamos.UseVisualStyleBackColor = true;
            this.btnVerPrestamos.Click += new System.EventHandler(this.btnVerPrestamos_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(20, 29);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(128, 30);
            this.btnAlta.TabIndex = 1;
            this.btnAlta.Text = "Registrar Prestamo";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGestionClientes);
            this.groupBox4.Location = new System.Drawing.Point(12, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 74);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Clientes";
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.Location = new System.Drawing.Point(20, 29);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Size = new System.Drawing.Size(128, 30);
            this.btnGestionClientes.TabIndex = 1;
            this.btnGestionClientes.Text = "Gestion Clientes";
            this.btnGestionClientes.UseVisualStyleBackColor = true;
            this.btnGestionClientes.Click += new System.EventHandler(this.btnGestionClientes_Click);
            // 
            // MainOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 222);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainOperador";
            this.Text = "MainOperador";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logout;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnGestionPagos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button btnVerPrestamos;
    }
}