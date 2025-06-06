namespace Vistas.Prestamos
{
    partial class Alta
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
            this.DNI = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaPrestamo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            this.comboClientes = new System.Windows.Forms.ComboBox();
            this.comboPeriodo = new System.Windows.Forms.ComboBox();
            this.numImporte = new System.Windows.Forms.NumericUpDown();
            this.numCuotas = new System.Windows.Forms.NumericUpDown();
            this.txtTasaInteres = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.Location = new System.Drawing.Point(18, 30);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(39, 13);
            this.DNI.TabIndex = 2;
            this.DNI.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Periodo de Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha";
            // 
            // fechaPrestamo
            // 
            this.fechaPrestamo.Enabled = false;
            this.fechaPrestamo.Location = new System.Drawing.Point(111, 138);
            this.fechaPrestamo.Name = "fechaPrestamo";
            this.fechaPrestamo.Size = new System.Drawing.Size(200, 20);
            this.fechaPrestamo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Importe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tasa Interes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cuotas ";
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(111, 298);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(198, 20);
            this.txtEstado.TabIndex = 17;
            this.txtEstado.Text = "PENDIENTE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Estado";
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(80, 339);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(162, 40);
            this.btnAlta.TabIndex = 18;
            this.btnAlta.Text = "Registrar Prestamo";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // comboDestino
            // 
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(113, 63);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(198, 21);
            this.comboDestino.TabIndex = 19;
            // 
            // comboClientes
            // 
            this.comboClientes.FormattingEnabled = true;
            this.comboClientes.Location = new System.Drawing.Point(112, 27);
            this.comboClientes.Name = "comboClientes";
            this.comboClientes.Size = new System.Drawing.Size(198, 21);
            this.comboClientes.TabIndex = 20;
            // 
            // comboPeriodo
            // 
            this.comboPeriodo.FormattingEnabled = true;
            this.comboPeriodo.Location = new System.Drawing.Point(113, 103);
            this.comboPeriodo.Name = "comboPeriodo";
            this.comboPeriodo.Size = new System.Drawing.Size(198, 21);
            this.comboPeriodo.TabIndex = 21;
            // 
            // numImporte
            // 
            this.numImporte.DecimalPlaces = 2;
            this.numImporte.Location = new System.Drawing.Point(113, 181);
            this.numImporte.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numImporte.Name = "numImporte";
            this.numImporte.Size = new System.Drawing.Size(198, 20);
            this.numImporte.TabIndex = 22;
            // 
            // numCuotas
            // 
            this.numCuotas.Location = new System.Drawing.Point(113, 259);
            this.numCuotas.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numCuotas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCuotas.Name = "numCuotas";
            this.numCuotas.Size = new System.Drawing.Size(198, 20);
            this.numCuotas.TabIndex = 23;
            this.numCuotas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Enabled = false;
            this.txtTasaInteres.Location = new System.Drawing.Point(111, 223);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.Size = new System.Drawing.Size(199, 20);
            this.txtTasaInteres.TabIndex = 24;
            this.txtTasaInteres.Text = "20%";
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 392);
            this.Controls.Add(this.txtTasaInteres);
            this.Controls.Add(this.numCuotas);
            this.Controls.Add(this.numImporte);
            this.Controls.Add(this.comboPeriodo);
            this.Controls.Add(this.comboClientes);
            this.Controls.Add(this.comboDestino);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fechaPrestamo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DNI);
            this.Name = "Alta";
            this.Text = "Alta Prestamo";
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaPrestamo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.ComboBox comboDestino;
        private System.Windows.Forms.ComboBox comboClientes;
        private System.Windows.Forms.ComboBox comboPeriodo;
        private System.Windows.Forms.NumericUpDown numImporte;
        private System.Windows.Forms.NumericUpDown numCuotas;
        private System.Windows.Forms.TextBox txtTasaInteres;
    }
}