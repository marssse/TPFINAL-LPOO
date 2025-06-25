using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vistas.Clientes;
namespace Vistas
{
    public partial class MainOperador : Form
    {
        public MainOperador()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login.logout_Click(sender, e);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            new Prestamos.Alta().Show();            
        }

        private void btnVerPrestamos_Click(object sender, EventArgs e)
        {
            new Prestamos.ListadoPrestamo().Show();
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            Vistas.Clientes.GestionClientes gClientes = new Vistas.Clientes.GestionClientes();
            gClientes.Show();
        }

        private void btnGestionPagos_Click(object sender, EventArgs e)
        {
            Vistas.Pagos.GestionPago gPagos = new Vistas.Pagos.GestionPago();
            gPagos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vistas.Pagos.ListarPagos lPagos = new Vistas.Pagos.ListarPagos();
            lPagos.Show();
        }


    }
}
