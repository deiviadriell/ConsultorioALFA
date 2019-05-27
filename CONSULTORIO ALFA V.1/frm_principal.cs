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
        string usuario;
        public frm_principal(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            //frm_nuevoPaciente frm_nuevoPaciente = new frm_nuevoPaciente();
            //frm_nuevoPaciente.ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            //frm_nuevoPaciente frm_nuevoPaciente = new frm_nuevoPaciente();
            //frm_nuevoPaciente.ShowDialog();
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

        private void buttonItem7_Click_2(object sender, EventArgs e)
        {
            frm_registrarUsuario frm_registrarUsuario = new frm_registrarUsuario();
            frm_registrarUsuario.ShowDialog();
        }

        private void frm_principal_Load(object sender, EventArgs e)
        {

        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            frm_editarUsuario frm_editarUsuario = new frm_editarUsuario(usuario);
            frm_editarUsuario.ShowDialog(); 
        }

        private void frm_principal_KeyUp(object sender, KeyEventArgs e)
        {
            //ctrl+r registrar paciente
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.R))
            {
                buttonItem2_Click(sender, e);                
            }
            //ctrl+e editar paciente
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.E))
            {
                buttonItem3_Click_1(sender, e);
            }
            //ctrl+d registrar consulta
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.D))
            {
                buttonItem4_Click_1(sender, e);
            }
            //ctrl+n nuevo usuario
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.N))
            {
                buttonItem7_Click_2(sender, e);
            }
            //ctr+m modificar usuario
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.M))
            {
                buttonItem9_Click(sender, e);
            }
            //ctrl+t tutorial
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.T))
            {
                buttonItem8_Click(sender, e);
            }
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
             
        }

        private void frm_principal_Load_1(object sender, EventArgs e)
        {

        }
    }
}
