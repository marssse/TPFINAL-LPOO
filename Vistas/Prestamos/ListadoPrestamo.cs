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
            CargarPrestamos();
        }

        private void CargarPrestamos()
        {
            dgvPrestamo.DataSource = GestionPrestamos.ObtenerPrestamos();
            dgvPrestamo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

       

    }
}
