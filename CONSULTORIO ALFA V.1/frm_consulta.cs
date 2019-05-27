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
using System.Globalization;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_consulta : Form
    {
        CultureInfo ci=new CultureInfo("Es-Es");
        Conexion uC;
        string cedula="";
        string genero = "";
        string fecha = "";
        string[] diasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
        string[] meses = { "Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"};
        
        public frm_consulta(string cedula)
        {
            InitializeComponent();
            uC = new Conexion();
            this.cedula = cedula;
            fecha = "Fecha: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)) + " "+DateTime.Now.Day+" de " +meses[DateTime.Now.Month-1]+ " del " + DateTime.Now.Year.ToString();

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
            txtPaciente.Text = "";
            txtCedula.Text = "";
           
            txtHistoriaClinica.Text = "";
            genero = "";
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
               // if (txtCedula.Text.Length == 10)
                //{
                    try
                    {

                        MySqlDataReader sDr = uC.Consultas("SELECT paciente.Cedula,paciente.Apellidos,paciente.Nombres,paciente.Genero,historiaclinica.idHistoriaClinica,paciente.Direccion FROM paciente inner join historiaclinica on paciente.idPaciente= historiaclinica.Paciente_idPaciente where cedula='" + txtCedula.Text + "'");
                        if (sDr.HasRows)
                        {
                            while (sDr.Read())
                            {
                               cedula = sDr.GetInt32(0).ToString();
                               txtPaciente.Text = sDr.GetString(2) +" "+sDr.GetString(1);                               
                                genero = sDr.GetString(3);
                                txtHistoriaClinica.Text = sDr.GetInt32(4).ToString();                                
                                label16.Visible = true;
                                txtPeso.Focus();
                                label6.Visible = true;
                                if (genero == "FEMENINO")
                                {
                                    //lblFecha.Visible = true;
                                    lblFum.Visible = true;
                                    lblGestas.Visible = true;
                                    dtpfum.Visible = true;
                                }
                                else
                                {
                                    //lblFecha.Visible = false;
                                    lblFum.Visible = false;
                                    lblGestas.Visible = false;
                                    dtpfum.Visible = false;
                                }
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

        private void label2_Click_1(object sender, EventArgs e)
        {
            frm_buscarpaciente frm_buscarpaciente = new frm_buscarpaciente();
            frm_buscarpaciente.ShowDialog();
            txtCedula.Text = frm_buscarpaciente.obtenerCedula();
            if (frm_buscarpaciente.obtenerCedula() != "")
            {
               string  idPaciente = frm_buscarpaciente.obtenerCedula();
               MySqlDataReader MySdr = uC.Consultas("SELECT paciente.Cedula,paciente.Apellidos,paciente.Nombres,paciente.Genero,paciente.direccion,historiaclinica.idHistoriaClinica,paciente.Direccion FROM paciente inner join historiaclinica on paciente.idPaciente= historiaclinica.Paciente_idPaciente where idPaciente='" + idPaciente + "'");
                if (MySdr.HasRows)
                {
                    while (MySdr.Read())
                    {
                        //idPaciente = MySdr.GetInt32(0).ToString();
                        txtCedula.Text = MySdr.GetString(0);
                        
                        txtPaciente.Text = MySdr.GetString(2)+" "+MySdr.GetString(1);
                        txtPeso.Focus();
                        txtHistoriaClinica.Text = MySdr.GetString(5);
                        label16.Visible = true;
                        genero = MySdr.GetString(3);
                        label6.Visible = true;
                        if (genero == "FEMENINO")
                        {
                           // lblFecha.Visible = true;
                            lblFum.Visible = true;
                            lblGestas.Visible = true;
                            dtpfum.Visible = true;
                        }
                        else
                        {
                           // lblFecha.Visible = false;
                            lblFum.Visible = false;
                            lblGestas.Visible = false;
                            dtpfum.Visible = false;
                        }

                        //nudEmbarazos.Value = MySdr.GetInt32(6);
                        //nudPartos.Value = MySdr.GetInt32(7);
                        //nudCesareas.Value = MySdr.GetInt32(8);
                        //nudAbortos.Value = MySdr.GetInt32(9);

                    }
                }
                //btnBuscar_Click(sender, e);
            }
            else
                limpiar();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            frm_historiaclinica frm_historiaclinica = new frm_historiaclinica(txtHistoriaClinica.Text, txtPaciente.Text ,genero);
            frm_historiaclinica.Show();
        }

        private void frm_consulta_Load(object sender, EventArgs e)
        {
            lblConsultorio.Text= uC.obtenerUnValor("select nombre from consultorio");
           // lblFecha.Visible = false;
            lblFum.Visible = false;
            lblGestas.Visible = false;
            //MessageBox.Show();
            label16.Visible = false;
            dtpfum.Visible = false;
            label6.Visible = false;
            lblFecha.Visible = true;
            if (cedula != "")
            {

                try
                {

                    MySqlDataReader sDr = uC.Consultas("SELECT paciente.Cedula,paciente.Apellidos,paciente.Nombres,paciente.Genero,historiaclinica.idHistoriaClinica,paciente.Direccion FROM paciente inner join historiaclinica on paciente.idPaciente= historiaclinica.Paciente_idPaciente where idPaciente='" + cedula + "'");
                    if (sDr.HasRows)
                    {
                        while (sDr.Read())
                        {
                            cedula = sDr.GetInt32(0).ToString();
                            txtCedula.Text = cedula;
                            txtPaciente.Text = sDr.GetString(2) + " " + sDr.GetString(1);
                            genero = sDr.GetString(3);
                            txtHistoriaClinica.Text = sDr.GetInt32(4).ToString();
                            label16.Visible = true;
                            txtPeso.Focus();
                            label6.Visible = true;
                            if (genero == "FEMENINO")
                            {
                               // lblFecha.Visible = true;
                                lblFum.Visible = true;
                                lblGestas.Visible = true;
                                dtpfum.Visible = true;
                            }
                            else
                            {
                               // lblFecha.Visible = false;
                                lblFum.Visible = false;
                                lblGestas.Visible = false;
                                dtpfum.Visible = false;
                            }
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
                txtCedula.Focus();
            

            txtPaciente.CharacterCasing = CharacterCasing.Upper;
            txtCedula.CharacterCasing = CharacterCasing.Upper;
           
            
            txtHistoriaClinica.CharacterCasing = CharacterCasing.Upper;
           
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


           
           
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtHistoriaClinica.Text!=""&& txtPresion.Text != "" && txtPeso.Text != "" && txtTemperatura.Text != ""&& txtPrescripcion.Text != "" && txtSintomas.Text != "")
            {
                uC.Estado = "ok";
                int filas_afectadas = 0;
                if (genero == "FEMENINO")
                    filas_afectadas = uC.Insertar("INSERT INTO signosvitales (Peso,Temperatura,Presion,FUM,Estatura) values('" + txtPeso.Text.ToString() + "','" + txtTemperatura.Text + "','" + txtPresion.Text + "','" + new Fecha().obtenerFechaParaMySql(dtpfum.Value) + "','"+txtEstatura.Text+"');");
                else
                {
                    filas_afectadas = uC.Insertar("INSERT INTO signosvitales (Peso,Temperatura,Presion,FUM,Estatura) values('" + txtPeso.Text.ToString() + "','" + txtTemperatura.Text + "','" + txtPresion.Text + "','0000-00-00','"+txtEstatura.Text+"');");
                }
                filas_afectadas = filas_afectadas + uC.Insertar("insert into consultas (Fecha,Sintomas,Prescripcion,HistoriaClinica_idHistoriaClinica,SignosVitales_idSignosVitales,Doctor_idDoctor,hora) values('" + new Fecha().obtenerFechaParaMySql(dtpfum.Value) + "','" + txtSintomas.Text + "','" + txtPrescripcion.Text + "','" + txtHistoriaClinica.Text + "','" + uC.obtenerUnValor("select * from signosvitales order by idSignosVitales desc limit 1") + "','1','"+DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes + ":" + DateTime.Now.TimeOfDay.Seconds+"')");
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
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back && (!(e.KeyChar == (char)Keys.Delete)))
            {
                e.Handled = true;
            }

            else
                e.Handled = false;
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTemperatura.Focus();
        }

        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPresion.Focus();
        }

        private void txtPresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtEstatura.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPaciente.Text = "";
            txtCedula.Text = "";
           
            txtHistoriaClinica.Text = "";
            
            txtPeso.Text = "";
            txtPrescripcion.Text = "";
            txtPresion.Text = "";
            txtSintomas.Text = "";
            txtTemperatura.Text = "";
            label16.Visible = false;
           // lblFecha.Visible = false;
            lblFum.Visible = false;
            lblGestas.Visible = false;
            txtEstatura.Text = "";
            dtpfum.Visible = false;
            label6.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGenero_TextChanged(object sender, EventArgs e)
        {
           // if (txtGenero.Text == "MASCULINO")
            {
                dtpfum.Visible = false;
                lblFum.Visible = false;
            }
           // else
            {
                dtpfum.Visible = true;
                lblFum.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = fecha + " Hora: " + DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes + ":" + DateTime.Now.TimeOfDay.Seconds;
        }

        private void txtEstatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (genero == "FEMENINO")
                {
                    dtpfum.Focus();
                }
                else
                    txtSintomas.Focus();
            }
        }

        private void lblGestas_Click(object sender, EventArgs e)
        {
            frmGestas frm = new frmGestas(txtCedula.Text);
            frm.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (txtPaciente.Text != "")
            {
                frmFichaMedica frm = new frmFichaMedica(txtCedula.Text);
                frm.Show();
 
            }
        }
    }
}
