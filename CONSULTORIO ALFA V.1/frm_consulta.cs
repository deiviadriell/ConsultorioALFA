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
    public partial class frm_consulta : Form
    {
        Conexion uC;
        string cedula;
        public frm_consulta(string cedula)
        {
            InitializeComponent();
            uC = new Conexion();
            this.cedula = cedula;

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }
        private void limpiar()
        {
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtGenero.Text = "";
            txtHistoriaClinica.Text = "";
            txtNombres.Text = "";
            txtPresion.Text = "";
            txtPeso.Text = "";
            txtTemperatura.Text = "";
            txtPrescripcion.Text = "";
            txtSintomas.Text = "";
            txtHistoriaClinica.Text = "";
            label16.Visible = false;
            txtCedula.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frm_buscarpaciente frm_buscarpaciente = new frm_buscarpaciente();
            frm_buscarpaciente.ShowDialog();
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

        private void label2_Click_1(object sender, EventArgs e)
        {
            frm_buscarpaciente frm_buscarpaciente = new frm_buscarpaciente();
            frm_buscarpaciente.ShowDialog();
            txtCedula.Text = frm_buscarpaciente.obtenerCedula();
            if (txtCedula.Text != "")
                btnBuscar_Click(sender, e);
            else
                limpiar();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            frm_historiaclinica frm_historiaclinica = new frm_historiaclinica(txtHistoriaClinica.Text, txtApellidos.Text + " " + txtNombres.Text);
            frm_historiaclinica.Show();
        }

        private void frm_consulta_Load(object sender, EventArgs e)
        {
            txtApellidos.CharacterCasing = CharacterCasing.Upper;
            txtCedula.CharacterCasing = CharacterCasing.Upper;
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
            txtGenero.CharacterCasing = CharacterCasing.Upper;
            txtHistoriaClinica.CharacterCasing = CharacterCasing.Upper;
            txtNombres.CharacterCasing = CharacterCasing.Upper;
            txtPeso.CharacterCasing = CharacterCasing.Upper;
            txtPrescripcion.CharacterCasing = CharacterCasing.Upper;
            txtPresion.CharacterCasing = CharacterCasing.Upper;
            txtSintomas.CharacterCasing = CharacterCasing.Upper;
            txtTemperatura.CharacterCasing = CharacterCasing.Upper;


            toolTip1.SetToolTip(txtCedula, "Ingrese un número de cédula");
            toolTip1.SetToolTip(txtPeso, "Ingrese el peso del paciente");
            toolTip1.SetToolTip(txtPrescripcion, "Ingrese la prescripción");
            toolTip1.SetToolTip(txtPresion, "Ingrese la presión del paciente");
            toolTip1.SetToolTip(txtSintomas, "Ingrese los sintomas del paciente");
            toolTip1.SetToolTip(txtTemperatura, "Ingrese la temperatura del paciente");


            label16.Visible = false;
            if (cedula != "")
            {
                txtCedula.Text = cedula;
                btnBuscar_Click(sender, e);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtPresion.Text != "" && txtPeso.Text != "" && txtTemperatura.Text != "" && txtCedula.Text != "" && txtPrescripcion.Text != "" && txtSintomas.Text != "")
            {
                int filas_afectadas = 0;
                filas_afectadas = uC.Insertar("INSERT INTO signosvitales (Peso,Temperatura,Presion,FUM) values('" + txtPeso.Text.ToString() + "','" + txtTemperatura.Text + "','" + txtPresion.Text + "','" + new Fecha().obtenerFechaParaMySql(dateTimePicker1.Value) + "');");
                filas_afectadas = filas_afectadas + uC.Insertar("insert into consultas (Fecha,Sintomas,Prescripcion,HistoriaClinica_idHistoriaClinica,SignosVitales_idSignosVitales) values('" + new Fecha().obtenerFechaParaMySql(dateTimePicker1.Value) + "','" + txtSintomas.Text + "','" + txtPrescripcion.Text + "','" + txtHistoriaClinica.Text + "','" + uC.obtenerUnValor("select * from signosvitales order by idSignosVitales desc limit 1") + "')");
                if (filas_afectadas == 2)
                {
                    MessageBox.Show("Datos ingresados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    txtCedula.Focus();
                }
                else
                    MessageBox.Show("Probelmas al intentar guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                MessageBox.Show("Debe ingresar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCedula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnBuscar_Click(sender, e);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTemperatura.Focus();
        }

        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTemperatura.Focus();
        }

        private void txtPresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dateTimePicker1.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtGenero.Text = "";
            txtHistoriaClinica.Text = "";
            txtNombres.Text = "";
            txtPeso.Text = "";
            txtPrescripcion.Text = "";
            txtPresion.Text = "";
            txtSintomas.Text = "";
            txtTemperatura.Text = "";
            label16.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
