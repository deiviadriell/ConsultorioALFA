using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace CONSULTORIO_ALFA_V._1
{
    public partial class frm_historiaclinica : Form
    {
        string idHistoriaClinica;
        string nombres;
        ControlDataGridView dgv;
        DataGridViewPrinter MyDataGridViewPrinter;
        string genero = "";
        public frm_historiaclinica(string idHistoriaClinica, string nombres,string genero)
        {
            InitializeComponent();
            this.idHistoriaClinica = idHistoriaClinica;
            this.nombres = nombres;
            this.genero = genero;
            dgv = new ControlDataGridView(dataGridView1);
        }

        private void frm_historiaclinica_Load(object sender, EventArgs e)
        {
            lblpaciente.Text = nombres.ToUpper();
            dgv.borrarGridView();
            string[] columnas = null;
            int[] anchoColumnas = null;
            if (genero == "FEMENINO")
            {
                dgv.llenarGridView("SELECT  consultas.Fecha, signosvitales.Peso, signosvitales.Temperatura, signosvitales.Presion, signosvitales.FUM, consultas.Sintomas, consultas.Prescripcion FROM paciente INNER JOIN (signosvitales INNER JOIN (historiaclinica INNER JOIN consultas ON historiaclinica.idHistoriaClinica = consultas.HistoriaClinica_idHistoriaClinica) ON signosvitales.idSignosVitales = consultas.SignosVitales_idSignosVitales) ON paciente.idPaciente = historiaclinica.Paciente_idPaciente where idHistoriaclinica=" + idHistoriaClinica + " ;");

                columnas = new string[] { "Fecha", "Peso", "Temperatura", "Presion", "FUM", "Sintomas", "Prescripcion" };
                anchoColumnas = new int [] { 70, 70, 70, 60, 75, 300, 285 };
            }
            else
            {

                dgv.llenarGridView("SELECT  consultas.Fecha, signosvitales.Peso, signosvitales.Temperatura, signosvitales.Presion, consultas.Sintomas, consultas.Prescripcion FROM paciente INNER JOIN (signosvitales INNER JOIN (historiaclinica INNER JOIN consultas ON historiaclinica.idHistoriaClinica = consultas.HistoriaClinica_idHistoriaClinica) ON signosvitales.idSignosVitales = consultas.SignosVitales_idSignosVitales) ON paciente.idPaciente = historiaclinica.Paciente_idPaciente where idHistoriaclinica=" + idHistoriaClinica + " ;");
                columnas = new string[] { "Fecha", "Peso", "Temperatura", "Presion","Sintomas", "Prescripcion" };
                anchoColumnas = new int[] { 70, 70, 70, 60, 335, 305 };
 
            }
            dgv.AnchoColumnas(columnas, anchoColumnas);
            dataGridView1.ReadOnly = true;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        //private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
        //    if (more == true)
        //        e.HasMorePages = true;
        //}
        //private bool SetupThePrinting() // procedimientos para configurar la impresion
        //{
        //    PrintDialog MyPrintDialog = new PrintDialog();
        //    MyPrintDialog.AllowCurrentPage = false; // perimitir pagina actual
        //    MyPrintDialog.AllowPrintToFile = false; //permitir impresion a archivo
        //    MyPrintDialog.AllowSelection = false; // permitir seleccion
        //    MyPrintDialog.AllowSomePages = false; //permitir algunas paginas
        //    MyPrintDialog.PrintToFile = false;// imprimir a archivo
        //    MyPrintDialog.ShowHelp = false; //mostrar ayuda
        //    MyPrintDialog.ShowNetwork = false; // mostrar red

        //    if (MyPrintDialog.ShowDialog() != DialogResult.OK)
        //        return false;

        //    MyPrintDocument.DocumentName = "REPORTE"; //nombre del docuemnto
        //    MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings; // ajustes de impresion
        //    MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings; //ajustes por defecto
        //    MyPrintDocument.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10); //mergenes de la impresion
        //    MyPrintDocument.DefaultPageSettings.Landscape = true;


        //    if (MessageBox.Show("Desea ver el reporte centrado en la pagina", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, true, true, "HISTORIA CLINICA " + nombres + "", new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
        //    else
        //        MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, false, true, "HISTORIA CLINICA " + nombres + "", new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

        //    return true;
        //}

        //private void btnRegistrar_Click(object sender, EventArgs e)
        //{
        //    if (SetupThePrinting())
        //        MyPrintDocument.Print();
        //}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
