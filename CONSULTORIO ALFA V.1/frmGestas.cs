using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frmGestas : Form
    {
        string cedula;
        Conexion uC = new Conexion();
        public frmGestas(string cedula)
        {
            InitializeComponent();
            this.cedula = cedula;
            txtCedula.Text = cedula;
        }

        private void frmGestas_Load(object sender, EventArgs e)
        {
            if (cedula != "")
            {
                try
                {

                    MySqlDataReader sDr = uC.Consultas("SELECT CONCAT (nombres,' ', apellidos)as paciente,Embarazos,Partos,Cesareas,Abortos from paciente where cedula ='"+txtCedula.Text+"'");
                    if (sDr.HasRows)
                    {
                        while (sDr.Read())
                        {
                            
                            txtPaciente.Text = sDr.GetString(0);
                            nudEmbarazos.Value =Convert.ToDecimal( sDr.GetString(1));
                            nudPartos.Value = Convert.ToDecimal(sDr.GetString(2));
                            nudCesareas.Value = Convert.ToDecimal(sDr.GetString(3));
                            nudAbortos.Value = Convert.ToDecimal(sDr.GetString(4));                         
                            
                            
                            
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

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                if (uC.Insertar("update paciente set Embarazos='" + nudEmbarazos.Value + "', Partos='" + nudPartos.Value + "', Cesareas='" + nudCesareas.Value + "', Abortos='" + nudAbortos.Value + "' where cedula='" + txtCedula.Text + "'")>0)
                {
                    MessageBox.Show("Datos Actualizados Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
 
                }
                else
                    MessageBox.Show("Error al intentar guardar verifique el número de cédula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                // if (txtCedula.Text.Length == 10)
                //{
                try
                {

                    MySqlDataReader sDr = uC.Consultas("SELECT CONCAT (nombres,' ', apellidos)as paciente,Embarazos,Partos,Cesareas,Abortos from paciente where cedula ='" + txtCedula.Text + "'");
                    if (sDr.HasRows)
                    {
                        while (sDr.Read())
                        {

                            txtPaciente.Text = sDr.GetString(0);
                            nudEmbarazos.Value = Convert.ToDecimal(sDr.GetString(1));
                            nudPartos.Value = Convert.ToDecimal(sDr.GetString(2));
                            nudCesareas.Value = Convert.ToDecimal(sDr.GetString(3));
                            nudAbortos.Value = Convert.ToDecimal(sDr.GetString(4));



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
            else
            {
                MessageBox.Show("Debe ingresar un número de cédula");
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void nudEmbarazos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                nudPartos.Focus();
        }

        private void nudPartos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                nudCesareas.Focus();
        }

        private void nudCesareas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                nudAbortos.Focus();
        }

        private void nudAbortos_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnGuardar.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frm_buscarpaciente frm_buscarpaciente = new frm_buscarpaciente();
            frm_buscarpaciente.ShowDialog();
            txtCedula.Text = frm_buscarpaciente.obtenerCedula();
            if (frm_buscarpaciente.obtenerCedula() != "")
            {
                string idPaciente = frm_buscarpaciente.obtenerCedula();
                MySqlDataReader sDr = uC.Consultas("SELECT CONCAT (nombres,' ', apellidos)as paciente,Embarazos,Partos,Cesareas,Abortos,cedula from paciente where idPaciente ='" + idPaciente+ "'");
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {

                        txtPaciente.Text = sDr.GetString(0);
                        nudEmbarazos.Value = Convert.ToDecimal(sDr.GetString(1));
                        nudPartos.Value = Convert.ToDecimal(sDr.GetString(2));
                        nudCesareas.Value = Convert.ToDecimal(sDr.GetString(3));
                        nudAbortos.Value = Convert.ToDecimal(sDr.GetString(4));
                        txtCedula.Text = sDr.GetString(5);



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
                //btnBuscar_Click(sender, e);
            }
            else
            {
                txtCedula.Text = "";
                txtPaciente.Text = "";
            }
        }
    }
}
