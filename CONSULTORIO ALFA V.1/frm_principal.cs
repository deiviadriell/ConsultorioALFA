using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_principal : Form
    {
        public frm_principal()
        {
            InitializeComponent();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            frm_nuevoPaciente frm_nuevoPaciente = new frm_nuevoPaciente();
            frm_nuevoPaciente.ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frm_nuevoPaciente frm_nuevoPaciente = new frm_nuevoPaciente();
            frm_nuevoPaciente.ShowDialog();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frm_consulta frm_consulta = new frm_consulta("");
            frm_consulta.ShowDialog();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            frm_editarconsulta frm_editarconsulta = new frm_editarconsulta();
            frm_editarconsulta.ShowDialog();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            frm_acercaDe frm_acercaDe = new frm_acercaDe();
            frm_acercaDe.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            frm_contactenos frm_contactenos = new frm_contactenos();
            frm_contactenos.ShowDialog();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\manual.pdf");
        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            frm_editarPaciente frm_editarPaciente = new frm_editarPaciente();
            frm_editarPaciente.ShowDialog();
        }

        private void buttonItem4_Click_1(object sender, EventArgs e)
        {
            frm_consulta frm_consulta = new frm_consulta("");
            frm_consulta.ShowDialog();
        }

        private void buttonItem5_Click_1(object sender, EventArgs e)
        {
            frm_editarconsulta frm_editarconsulta = new frm_editarconsulta();
            frm_editarconsulta.ShowDialog(); 
        }

        private void buttonItem6_Click_1(object sender, EventArgs e)
        {
            frm_acercaDe frm_acercaDe = new frm_acercaDe();
            frm_acercaDe.ShowDialog(); 
        }

        private void buttonItem7_Click_1(object sender, EventArgs e)
        {
            frm_contactenos frm_contactenos = new frm_contactenos();
            frm_contactenos.ShowDialog(); 
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\manual.pdf");

        }
    }
}
