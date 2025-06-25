namespace Vistas.Pagos
{
    partial class GestionPago
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
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.DNI = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPrestamos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            this.btnPagar = new System.Windows.Forms.Button();
            this.cmbCuotas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfoCuota = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(281, 151);
            this.cmbClientes.Margin = new System.Windows.Forms.Padding(7);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(457, 37);
            this.cmbClientes.TabIndex = 22;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.Location = new System.Drawing.Point(58, 154);
            this.DNI.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(89, 29);
            this.DNI.TabIndex = 21;
            this.DNI.Text = "Cliente";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Enabled = false;
            this.dtpFechaPago.Location = new System.Drawing.Point(281, 75);
            this.dtpFechaPago.Margin = new System.Windows.Forms.Padding(7);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(461, 35);
            this.dtpFechaPago.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha";
            // 
            // cmbPrestamos
            // 
            this.cmbPrestamos.FormattingEnabled = true;
            this.cmbPrestamos.Location = new System.Drawing.Point(1134, 151);
            this.cmbPrestamos.Margin = new System.Windows.Forms.Padding(7);
            this.cmbPrestamos.Name = "cmbPrestamos";
            this.cmbPrestamos.Size = new System.Drawing.Size(457, 37);
            this.cmbPrestamos.TabIndex = 26;
            this.cmbPrestamos.SelectedIndexChanged += new System.EventHandler(this.cmbPrestamos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(834, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Prestamos Pendientes";
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Location = new System.Drawing.Point(63, 296);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.RowTemplate.Height = 37;
            this.dgvCuotas.Size = new System.Drawing.Size(1489, 463);
            this.dgvCuotas.TabIndex = 27;
            this.dgvCuotas.SelectionChanged += new System.EventHandler(this.dgvCuotas_SelectionChanged);
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(936, 816);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(209, 67);
            this.btnPagar.TabIndex = 28;
            this.btnPagar.Text = "Pagar Cuota";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // cmbCuotas
            // 
            this.cmbCuotas.FormattingEnabled = true;
            this.cmbCuotas.Location = new System.Drawing.Point(59, 832);
            this.cmbCuotas.Margin = new System.Windows.Forms.Padding(7);
            this.cmbCuotas.Name = "cmbCuotas";
            this.cmbCuotas.Size = new System.Drawing.Size(182, 37);
            this.cmbCuotas.TabIndex = 29;
            this.cmbCuotas.Visible = false;
            this.cmbCuotas.SelectedIndexChanged += new System.EventHandler(this.cmbCuotas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Seleccionar cuota a pagar";
            // 
            // lblInfoCuota
            // 
            this.lblInfoCuota.AutoSize = true;
            this.lblInfoCuota.Location = new System.Drawing.Point(319, 832);
            this.lblInfoCuota.Name = "lblInfoCuota";
            this.lblInfoCuota.Size = new System.Drawing.Size(19, 29);
            this.lblInfoCuota.TabIndex = 31;
            this.lblInfoCuota.Text = " ";
            // 
            // GestionPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1679, 1235);
            this.Controls.Add(this.lblInfoCuota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCuotas);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.dgvCuotas);
            this.Controls.Add(this.cmbPrestamos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaPago);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.DNI);
            this.Name = "GestionPago";
            this.Text = "GestionPago";
            this.Load += new System.EventHandler(this.GestionPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPrestamos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCuotas;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.ComboBox cmbCuotas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfoCuota;
    }
}