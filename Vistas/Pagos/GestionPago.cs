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
    public partial class GestionPago : Form
    {
        public GestionPago()
        {
            InitializeComponent();
        }
       
        private void CargarClientes()
        {
            // Desconectamos el evento temporalmente
            cmbClientes.SelectedIndexChanged -= cmbClientes_SelectedIndexChanged;

            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "CLI_DNI";
            cmbClientes.DataSource = ClaseBase.GestionPago.ObtenerClientes();
            cmbClientes.SelectedIndex = -1;

            // 🔌 Lo reconectamos después de cargar
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null)
            {
                string dniCliente = cmbClientes.SelectedValue.ToString();
                DataTable prestamos = ClaseBase.GestionPago.ObtenerPrestamosPendientes(dniCliente);

                if (prestamos.Rows.Count > 0)
                {
                    cmbPrestamos.DisplayMember = "Descripcion";
                    cmbPrestamos.ValueMember = "PRE_Numero";
                    cmbPrestamos.DataSource = prestamos;
                    cmbPrestamos.SelectedIndex = 0;
                }
                    
                else
                {
                    MessageBox.Show("El cliente no tiene préstamos pendientes", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPrestamos.DataSource = null;
                }
            }
        }

        private void cmbPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrestamos.SelectedValue != null)
            {
                int prestamoNumero = (int)cmbPrestamos.SelectedValue;
                DataTable cuotas = ClaseBase.GestionPago.ObtenerCuotasPendientes(prestamoNumero);

                if (cuotas.Rows.Count > 0)
                {
                    dgvCuotas.DataSource = cuotas;
                    cmbCuotas.DisplayMember = "CUO_Numero";
                    cmbCuotas.ValueMember = "CUO_Codigo";
                    cmbCuotas.DataSource = cuotas;
                    cmbCuotas.SelectedIndex = 0;
                }
                else
                {
                    dgvCuotas.DataSource = null;
                    cmbCuotas.DataSource = null;
                    lblInfoCuota.Text = "";
                    MessageBox.Show("No hay cuotas pendientes para este préstamo", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPrestamos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un préstamo", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCuotas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una cuota", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void dgvCuotas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCuotas.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCuotas.SelectedRows[0];
            }
        }

        private void GestionPago_Load(object sender, EventArgs e)
        {
            CargarClientes();
            dtpFechaPago.Value = DateTime.Now;
        }

        private void cmbCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuotas.SelectedValue != null)
            {
                // Mostrar información de la cuota seleccionada
                DataRowView row = (DataRowView)cmbCuotas.SelectedItem;
                lblInfoCuota.Text = "Cuota #" + row["CUO_Numero"] + " - Importe: $" + row["CUO_Importe"];
            }
        }
        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    int cuotaCodigo = (int)cmbCuotas.SelectedValue;
                    DateTime fechaPago = dtpFechaPago.Value;

                    ClaseBase.GestionPago.RegistrarPago(cuotaCodigo, fechaPago);

                    MessageBox.Show("Pago registrado correctamente", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ⚠️ Recargar los préstamos pendientes del cliente actual
                    string dniCliente = cmbClientes.SelectedValue.ToString();
                    DataTable nuevosPrestamos = ClaseBase.GestionPago.ObtenerPrestamosPendientes(dniCliente);

                    if (nuevosPrestamos.Rows.Count > 0)
                    {
                        cmbPrestamos.DisplayMember = "PRE_Numero";
                        cmbPrestamos.ValueMember = "PRE_Numero";
                        cmbPrestamos.DataSource = nuevosPrestamos;
                        cmbPrestamos.SelectedIndex = 0; // Esto dispara el SelectedIndexChanged para recargar cuotas
                    }
                    else
                    {
                        MessageBox.Show("Este cliente ya no tiene préstamos pendientes.", "Información",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbPrestamos.DataSource = null;
                        cmbCuotas.DataSource = null;
                        dgvCuotas.DataSource = null;
                        lblInfoCuota.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar pago: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
