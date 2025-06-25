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
    public partial class ListadoPrestamo : Form
    {
        public ListadoPrestamo()
        {
            InitializeComponent();
            // Configurar fechas por defecto (últimos 30 días)
            dtpFechaDesde.Value = DateTime.Today.AddMonths(-1);
            dtpFechaHasta.Value = DateTime.Today;

            CargarPrestamos();
            CargarDestinos();
            ConfigurarDataGridView();
        }

        private void CargarPrestamos(int? destinoCodigo = null)
        {
            dgvPrestamo.DataSource = GestionPrestamos.ObtenerPrestamos(destinoCodigo);
        }


        private void CargarDestinos()
        {
            comboDestino.DataSource = GestionPrestamos.ObtenerDestinosEnPrestamo();
            comboDestino.DisplayMember = "DES_Descripcion";
            comboDestino.ValueMember = "DES_Codigo";
        }

        private void ConfigurarDataGridView()
        {
            dgvPrestamo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Formatear columnas numéricas y de fecha
            if (dgvPrestamo.Columns["Importe"] != null)
            {
                dgvPrestamo.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgvPrestamo.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvPrestamo.Columns["Fecha"] != null)
            {
                dgvPrestamo.Columns["Fecha"].DefaultCellStyle.Format = "d";
                dgvPrestamo.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPrestamo.Columns["Tasa de Interés"] != null)
            {
                var col = dgvPrestamo.Columns["Tasa de Interés"] as DataGridViewTextBoxColumn;
                if (col != null)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "0.00'%'";  // Las comillas simples escapan el %
                }
            }

            if (dgvPrestamo.Columns["Cantidad de Cuotas"] != null)
            {
                dgvPrestamo.Columns["Cantidad de Cuotas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        private void comboDestino_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboDestino.SelectedValue != null)
                {
                    if (comboDestino.SelectedValue == DBNull.Value)
                    {
                        CargarPrestamos(); // Cargar todos
                    }
                    else
                    {
                        // Manejo seguro de la conversión
                        DataRowView drv = (DataRowView)comboDestino.SelectedItem;
                        if (drv != null && drv.Row["DES_Codigo"] != DBNull.Value)
                        {
                            int destinoCodigo = Convert.ToInt32(drv.Row["DES_Codigo"]);
                            CargarPrestamos(destinoCodigo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Validar que la fecha desde sea menor o igual a la fecha hasta
                    if (dtpFechaDesde.Value > dtpFechaHasta.Value)
                    {
                        MessageBox.Show("La fecha 'Desde' debe ser menor o igual a la fecha 'Hasta'",
                                      "Error en fechas",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                        return;
                    }

                    // Obtener los préstamos para el rango de fechas seleccionado
                    dgvPrestamo.DataSource = GestionPrestamos.ObtenerPrestamosPorRangoFechas(
                        dtpFechaDesde.Value,
                        dtpFechaHasta.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar préstamos: " + ex.Message,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }
    }
}
