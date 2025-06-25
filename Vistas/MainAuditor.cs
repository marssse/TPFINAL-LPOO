using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vistas;

namespace Vistas
{
    public partial class MainAuditor : Form
    {
        public MainAuditor()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login.logout_Click(sender, e);
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de gestión
            new GestionUsuario().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vistas.Clientes.GestionClientes gClientes = new Vistas.Clientes.GestionClientes();
            gClientes.Show();
        }

        private void btnGestionarDestino_Click(object sender, EventArgs e)
        {
            Vistas.Destinos.GestionDestinos gDestino = new Vistas.Destinos.GestionDestinos();
            gDestino.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Vistas.Pagos.GestionPago gPagos = new Vistas.Pagos.GestionPago();
            gPagos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vistas.Pagos.ListarPagos lPagos = new Vistas.Pagos.ListarPagos();
            lPagos.Show();
        }


        private void verPrestamos_Click(object sender, EventArgs e)
        {
            new Prestamos.ListadoPrestamo().Show();
        }

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            new Prestamos.Alta().Show();
        }

    }
}
