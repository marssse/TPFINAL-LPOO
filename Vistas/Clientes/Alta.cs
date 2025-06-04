using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vistas.Clientes
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
            "Datos del Cliente:\n" +
            "DNI: " + txtDni.Text + "\n" +
            "Nombre: " + txtNombre.Text + "\n" +
            "Apellido: " + txtApellido.Text + "\n" +
            "Sexo: " + txtSexo.Text + "\n" +  // Asumo que tienes un txtSexo
            "Fecha de Nacimiento: " + fechaNacimiento.Text + "\n" + // Asumo que tienes un txtFechaNacimiento
            "Ingresos: " + txtIngresos.Text + "\n" + // Asumo que tienes un txtIngresos
            "Dirección: " + txtDireccion.Text + "\n" + // Asumo que tienes un txtDireccion
            "Teléfono: " + txtTelefono.Text  // Asumo que tienes un txtTelefono
);
        }

    }
}
