using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vistas.Prestamos
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Datos del Préstamo:\n" +
                "Número de Préstamo: " + txtNumero.Text + "\n" +
                "DNI del Cliente: " + txtDni.Text + "\n" +
                "Código de Destino: " + txtDesCodigo.Text + "\n" +
                "Código de Período: " + txtPersonaCodigo.Text + "\n" +
                "Fecha del Préstamo: " + fechaPrestamo.Text + "\n" +
                "Importe del Préstamo: " + txtImporte.Text + "\n" +
                "Tasa de Interés: " + txtTasaInteres.Text + "\n" +
                "Cantidad de Cuotas: " + txtCuotas.Text + "\n" +
                "Estado del Préstamo: " + txtEstado.Text
            );
        }
    }
}
