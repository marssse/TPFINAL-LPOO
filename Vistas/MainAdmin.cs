﻿using System;
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
    public partial class MainAdmin : Form
    {
        public MainAdmin()
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

        private void btnGestionarDestino_Click(object sender, EventArgs e)
        {
            Vistas.Destinos.GestionDestinos gDestino = new Vistas.Destinos.GestionDestinos();
            gDestino.Show();
        }

    }
}
