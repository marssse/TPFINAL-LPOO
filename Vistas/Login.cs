using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClaseBase.Entities;

using ClaseBase;

namespace Vistas
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;

        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtContrasenia.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingrese usuario y contraseña");
                return;
            }

            object rol = GestionUsuarios.ValidarLogin(usuario, password);            

            if (rol != null)
            {
                this.Hide(); // Oculta el formulario de login

                // Abre el formulario principal según el rol
                switch (rol.ToString())
                {
                    case "ADMIN":
                        new MainAdmin().ShowDialog();
                        break;
                    case "OPER":
                        new MainOperador().ShowDialog();
                        break;
                    case "AUDIT":
                        new MainAuditor().ShowDialog();
                        break;
                    default:
                        MessageBox.Show("Rol no reconocido");
                        break;
                }

                this.Close(); // Cierra el login cuando cierran el form principal

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                txtContrasenia.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Blue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = SystemColors.Control;
        }

        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = SystemColors.Control;
        }

        public static void logout_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Seguro que desea salir del sistema?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
