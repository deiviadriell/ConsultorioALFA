using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_contactenos : Form
    {
        public frm_contactenos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contactos a los siguientes correos deiviv2014@gmail.com ó tambien a deivi_v2014@hotmail.com");

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contactos en Skype usuario: vbrazil2014");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contactos en twitter usuario: deivi_adriell");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Facebook: Deivi Zúñiga");
        }
    }
}
