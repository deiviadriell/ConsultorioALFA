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
using System.Globalization;
using System.IO;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_nuevoPaciente : Form
    {
        List<string> sentencias = new List<string>();
        Conexion uC = new Conexion();
        string idPaciente = "";
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        public frm_nuevoPaciente(Conexion unaConexion)
        {
            
            InitializeComponent();
            //this.uC = unaConexion;
        }

        private void frm_nuevoPaciente_Load(object sender, EventArgs e)
        {
           // lblConsultorio.Text = uC.obtenerUnValor("select nombre from consultorio");
            txtCedula.Focus();
            lblExiste.Visible = false;
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
           
               
                
        }

        public string obtenerFechaParaSqlServer(DateTime fecha)
        {
            string dia = fecha.Day.ToString();
            string mes = fecha.Month.ToString();

            if (dia.Length < 2)
                dia = "0" + dia;
            if (mes.Length < 2)
                mes = "0" + mes;

            string  fechaRetorno = fecha.Year.ToString() + "-" + mes + "-" + dia;
            return fechaRetorno;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text != ""   && txtDireccion.Text != "" && txtNombres.Text != "")
            {
                try
                {

                    //Conexion uC = new Conexion();
                    //CultureInfo ci = new CultureInfo("Es-Es");
                    //uC.Insertar("INSERT INTO paciente (Cedula,Nombres,Apellidos,Direccion,Genero,Embarazos,Partos,Cesareas,Abortos,FechaNacimiento,Telefono,Email,fechaTexto)  values('" + txtCedula.Text + "','" + txtNombres.Text + "','" + txtApellidos.Text + "','" + txtDireccion.Text + "','" + cboGenero.Text + "','" + nudEmbarazos.Value.ToString() + "','" + nudPartos.Value.ToString() + "','" + nudCesareas.Value.ToString() + "','" + nudAbortos.Value.ToString() + "','"+obtenerFechaParaSqlServer(dtpFecha.Value )+"','"+txtTelefono.Text+"','"+txtEmail.Text+"','"+CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)) + " "+DateTime.Now.Day+" de " +meses[DateTime.Now.Month-1]+ " del " + DateTime.Now.Year.ToString()+"')");
                    //idPaciente = uC.obtenerUnValor("select * from paciente order by idpaciente desc limit 1");
                    //uC.Insertar("INSERT INTO historiaclinica (Fecha,Paciente_idPaciente) values('" + new Fecha().obtenerFechaParaMySql() + "','" + idPaciente + "')");
                    //uC.ejecutarTransacciones(sentencias);
                    if (uC.Estado == "ok")
                    {
                        guardaImagen("");
                        MessageBox.Show("El paciente ha sido registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult resultado = MessageBox.Show("Desea ir al formulario de consulta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            frm_consulta frm_consulta = new frm_consulta(idPaciente);
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
         private bool guardaImagen(string ruta ) 
         {
             //'creo la ruta
             string rutaProyecto;
             rutaProyecto = Directory.GetCurrentDirectory() + "\\imagenesEmpleados";
             if  (System.IO.Directory.Exists(rutaProyecto) !=true) 
             {
                 System.IO.Directory.CreateDirectory(rutaProyecto);
             }            
             string ID;
             rutaProyecto = rutaProyecto + "\\";
             if (idPaciente!= "" )
             {
                 try 
                 {
                     foto.Image.Save(rutaProyecto +idPaciente + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);                    
                     return true;
                 }
                 catch(Exception ex)
                 {
                     return false;
                 }
             }
             return false;
         }


         private void txtCedula_Leave(object sender, EventArgs e)
         {
             //verifico que la cédula ingresada no exista en la bd
             if (txtCedula.Text.Length == 10)
             {
                 try
                 {
                     if (uC.ObtenerNumeroDeFilas("SELECT * FROM paciente where cedula='" + txtCedula.Text + "'") > 0)
                     {
                         lblExiste.Visible = true;
                         txtCedula.Text = "";
                         txtCedula.Focus();
                     }
                 }
                 catch (Exception ex)
                 {
                 }
             }
         }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            this.foto.Image = global::CONSULTORIO_ALFA_V._1.Properties.Resources.NoDisponible;
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtNombres.Text = "";
            
            txtCedula.Focus();
            txtEmail.Text = "";
            txtTelefono.Text = "";
            dtpFecha.Value = DateTime.Now;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                //txtNombres.Focus();
                cboGenero.Focus();
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back && (!(e.KeyChar == (char)Keys.Delete)))
            {
                e.Handled = true;
            }
            
            else
                e.Handled = false;
            
            
            
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
           
        }

        private void nudPartos_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void nudCesareas_KeyPress(object sender, KeyPressEventArgs e)
        {
           
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
                txtTelefono.Focus();
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                //openFileDialog1.Filter = "Archivos de Imagen (BMP,JPG, GIF) ǀ*.bmp;*.jpg;*.gif";
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

        private void cboGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNombres.Focus();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            dtpFecha.Focus();
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back && (!(e.KeyChar == (char)Keys.Delete)))
            {
                e.Handled = true;
            }

            else
                e.Handled = false;
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtEmail.Focus();
        }

        private void txtCedula_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (uC.Insertar("INSERT INTO paciente (cedula,nombres,apellidos,direccion,telefono,correo,fecNacimiento,genero) values ('" + txtCedula.Text + "','" + txtNombres.Text + "','" + txtApellidos.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text + "','" + txtEmail.Text + "','" + dtpFecha.Value + "','" + cboGenero.SelectedText + "')") > 0)
            {
                MessageBox.Show("Paciente registrado");
            }
            else
            {
                MessageBox.Show("Problemas al intentar guardar:" + uC.Estado);
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
