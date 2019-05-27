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
        string idPaciente = "";
        public frm_editarPaciente()
        {
            InitializeComponent();
        }
         private void cargarImagen(string idEmpleado)
         {
             if (idEmpleado != "" )
             {
                 try
                 {
                     foto.Load(System.IO.Directory.GetCurrentDirectory().ToString() + "\\imagenesEmpleados\\" + idEmpleado+".jpg");
                 }
                 catch(Exception ex)
                 {
                 }
             }
            
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
                            idPaciente = sDr.GetInt32(0).ToString();
                            txtApellidos.Text = sDr.GetString(3);
                            txtDireccion.Text = sDr.GetString(4);
                            cboGenero.Text = sDr.GetString(5);
                            //txtHistoriaClinica.Text = sDr.GetInt32(4).ToString();
                            txtNombres.Text = sDr.GetString(2);
                            nudEmbarazos.Value = sDr.GetInt32(6);
                            nudPartos.Value = sDr.GetInt32(7);
                            nudCesareas.Value = sDr.GetInt32(8);
                            nudAbortos.Value = sDr.GetInt32(9);
                            txtNombres.Focus();
                            dtpFecha.Value = sDr.GetDateTime(10);
                            txtTelefono.Text = sDr.GetString(11);
                            txtEmail.Text = sDr.GetString(12);
                            cargarImagen(idPaciente);


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
                txtNombres.Focus();
            }
        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGenero.Text == "FEMENINO")
            {
               // groupBox1.Enabled = true;
                nudEmbarazos.Focus();
            }
            else
            {
                //groupBox1.Enabled = false;
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
            nudAbortos.Value = 0;
            nudCesareas.Value = 0;
            nudEmbarazos.Value = 0;
            nudPartos.Value = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool guardaImagen(string ruta)
        {
            //'creo la ruta
            string rutaProyecto;
            rutaProyecto = System.IO.Directory.GetCurrentDirectory() + "\\imagenesEmpleados";
            if (System.IO.Directory.Exists(rutaProyecto) != true)
            {
                System.IO.Directory.CreateDirectory(rutaProyecto);
            }
            string ID;
            rutaProyecto = rutaProyecto + "\\";
            if (idPaciente != "")
            {
                try
                {
                    foto.Image.Save(rutaProyecto + idPaciente + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (idPaciente!="")
            {
                try
                {

                    Conexion uC = new Conexion();
                    sentencias.Add("update paciente set cedula='"+txtCedula.Text+"', Nombres='" + txtNombres.Text + "', apellidos='" + txtApellidos.Text + "', Direccion='" + txtDireccion.Text + "',Genero='" + cboGenero.Text + "',Embarazos='" + Convert.ToInt32(nudEmbarazos.Value) + "', partos='" + Convert.ToInt32(nudPartos.Value) + "', Cesareas='" + Convert.ToInt32(nudCesareas.Value) + "', abortos='" + Convert.ToInt32(nudAbortos.Value) + "' where idPaciente='" + idPaciente+ "'");
                    //sentencias.Add("INSERT INTO historiaclinica (Fecha,Paciente_Cedula) values(" + new Fecha().obtenerFechaParaAccess() + ",'" + txtCedula.Text + "')");
                    uC.ejecutarTransacciones(sentencias);
                    if (uC.Estado == "ok")
                    {
                        guardaImagen("");
                        MessageBox.Show("Los datos del paciente han sido actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLimpiar_Click(sender, e);
                        idPaciente = "";

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

            if (frm_buscarpaciente.obtenerCedula() != "")
            {
                idPaciente = frm_buscarpaciente.obtenerCedula();
                MySqlDataReader MySdr=uC.Consultas("select * from paciente where idPaciente='" + frm_buscarpaciente.obtenerCedula() + "'");
                if (MySdr.HasRows)
                {
                    while (MySdr.Read())
                    {
                        idPaciente = MySdr.GetInt32(0).ToString();
                        txtCedula.Text = MySdr.GetString(1);
                        txtNombres.Text = MySdr.GetString(2);
                        txtApellidos.Text = MySdr.GetString(3);
                        txtDireccion.Text = MySdr.GetString(4);
                        cboGenero.Text=MySdr.GetString(5);

                        nudEmbarazos.Value = MySdr.GetInt32(6);
                        nudPartos.Value = MySdr.GetInt32(7);
                        nudCesareas.Value = MySdr.GetInt32(8);
                        nudAbortos.Value = MySdr.GetInt32(9);
                        dtpFecha.Value = MySdr.GetDateTime(10);
                        txtTelefono.Text = MySdr.GetString(11);
                        txtEmail.Text = MySdr.GetString(12);


                    }
                }
                //txtCedula.Text = frm_buscarpaciente.obtenerCedula();
                //btnBuscar_Click(sender, e);
                
            }           
            else
                btnLimpiar_Click(sender, e);
        }

        private void frm_editarPaciente_Load(object sender, EventArgs e)
        {
            lblConsultorio.Text = uC.obtenerUnValor("select nombre from consultorio");
            txtCedula.CharacterCasing = CharacterCasing.Upper;
            txtApellidos.CharacterCasing = CharacterCasing.Upper;
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
            txtNombres.CharacterCasing = CharacterCasing.Upper;

            toolTip1.SetToolTip(txtCedula, "Ingrese un número de cédula");
            toolTip1.SetToolTip(txtNombres, "Ingrese los nombres del paciente");
            toolTip1.SetToolTip(txtApellidos, "Ingrese los apellidos del paciente");
            toolTip1.SetToolTip(txtDireccion, "Ingrese la dirección del paciente");
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtApellidos.Focus();
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDireccion.Focus();
            }
        }

        private void nudEmbarazos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                nudPartos.Focus();
            }
        }

        private void nudPartos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                nudCesareas.Focus();
            }
        }

        private void nudCesareas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                nudAbortos.Focus();
            }
        }

        private void nudAbortos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnRegistrar.Focus();
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void txtCedula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
                btnBuscar_Click(sender, e);
        }

        private void cboGenero_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboGenero.Text == "MASCULINO")
            {
                lblAbortos.Visible = false;
                lblCesareas.Visible = false;
                lblEmbarazos.Visible = false;
                lblPartos.Visible = false;

                nudAbortos.Visible = false;
                nudCesareas.Visible = false;
                nudEmbarazos.Visible = false;
                nudPartos.Visible = false;

            }
            else
            {
                
                lblAbortos.Visible = true;
                lblCesareas.Visible = true;
                lblEmbarazos.Visible = true;
                lblPartos.Visible = true;

                nudAbortos.Visible = true;
                nudCesareas.Visible = true;
                nudEmbarazos.Visible = true;
                nudPartos.Visible = true;
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                //openFileDialog1.Filter = "Archivos de Imagen (BMP,JPG, GIF) ǀ*.bmp;*.jpg;*.gif";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Seleccionar foto del paciente";
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foto.Load(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar cargar la imagen en: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

