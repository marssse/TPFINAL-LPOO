using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vistas.Pagos
{
    public partial class ListarPagos : Form
    {
        public ListarPagos()
        {
            InitializeComponent();
        }

        private void ListarPagos_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void CargarClientes()
        {
            // Evitar evento automático
            cmbClientes.SelectedIndexChanged -= cmbClientes_SelectedIndexChanged;

            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "CLI_DNI";
            cmbClientes.DataSource = ClaseBase.GestionPago.ObtenerClientes();
            cmbClientes.SelectedIndex = -1;

            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1 || cmbClientes.SelectedValue == null)
                return;

            string dni = cmbClientes.SelectedValue.ToString();

            DataTable pagos = ClaseBase.GestionPago.ObtenerPagosPorCliente(dni);

            if (pagos.Rows.Count == 0)
            {
                MessageBox.Show("Este cliente no tiene pagos registrados.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvPagos.DataSource = null;  // Limpia la grilla para no mostrar datos anteriores
            }
            else
            {
                dgvPagos.DataSource = pagos;
            }
        }

    }
}
