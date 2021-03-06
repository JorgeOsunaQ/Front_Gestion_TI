﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibreriaBD;

namespace GestionDeOperacionesTI
{
    public partial class frmMenuAdministrador : Form
    {
        private ManejaEmpleado AdmEmp;
        int IDEmp;
        public frmMenuAdministrador(ManejaEmpleado AdmEmp, int IDEmp)
        {
            InitializeComponent();
            this.AdmEmp = AdmEmp;
            this.IDEmp = IDEmp;
        }

        private void AbrirForm(object formP)
        {
            if(this.pnContenido.Controls.Count > 0)
            {
                this.pnContenido.Controls.Clear();
                Form frm = formP as Form;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                this.pnContenido.Controls.Add(frm);
                this.pnContenido.Tag = frm;
                frm.Show();
            }
        }

        private void editarPerfilToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new frmEditaPerfil(AdmEmp,IDEmp));
        }

        private void frmMenuAdministrador_Load(object sender, EventArgs e)
        {
            AbrirForm(new frmInicio(AdmEmp, IDEmp));
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmInicio(AdmEmp,IDEmp));
        }
    }
}
