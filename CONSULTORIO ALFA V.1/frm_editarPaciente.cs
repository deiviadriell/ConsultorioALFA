using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_editarPaciente : Form
    {
        Conexion uC = new Conexion();
        List<string> sentencias = new List<string>();
        public frm_editarPaciente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length == 10)
            {
                try
                {

                    MySqlDataReader sDr = uC.Consultas("SELECT * from paciente where cedula='" + txtCedula.Text + "'");
                    if (sDr.HasRows)
                    {
                        while (sDr.Read())
                        {
                            txtApellidos.Text = sDr.GetString(2);
                            txtDireccion.Text = sDr.GetString(3);
                            cboGenero.Text = sDr.GetString(4);
                            //txtHistoriaClinica.Text = sDr.GetInt32(4).ToString();
                            txtNombres.Text = sDr.GetString(1);
                            nudEmbarazos.Value = sDr.GetInt32(5);
                            nudPartos.Value = sDr.GetInt32(6);
                            nudCesareas.Value = sDr.GetInt32(7);
                            nudAbortos.Value = sDr.GetInt32(8);
                            txtNombres.Focus();


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
                    else
                    {
                        MessageBox.Show("El número de cédula ingresado no se encuentra en la base de datos intente otra ves", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            else
            {

                MessageBox.Show("Debe ingresar un número de cédula completo le faltan " + (10 - txtCedula.Text.Length).ToString() + " dígitos");
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGenero.Text == "FEMENINO")
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                nudAbortos.Value = 0;
                nudCesareas.Value = 0;
                nudEmbarazos.Value = 0;
                nudPartos.Value = 0;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtNombres.Text = "";
            txtCedula.Focus();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "" && txtApellidos.Text != "" && txtNombres.Text != "")
            {
                try
                {

                    Conexion uC = new Conexion();
                    sentencias.Add("update paciente set Nombres='" + txtNombres.Text + "', apellidos='" + txtApellidos.Text + "', Direccion='" + txtDireccion.Text + "',Genero='" + cboGenero.Text + "',Embarazos='" + Convert.ToInt32(nudEmbarazos.Value) + "', partos='" + Convert.ToInt32(nudPartos.Value) + "', Cesareas='" + Convert.ToInt32(nudCesareas.Value) + "', abortos='" + Convert.ToInt32(nudAbortos.Value) + "' where Cedula='" + txtCedula.Text + "'");
                    //sentencias.Add("INSERT INTO historiaclinica (Fecha,Paciente_Cedula) values(" + new Fecha().obtenerFechaParaAccess() + ",'" + txtCedula.Text + "')");
                    uC.ejecutarTransacciones(sentencias);
                    if (uC.Estado == "ok")
                    {
                        MessageBox.Show("Los datos del paciente han sido actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLimpiar_Click(sender, e);

                    }
                    else
                    {
                        MessageBox.Show(uC.Estado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sentencias.Clear();


                }
                catch (Exception ex)
                {
                    sentencias.Clear();
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            frm_buscarpaciente frm_buscarpaciente = new frm_buscarpaciente();
            frm_buscarpaciente.ShowDialog();
            txtCedula.Text = frm_buscarpaciente.obtenerCedula();
            if (txtCedula.Text != "")
                btnBuscar_Click(sender, e);
            else
                btnLimpiar_Click(sender, e);
        }

        private void frm_editarPaciente_Load(object sender, EventArgs e)
        {
            txtCedula.CharacterCasing = CharacterCasing.Upper;
            txtApellidos.CharacterCasing = CharacterCasing.Upper;
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
            txtNombres.CharacterCasing = CharacterCasing.Upper;

            toolTip1.SetToolTip(txtCedula, "Ingrese un número de cédula");
            toolTip1.SetToolTip(txtNombres, "Ingrese los nombres del paciente");
            toolTip1.SetToolTip(txtApellidos, "Ingrese los apellidos del paciente");
            toolTip1.SetToolTip(txtDireccion, "Ingrese la dirección del paciente");
        }


    }
}

