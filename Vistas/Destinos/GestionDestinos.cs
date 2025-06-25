using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClaseBase;

namespace Vistas.Destinos
{
    public partial class GestionDestinos : Form
    {
        private bool modoEdicion = false;
        private string codigoActual = string.Empty;

        public GestionDestinos()
        {
            InitializeComponent();
        }
        private void GestionDestinos_Load(object sender, EventArgs e)
        {
            CargarDestinos();
            EstablecerModoEdicion(false);
        }

        private void CargarDestinos(string filtro = "")
        {
            if (string.IsNullOrEmpty(filtro))
            {
                dgvDestinos.DataSource = ClaseBase.GestionDestino.ObtenerTodosDestinos();
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            codigoActual = string.Empty;
        }

        private void EstablecerModoEdicion(bool edicion)
        {
            modoEdicion = edicion;
            btnRegistrar.Enabled = !edicion;
            btnActualizar.Enabled = edicion;
            btnEliminar.Enabled = edicion;
            btnCancelar.Visible = edicion;

            txtCodigo.ReadOnly = edicion;
        }

        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            

            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ClaseBase.GestionDestino.AgregarDestino(
                    txtDescripcion.Text
                );

                LimpiarCampos();
                CargarDestinos();
                MessageBox.Show("Destino registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string descripcion = txtBuscar.Text.Trim();
            dgvDestinos.DataSource = ClaseBase.GestionDestino.BuscarDestinos(descripcion);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarDestinos();
        }

        private void dgvDestinos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDestinos.Rows[e.RowIndex];
                if (row.Cells["Codigo"].Value.ToString() != "")
                {
                    codigoActual = row.Cells["Codigo"].Value.ToString();
                    txtCodigo.Text = codigoActual;
                    txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();

                    EstablecerModoEdicion(true);
                }
                
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ClaseBase.GestionDestino.ActualizarDestino(
                    codigoActual,
                    txtDescripcion.Text
                );

                LimpiarCampos();
                CargarDestinos();
                EstablecerModoEdicion(false);
                MessageBox.Show("Destino actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este destino?", "Confirmar",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClaseBase.GestionDestino.EliminarDestino(codigoActual);
                LimpiarCampos();
                CargarDestinos();
                EstablecerModoEdicion(false);
                MessageBox.Show("Destino eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstablecerModoEdicion(false);
        }


        
    }
}
