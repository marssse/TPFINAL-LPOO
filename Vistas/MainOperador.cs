using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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


    }
}
