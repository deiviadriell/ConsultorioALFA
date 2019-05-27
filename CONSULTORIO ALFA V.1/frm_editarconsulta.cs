using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_editarconsulta : Form
    {
        Conexion uC;
        string cedula;
        public frm_editarconsulta()
        {
            InitializeComponent();
            uC = new Conexion();
            this.cedula = cedula;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                if (txtCedula.Text.Length == 10)
                {
                    try
                    {

                        MySqlDataReader sDr = uC.Consultas("SELECT paciente.Cedula,paciente.Apellidos,paciente.Nombres,paciente.Genero,historiaclinica.idHistoriaClinica,paciente.Direccion FROM paciente inner join historiaclinica on paciente.Cedula= historiaclinica.Paciente_Cedula where cedula='" + txtCedula.Text + "'");
                        if (sDr.HasRows)
                        {
                            while (sDr.Read())
                            {
                                txtApellidos.Text = sDr.GetString(1);
                                txtDireccion.Text = sDr.GetString(5);
                                txtGenero.Text = sDr.GetString(3);
                                txtHistoriaClinica.Text = sDr.GetInt32(4).ToString();
                                txtNombres.Text = sDr.GetString(2);
                                label16.Visible = true;
                                txtPeso.Focus();
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

                    MessageBox.Show("Debe ingresar un número de cédula completo le faltan " + (10 - txtCedula.Text.Length).ToString() + " dígitos");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un número de cédula");
            }

        }

        private void frm_editarconsulta_Load(object sender, EventArgs e)
        {

        }
    }
}
