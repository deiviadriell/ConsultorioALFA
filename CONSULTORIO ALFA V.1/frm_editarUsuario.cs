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
    public partial class frm_editarUsuario : Form
    {
        string usuario;
        public frm_editarUsuario(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void frm_editarUsuario_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = usuario;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt_claveActual.Text = "";
            txtClaveNueva.Text = "";
            txtConfirmar.Text = "";
            txtUsuario.Text = "";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txt_claveActual.Text != "" && txtClaveNueva.Text != "" && txtConfirmar.Text != "")
            {
                if (txtClaveNueva.Text == txtConfirmar.Text)
                {
                    Conexion uC = new Conexion();
                    if (uC.obtenerUnValor("SELECT COUNT(clave) from usuario where nick='" + txtUsuario.Text + "' and clave='"+txt_claveActual.Text+"'") == "1")
                    {


                        if (uC.Insertar("update usuario set clave='" + txtClaveNueva.Text + "' where nick='" + usuario + "'") > 0)
                        {
                            MessageBox.Show("La clave ha sido modificada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        else
                        {
                            MessageBox.Show("Problemas al actualizar en: " + uC.Estado + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La clave actual no es la correcta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_claveActual.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Las claves no coinciden", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
 
                }
                
            }
            else
                MessageBox.Show("Debe ingresar todos los campos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
