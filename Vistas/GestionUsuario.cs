using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClaseBase;

namespace Vistas
{
    public partial class GestionUsuario : Form
    {
        public GestionUsuario()
        {
            InitializeComponent();
        }

        private void GestionUsuario_Load(object sender, EventArgs e)
        {
            load_combo_roles();
            load_usuarios();
            // Configurar RadioButtons
            rbOrdenUsuario.Text = "Ordenar por Usuario";
            rbOrdenApellido.Text = "Ordenar por Apellido";
            rbOrdenUsuario.Checked = true; // Opción por defecto

            // Configurar botón
            btnOrdenar.Text = "Aplicar Orden";
        }

        private void load_combo_roles()
        {     
            comboRol.DisplayMember = "ROL_Descripcion";
            comboRol.ValueMember = "ROL_Codigo";
            comboRol.DataSource = GestionUsuarios.ObtenerRoles();
        }

        private void load_usuarios()
        {
            dgvUsuarios.DataSource = GestionUsuarios.ObtenerTodosUsuarios();
        }

        private void reset_fields()
        {
            txtID.Clear();            
            comboRol.SelectedIndex = -1;
            txtUsuario.Clear();
            txtNombreCompleto.Clear();
            txtPassword.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            GestionUsuarios.AgregarUsuario(
                txtUsuario.Text,
                txtPassword.Text,
                txtNombreCompleto.Text,
                comboRol.SelectedValue.ToString()
            );
            reset_fields();
            load_usuarios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text.Trim();
            dgvUsuarios.DataSource = GestionUsuarios.BuscarUsuarios(textoBusqueda);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            load_usuarios();
            txtBusqueda.Text = "";
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                if (row.Cells["ID"].Value.ToString() != "")
                {
                    // Obtener valores de la fila seleccionada
                    int usuarioId = Convert.ToInt32(row.Cells["ID"].Value);
                    string nombreUsuario = row.Cells["Usuario"].Value.ToString();
                    string nombreCompleto = row.Cells["Apellido y Nombre"].Value.ToString();
                    string rolDescripcion = row.Cells["Rol"].Value.ToString();
                    string rolCodigo = row.Cells["Código de Rol"].Value.ToString();
                    string password = row.Cells["Contraseña"].Value.ToString();

                    // Cargar datos en los controles del formulario
                    txtID.Text = usuarioId.ToString();
                    txtUsuario.Text = nombreUsuario;
                    txtNombreCompleto.Text = nombreCompleto;
                    comboRol.Text = rolDescripcion;
                    txtPassword.Text = password;

                    // Guardar el código de rol para uso posterior
                    rolActual = rolCodigo;

                    // Cambiar a modo edición
                    ModoEdicion(true);
                }
                else {
                    // Salir del modo edición
                    ModoEdicion(false);
                    //MessageBox.Show("Usuario eliminado correctamente");
                }
            }
        }
        private string rolActual; // Variable para almacenar el código de rol actual

        private void ModoEdicion(bool enEdicion)
        {
            btnRegistrar.Enabled = !enEdicion;
            btnActualizar.Enabled = enEdicion;
            btnEliminar.Enabled = enEdicion;
            btnCancelar.Visible = enEdicion;

            // Opcional: Limpiar campos si no está en edición
            if (!enEdicion)
            {
                reset_fields();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validar datos antes de actualizar
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios");
                return;
            }

            // Obtener datos del formulario
           int usuarioId = Convert.ToInt32(txtID.Text);
           // string nombreUsuario = txtUsuario.Text;
           // string nombreCompleto = txtNombreCompleto.Text;
           string nuevoRolCodigo = ObtenerCodigoRol(comboRol.Text);

            // Actualizar en la base de datos
           GestionUsuarios.ActualizarUsuario(
                usuarioId,
                txtUsuario.Text,
                txtPassword.Text,
                txtNombreCompleto.Text,
                nuevoRolCodigo
               );

            // Actualizar DataGridView
           load_usuarios();

            // Salir del modo edición
            ModoEdicion(false);
            MessageBox.Show("Usuario actualizado correctamente");
        }

        // Método auxiliar para obtener código de rol desde la descripción
        private string ObtenerCodigoRol(string descripcion)
        {
            foreach (DataRowView item in comboRol.Items)
            {
                if (item["ROL_Descripcion"].ToString() == descripcion)
                    return item["ROL_Codigo"].ToString();
            }
            return rolActual; // Mantener el actual si no se encuentra
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int usuarioId = Convert.ToInt32(txtID.Text);
            GestionUsuarios.EliminarUsuario(usuarioId);
            // Actualizar DataGridView
            load_usuarios();

            // Salir del modo edición
            ModoEdicion(false);
            MessageBox.Show("Usuario eliminado correctamente");
        }
        //metodos tp3
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbOrdenUsuario.Checked)
                {
                    dgvUsuarios.DataSource = GestionUsuarios.ObtenerUsuariosOrdenadosPorUsuario();
                }
                else if (rbOrdenApellido.Checked)
                {
                    dgvUsuarios.DataSource = GestionUsuarios.ObtenerUsuariosOrdenadosPorApellido();
                }

                MessageBox.Show("Usuarios ordenados correctamente.", "Éxito",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ordenar usuarios: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

    }
}
