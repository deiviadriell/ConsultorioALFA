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
    public partial class frm_login : Form
    {
        bool salir = false;
        public frm_login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public bool salio()
        {
            return salir;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtUsuario.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

           salir = true;
           Close();
        }
        public string obtenerUsuario()
        {
            return txtUsuario.Text;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {



            if (txtClave.Text != "" && txtUsuario.Text != "")
            {
                Conexion uC = new Conexion();
                string valor=uC.obtenerUnValor("select COUNT(nick) from usuario where nick='" + txtUsuario.Text + "' and clave='" + txtClave.Text + "'");
                if (valor!=""&&valor!="0")
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("El usuario y/o contraseña no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }


            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtClave.Focus();
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnRegistrar_Click(sender, e);
            }
        }
    }
}
