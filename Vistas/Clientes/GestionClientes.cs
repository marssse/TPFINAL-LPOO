using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClaseBase;

namespace Vistas.Clientes
{
    public partial class GestionClientes : Form
    {
        private bool modoEdicion = false;
        private string dniActual = string.Empty;
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            CargarSexos();
            CargarClientes();
            EstablecerModoEdicion(false);
        }
        private void CargarSexos()
        {
            cmbSexo.Items.Clear();
            cmbSexo.Items.Add("M");
            cmbSexo.Items.Add("H");
            cmbSexo.SelectedIndex = -1; // Opcional: ningún ítem seleccionado por defecto
        }


        private void CargarClientes(string filtro = "")
        {
            if (string.IsNullOrEmpty(filtro))
            {
                dgvClientes.DataSource = ClaseBase.GestionClientes.ObtenerTodosClientes();
            }
           
            FormatearDataGridView();
        }

        private void FormatearDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DNI",
                HeaderText = "DNI",
                Name = "colDni"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "colNombre"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Name = "colApellido"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Sexo",
                HeaderText = "Sexo",
                Name = "colSexo"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaNacimiento",
                HeaderText = "Fecha de Nacimiento",
                Name = "colFechaNacimiento"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Ingresos",
                HeaderText = "Ingresos",
                Name = "colIngresos"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Direccion",
                HeaderText = "Dirección",
                Name = "colDireccion"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Name = "colTelefono"
            });

            // Opcional: autoajustar columnas
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarCampos()
        {
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cmbSexo.SelectedIndex = -1;
            fechaNacimiento.Value = DateTime.Now;
            txtIngresos.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            dniActual = string.Empty;
        }

        private void EstablecerModoEdicion(bool edicion)
        {
            modoEdicion = edicion;
            btnRegistrar.Enabled = !edicion;
            btnActualizar.Enabled = edicion;
            btnEliminar.Enabled = edicion;
            btnCancelar.Visible = edicion;

            // Habilitar/deshabilitar controles según el modo
            txtDNI.ReadOnly = edicion; // El DNI no se puede modificar en edición
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("El DNI es requerido");
                return false;
            }
            long dniParsed;
            if (!long.TryParse(txtDNI.Text, out dniParsed))
            {
                MessageBox.Show("El DNI debe ser numérico");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido");
                return false;
            }

            if (cmbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un sexo");
                return false;
            }

            decimal ingresos;
            if (!decimal.TryParse(txtIngresos.Text, out ingresos))
            {
                MessageBox.Show("Los ingresos deben ser un número válido");
                return false;
            }

            if (fechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura");
                return false;
            }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ClaseBase.GestionClientes.AgregarCliente(
                    txtDNI.Text,
                    txtNombre.Text,
                    txtApellido.Text,
                    cmbSexo.SelectedItem != null ? cmbSexo.SelectedItem.ToString() : "",
                    fechaNacimiento.Value,
                    decimal.Parse(txtIngresos.Text),
                    txtDireccion.Text,
                    txtTelefono.Text
                );

                LimpiarCampos();
                CargarClientes();
                MessageBox.Show("Cliente registrado exitosamente");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            CargarClientes();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
                dniActual = row.Cells["colDni"].Value.ToString();
                txtDNI.Text = dniActual;
                txtNombre.Text = row.Cells["colNombre"].Value.ToString();
                txtApellido.Text = row.Cells["colApellido"].Value.ToString();
                cmbSexo.SelectedItem = row.Cells["colSexo"].Value.ToString();
                fechaNacimiento.Value = Convert.ToDateTime(row.Cells["colFechaNacimiento"].Value);
                txtIngresos.Text = row.Cells["colIngresos"].Value.ToString();
                txtDireccion.Text = row.Cells["colDireccion"].Value.ToString();
                txtTelefono.Text = row.Cells["colTelefono"].Value.ToString();


                EstablecerModoEdicion(true);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ClaseBase.GestionClientes.ActualizarCliente(
                    dniActual,
                    txtNombre.Text,
                    txtApellido.Text,
                    cmbSexo.SelectedItem != null ? cmbSexo.SelectedItem.ToString() : "",
                    fechaNacimiento.Value,
                    decimal.Parse(txtIngresos.Text),
                    txtDireccion.Text,
                    txtTelefono.Text
                );

                LimpiarCampos();
                CargarClientes();
                EstablecerModoEdicion(false);
                MessageBox.Show("Cliente actualizado exitosamente");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?",
                              "Confirmar",
                              MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClaseBase.GestionClientes.EliminarCliente(dniActual);
                LimpiarCampos();
                CargarClientes();
                EstablecerModoEdicion(false);
                MessageBox.Show("Cliente eliminado exitosamente");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstablecerModoEdicion(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string apellido = txtBuscarApellido.Text.Trim();
            string nombre = txtBuscarNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(apellido) && string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese al menos un criterio de búsqueda (Nombre o Apellido).");
                return;
            }

            dgvClientes.DataSource = ClaseBase.GestionClientes.BuscarClientesCombinado(apellido,nombre);

                
           
        }

        

    }
}
