using CKEditorBrowserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var tabCtrl = new TabControl()
            {
                Dock = DockStyle.Fill
            };

            var curDir = Directory.GetCurrentDirectory();
            var ckEditorUri = new Uri(String.Format("file:///{0}/Resources/CkEditor/index.html", curDir));

            for (int i = 0; i < 8; i++)
            {
                var tabPg = new TabPage($"Tab {i}");
                var ckEditorCtrl = new CKEditorControl(ckEditorUri)
                {
                    Dock = DockStyle.Fill
                };

                tabPg.Controls.Add(ckEditorCtrl);

                int indx = i;
                ckEditorCtrl.DocumentCompleted+= (sss,ee)=> {
                    ckEditorCtrl.SetContent($"Tab {indx} Content");
                };

                tabCtrl.Controls.Add(tabPg);
            }

            Controls.Add(tabCtrl);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            //frm_nuevoPaciente frm_nuevoPaciente = new frm_nuevoPaciente();
            //frm_nuevoPaciente.ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frm_editarPaciente frm_editarPaciente = new frm_editarPaciente();
            frm_editarPaciente.ShowDialog(); 
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
    }
}


