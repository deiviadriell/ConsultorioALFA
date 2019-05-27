using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_registrarUsuario : Form
    {
        Conexion uC = new Conexion();
        public frm_registrarUsuario()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtConfirmar.Text = "";
            txtUsuario.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtClave.Text != "" && txtConfirmar.Text != "" &&textBox1.Text!="")
            {
                //verifico la contraseña del administrador
                //confirmo que las contraseñas concuerden 
                if (txtClave.Text == txtConfirmar.Text)
                {
                    //confirmar clave admin
                    bool bandera = false;
                    MySqlDataReader sDr = uC.Consultas("SELECT * FROM usuario where clave='" + textBox1.Text + "' and rol='administrador'");
                    if (sDr.HasRows)
                        bandera = true;
                    else                    
                        bandera = false;
                    if (bandera)
                    {
                        if (uC.Insertar("INSERT INTO USUARIO VALUES('" + txtUsuario.Text + "','" + txtClave.Text + "','usuario')") > 0)
                        {
                            MessageBox.Show("El usuario a sido registrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(sender, e);
                            txtUsuario.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Las clave del admnisitrador no concuerdan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Las contraseñas no concuerdan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmar.Text = "";
                    txtClave.Focus();
 
                }
                

                //pido la clave del administrador

                //guardo
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            //verifico que la cédula ingresada no exista en la bd


            try
            {

                MySqlDataReader sDr = uC.Consultas("SELECT * FROM usuario where nick='" + txtUsuario.Text + "'");
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        MessageBox.Show("El nick del usuario ingresado ya existe ingrese otro por favor");
                        txtUsuario.Text = "";
                        txtUsuario.Focus();
                        break;


                    }
                    //verifico si es nuevo o si tiene historia clinica
                    /*string idHistoria=uC.obtenerUnValor("select historiaclinica.idHistoriaClinica from historiaclinica where historiaclinica.Paciente_Cedula='" + txtCedula.Text + "'");
                    if (idHistoria != "")
                    {
                        txtHistoriaClinica.Text = idHistoria;
                    }
                    else
                    {
                        idHistoria = (Convert.ToInt32(uC.obtenerUnValor("select top 1 historiaclinica.idHistoriaClinica from historiaclinica order by idHistoriaClinica desc"))+1).ToString();
                        txtHistoriaClinica.Text = idHistoria;
                    }*/
                }
            }
            catch (Exception ex)
            {
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
                txtConfirmar.Focus();
            }
        }

        private void txtConfirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnRegistrar.Focus();
            }
        }
        
    }
}
