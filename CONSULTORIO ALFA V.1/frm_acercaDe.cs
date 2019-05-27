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
    public partial class frm_acercaDe : Form
    {
        public frm_acercaDe()
        {
            InitializeComponent();
        }

        private void frm_acercaDe_Load(object sender, EventArgs e)
        {
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        }
    }
}
