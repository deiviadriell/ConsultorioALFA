using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_buscarpaciente : Form
    {
        ControlDataGridView dgv;
        string cedula = "";
        string id = "";
        public frm_buscarpaciente()
        {
            InitializeComponent();
            dgv = new ControlDataGridView(dataGridView1);
        }

        private void frm_buscarpaciente_Load(object sender, EventArgs e)
        {
            cboBuscar.SelectedIndex = 0;
            toolTip1.SetToolTip(txtBuscar, "Ingrese el parámetro de busquedad");
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string consulta = "SELECT historiaclinica.idHistoriaClinica as HistoriaClinica, paciente.Cedula as Cedula, paciente.Apellidos, paciente.Nombres,paciente.idPaciente FROM historiaclinica INNER JOIN paciente ON historiaclinica.Paciente_idPaciente = paciente.idPaciente ";
                if (cboBuscar.SelectedIndex == 0)
                {
                    consulta = consulta + "where idHistoriaClinica like '" + txtBuscar.Text + "%'";
                }
                else if (cboBuscar.SelectedIndex == 1)
                {
                    consulta = consulta + "where Cedula like '" + txtBuscar.Text + "%'";
                }
                else if (cboBuscar.SelectedIndex == 2)
                {
                    consulta = consulta + "where apellidos like '" + txtBuscar.Text + "%'";
                }
                else if (cboBuscar.SelectedIndex == 3)
                {
                    consulta = consulta + "where nombres like '" + txtBuscar.Text + "%'";
                }
                consulta = consulta + " LIMIT 250 ";
                dgv.borrarGridView();
                dgv.llenarGridView(consulta);
                string[] columnas = { "HistoriaClinica", "Cedula", "Apellidos", "Nombres" };
                int[] anchoColumnas = { 85, 75, 185, 185 };            
                dgv.AnchoColumnas(columnas, anchoColumnas);  
                string []novisibles={"idPaciente"};
                dgv.ColumnasNoVisible(novisibles);
                dataGridView1.ReadOnly = true;
               
            }
            catch (Exception ex)
            { }
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.borrarGridView();
            txtBuscar.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != dataGridView1.Rows.Count - 1)
                {

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1[i, e.RowIndex].Style.BackColor = Color.DodgerBlue;
                        dataGridView1[i, e.RowIndex].Style.ForeColor = Color.White;                        
                        cedula = dataGridView1[4, e.RowIndex].Value.ToString();
                        //unDocentes = new Docente(dataGridView1[0, e.RowIndex].Value.ToString(), dataGridView1[1, e.RowIndex].Value.ToString(), dataGridView1[2, e.RowIndex].Value.ToString(), dataGridView1[3, e.RowIndex].Value.ToString(), dataGridView1[4, e.RowIndex].Value.ToString(), dataGridView1[5, e.RowIndex].Value.ToString(), dataGridView1[6, e.RowIndex].Value.ToString());                        
                        /*DataTable tabla = dataGridView1.DataSource as DataTable;
                        unRepresentante = new Representante((tabla.Rows[e.RowIndex][6]).ToString(), (tabla.Rows[e.RowIndex][7]).ToString(), (tabla.Rows[e.RowIndex][8]).ToString(), (tabla.Rows[e.RowIndex][9]).ToString(), (tabla.Rows[e.RowIndex][10]).ToString(), (tabla.Rows[e.RowIndex][11]).ToString());
                        unAlumno = new Alumnos((tabla.Rows[e.RowIndex][0]).ToString(), (tabla.Rows[e.RowIndex][3]).ToString(), (tabla.Rows[e.RowIndex][2]).ToString(), (tabla.Rows[e.RowIndex][1]).ToString(), Convert.ToDateTime((tabla.Rows[e.RowIndex][4]).ToString()), unRepresentante, (tabla.Rows[e.RowIndex][5]).ToString(), (tabla.Rows[e.RowIndex][15]).ToString());
                        idCurso = (tabla.Rows[e.RowIndex][12]).ToString();
                        idParalelo = (tabla.Rows[e.RowIndex][13]).ToString();
                        idSeccion = (tabla.Rows[e.RowIndex][14]).ToString();*/
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {

                                dataGridView1[j, i].Style.BackColor = Color.White;
                                dataGridView1[j, i].Style.ForeColor = Color.Black;
                            }
                        }
                    }
                }
                else
                {
                    //unAlumno = null;
                    cedula = "";
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1[i, e.RowIndex].Style.BackColor = Color.DodgerBlue;
                        dataGridView1[i, e.RowIndex].Style.ForeColor = Color.White;
                        //unDocentes = new Docente(dataGridView1[0, e.RowIndex].Value.ToString(), dataGridView1[1, e.RowIndex].Value.ToString(), dataGridView1[2, e.RowIndex].Value.ToString(), dataGridView1[3, e.RowIndex].Value.ToString(), dataGridView1[4, e.RowIndex].Value.ToString(), dataGridView1[5, e.RowIndex].Value.ToString(), dataGridView1[6, e.RowIndex].Value.ToString());


                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {

                                dataGridView1[j, i].Style.BackColor = Color.White;
                                dataGridView1[j, i].Style.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cedula = "";
                
                ex = null;
                //unAlumno = null;
            }
        }
        public string obtenerCedula()
        {
            return cedula;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cedula != "")
            {
                Close();
            }
            else
            {
                DialogResult resultado = MessageBox.Show("No ha seleccionado ningún paciente, seguro desea salir?", "Confirmación", MessageBoxButtons.YesNoCancel);
                if (resultado == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cedula = dataGridView1[4, e.RowIndex].Value.ToString();
            Close();
        }

        private void frm_buscarpaciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cedula == "")
            {
                DialogResult resultado = MessageBox.Show("No ha seleccionado ningún paciente, seguro desea salir?", "Confirmación", MessageBoxButtons.YesNoCancel);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }



            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            

        }
    }
}
