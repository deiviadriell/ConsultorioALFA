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
    public partial class frm_nuevoPaciente : Form
    {
        List<string> sentencias = new List<string>();
        Conexion uC = new Conexion();
        public frm_nuevoPaciente()
        {

            InitializeComponent();
        }

        private void frm_nuevoPaciente_Load(object sender, EventArgs e)
        {
            txtCedula.CharacterCasing = CharacterCasing.Upper;
            txtApellidos.CharacterCasing = CharacterCasing.Upper;
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
            txtNombres.CharacterCasing = CharacterCasing.Upper;

            txtCedula.Focus();
            cboGenero.SelectedIndex = 0;

            /*ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.ToolTipTitle = "Información";      
            
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;            
            buttonToolTip.SetToolTip(txtCedula, "Click me to execute.");
            */

            toolTip1.SetToolTip(txtCedula, "Ingrese un número de cédula");
            toolTip1.SetToolTip(txtNombres, "Ingrese los nombres del paciente");
            toolTip1.SetToolTip(txtApellidos, "Ingrese los apellidos del paciente");
            toolTip1.SetToolTip(txtDireccion, "Ingrese la dirección del paciente");

            /*toolTip1.Show("Ingrese un número de cédula (10 dígitos) ", txtCedula);
            toolTip1.Show("Ingrese los nombres del paciente", txtNombres);
            toolTip1.Show("Ingrese los apellidos del paciente", txtApellidos);
            toolTip1.Show("Ingrese la dirección del paciente", txtDireccion);*/
        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGenero.Text == "FEMENINO")
            {
                groupBox1.Enabled = true;
                nudEmbarazos.Focus();
            }
            else
                groupBox1.Enabled = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text != "" && txtCedula.Text != "" && txtDireccion.Text != "" && txtNombres.Text != "")
            {
                try
                {
                    Conexion uC = new Conexion();
                    sentencias.Add("INSERT INTO paciente values('" + txtCedula.Text + "','" + txtNombres.Text + "','" + txtApellidos.Text + "','" + txtDireccion.Text + "','" + cboGenero.Text + "','" + nudEmbarazos.Value.ToString() + "','" + nudPartos.Value.ToString() + "','" + nudCesareas.Value.ToString() + "','" + nudAbortos.Value.ToString() + "')");
                    sentencias.Add("INSERT INTO historiaclinica (Fecha,Paciente_Cedula) values(" + new Fecha().obtenerFechaParaAccess() + ",'" + txtCedula.Text + "')");
                    uC.ejecutarTransacciones(sentencias);
                    if (uC.Estado == "ok")
                    {
                        MessageBox.Show("El paciente ha sido registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult resultado = MessageBox.Show("Desea ir al formulario de consulta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            frm_consulta frm_consulta = new frm_consulta(txtCedula.Text);
                            Close();
                            frm_consulta.ShowDialog();
                        }
                        limpiar();



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
                MessageBox.Show("Debe ingresar los campos del paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            //verifico que la cédula ingresada no exista en la bd
            if (txtCedula.Text.Length == 10)
            {
                try
                {

                   MySqlDataReader sDr = uC.Consultas("SELECT * FROM paciente where cedula='" + txtCedula.Text + "'");
                    if (sDr.HasRows)
                    {
                        while (sDr.Read())
                        {
                            MessageBox.Show("La cédula ingresada ya existe corresponde al paciente " + sDr.GetString(1) + " " + sDr.GetString(1) + "");
                            txtCedula.Text = "";
                            txtCedula.Focus();
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
            else
            {
                if (txtCedula.Text.Length != 0)
                {
                    MessageBox.Show("Debe ingresar un número de cédula completo le faltan " + (10 - txtCedula.Text.Length).ToString() + " dígitos");
                    txtCedula.Focus();
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtNombres.Text = "";
            nudAbortos.Value = 0;
            nudCesareas.Value = 0;
            nudEmbarazos.Value = 0;
            nudPartos.Value = 0;
            txtCedula.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNombres.Focus();
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtApellidos.Focus();
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDireccion.Focus();
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

        private void nudAbortos_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudAbortos_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnRegistrar.Focus();
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cboGenero.Focus();
        }
    }
}
