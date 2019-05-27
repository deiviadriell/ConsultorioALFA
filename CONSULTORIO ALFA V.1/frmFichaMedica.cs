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
    public partial class frmFichaMedica : Form
    {
        Conexion uC = new Conexion();
        string cedula = "";
        string edad = "";
        public frmFichaMedica(string cedula)
        {
            InitializeComponent();
            this.cedula = cedula;
            txtCedula.Text = cedula;
        }
        private void cargarImagen(string idEmpleado)
        {
            if (idEmpleado != "")
            {
                try
                {
                    foto.Load(System.IO.Directory.GetCurrentDirectory().ToString() + "\\imagenesEmpleados\\" + idEmpleado + ".jpg");
                }
                catch (Exception ex)
                {
                }
            }

        }
        private void frmFichaMedica_Load(object sender, EventArgs e)
        {
            lblConsultorio.Text = uC.obtenerUnValor("select nombre from consultorio");
            try
            {
                MySqlDataReader Dr = uC.Consultas("SELECT nombres,apellidos,direccion,genero,embarazos,partos,cesareas,abortos,telefono,email,fecha,fechaNacimiento,idPaciente from paciente inner join historiaclinica on idPaciente=Paciente_idPaciente where cedula='" + txtCedula.Text + "'");
                while (Dr.Read())
                {
                    txtNombres.Text = Dr.GetString(0);
                    txtApellidos.Text = Dr.GetString(1);
                    txtDireccion.Text = Dr.GetString(2);
                    cboGenero.Text = Dr.GetString(3);
                    
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
                        nudEmbarazos.Value = Convert.ToDecimal(Dr.GetString(4));
                        nudPartos.Value = Convert.ToDecimal(Dr.GetString(5));
                        nudCesareas.Value = Convert.ToDecimal(Dr.GetString(6));
                        nudAbortos.Value = Convert.ToDecimal(Dr.GetString(7));
                        lblAbortos.Visible = true;
                        lblCesareas.Visible = true;
                        lblEmbarazos.Visible = true;
                        lblPartos.Visible = true;

                        nudAbortos.Visible = true;
                        nudCesareas.Visible = true;
                        nudEmbarazos.Visible = true;
                        nudPartos.Visible = true;
                    }
                    txtTelefono.Text = Dr.GetString(8);
                    txtEmail.Text = Dr.GetString(9);
                    dtpFecha.Value = Dr.GetDateTime(10);
                    DateTime fechaNacimiento = Dr.GetDateTime(11);
                    cargarImagen((Dr.GetInt32(12)).ToString());
                    
                    int años=0, meses=0, dias = 0;
                    años = DateTime.Now.Year - fechaNacimiento.Year;
                    meses = DateTime.Now.Month - fechaNacimiento.Month;
                    if (meses < 0)
                    {
                        meses = 12 + meses;
                    }
                    if (meses == 1)

                        txtEdad.Text = años.ToString() + " años," + meses.ToString() + " mes";
                    else
                        txtEdad.Text = años.ToString() + " años," + meses.ToString() + " meses";




                }

            }
            catch (Exception ex)
            { }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
