using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClaseBase;

namespace Vistas.Prestamos
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            // Configurar ComboBoxs
            comboClientes.DataSource = GestionPrestamos.ObtenerClientes();
            comboClientes.DisplayMember = "NombreCompleto";
            comboClientes.ValueMember = "CLI_DNI";

            comboDestino.DataSource = GestionPrestamos.ObtenerDestinos();
            comboDestino.DisplayMember = "DES_Descripcion";
            comboDestino.ValueMember = "DES_Codigo";

            comboPeriodo.DataSource = GestionPrestamos.ObtenerPeriodos();
            comboPeriodo.DisplayMember = "PER_Descripcion";
            comboPeriodo.ValueMember = "PER_Codigo";
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            bool resultado = GestionPrestamos.RegistrarPrestamoConInteres(
                comboClientes.SelectedValue.ToString(),
                (int)comboDestino.SelectedValue,
                (int)comboPeriodo.SelectedValue,
                decimal.Parse(numImporte.Text),
                txtTasaInteres.Text, // Ejemplo: "20%"
                (int)numCuotas.Value
            );

            if (resultado)
            {
                MessageBox.Show("Préstamo registrado exitosamente");
                LimpiarFormulario();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el préstamo");
            }
        }

        private bool ValidarDatos()
        {
            if (comboClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente");
                return false;
            }

            if (decimal.Parse(numImporte.Text) <= 0)
            {
                MessageBox.Show("Ingrese un importe válido");
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            numImporte.Value = 0;
            numCuotas.Value = 1;
            comboClientes.Focus();
        }

    }
}
