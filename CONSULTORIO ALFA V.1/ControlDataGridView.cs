using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace CONSULTORIO_ALFA_V._1
{
    class ControlDataGridView
    {
        private DataTable unaTabla = new DataTable();
        private Conexion unaConexion;
        private OleDbDataReader uDr;
        DataGridView dataGridView1;
        private string estado;
        public ControlDataGridView(DataGridView dataGridView1)
        {
            this.dataGridView1 = dataGridView1;
            estado = "";
 
        }
        public DataTable llenarGridView(string sqlSentencia)
        {
            try
            {
                unaConexion = new Conexion();
                unaTabla.Load(unaConexion.Consultas(sqlSentencia));
                estado = "ok";
                dataGridView1.DataSource = unaTabla;
                return unaTabla;
            }
            catch (Exception ex)
            {
                estado = ex.Message.ToString();
                return null;
            }      
            
            
        }
        public DataTable obtenerTable(string[] columnas,string[] tipo,SqlDataReader sDr)
        {
            Type []tipos=new Type [10] ;
            for (int i = 0; i <= columnas.GetUpperBound(0); i++)
            {
                unaTabla.Columns.Add(columnas[i].ToUpper(), Type.GetType(tipo[i]));
                
            }
            int indice = 0;
            while (sDr.Read())
            {
                
                unaTabla.Rows.Add();
                for (int j = 0; j <= columnas.GetUpperBound(0); j++)
                {
                    string fila = "";
                    
                    fila = fila + sDr.GetValue(j).ToString();
                    if (j != columnas.GetUpperBound(0))
                    {
                        unaTabla.Rows[indice][j] = fila;
                    }
                    else
                    {
                        unaTabla.Rows[indice][j] = false;
                    }
                    
                    
                }
//                unaTabla.Rows.Add(fila);
                //unaTabla.Rows.Add(sDr.GetValue(0).ToString(), sDr.GetValue(1).ToString(), sDr.GetValue(2).ToString(), sDr.GetValue(3).ToString(), true.ToString());
                //DataGridViewRow rows = new DataGridViewRow();
                //unaTabla.Rows.Add(sDr.GetString(0), (1).ToString(), sDr.GetString(2), sDr.GetString(1), true);
                //string[] row1 = new string[] { sDr.GetString(0), (numero+1).ToString(),sDr.GetString(1), sDr.GetString(2),""};
                //dataGridView1.Rows.Add(row1);  
                indice++;

            }
            return unaTabla;
        }
        public void ColumnasNoVisible(string []columnas)
        {
            for (int i = 0; i <= columnas.GetUpperBound(0); i++)
            {
                dataGridView1.Columns[columnas[i]].Visible = false;
            }
            
        }
        public void AnchoColumnas(string []columnas,int[] anchoColumnas)
        {
            for (int i = 0; i <= anchoColumnas.GetUpperBound(0); i++)
            {
               this.dataGridView1.Columns[columnas[i]].Width = anchoColumnas[i];
                //dataGridView1.Columns[anchoColumnas[i]].Visible = false;
            }
 
        }
        public void columnasSoloLectura(string[] columnas)
        {
            for (int i = 0; i <= columnas.GetUpperBound(0); i++)
            {
                dataGridView1.Columns[columnas[i]].ReadOnly = true;
            }
 
        }
        public void diseñoCabecera(Color colorFondo, string tipoDeLetra, int tamañoLetra, FontStyle negritaCursivaSubrayada)
        {
            DataGridViewCellStyle estiloCabecera = new DataGridViewCellStyle();
            estiloCabecera.BackColor = colorFondo;
            estiloCabecera.Font = new Font(tipoDeLetra, tamañoLetra, negritaCursivaSubrayada);
            dataGridView1.ColumnHeadersDefaultCellStyle = estiloCabecera;
        }
        public void centrarTitulos()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public void filtrarGridView(string campoAFiltrar,string valorFiltrar)
        {
            DataTable tabla = dataGridView1.DataSource as DataTable;
            tabla.DefaultView.RowFilter = (campoAFiltrar + " like '" + valorFiltrar + "%'");
            dataGridView1.DataSource = tabla;            
        }
        public void marcarTodos(int columna,bool valorMarcar)
        {
            DataTable tabla = dataGridView1.DataSource as DataTable;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                tabla.Rows[i][columna] = valorMarcar;
                dataGridView1.DataSource = tabla;
 
            }

        }
        public void ColoresDeFondos(Color letra, Color celdas)
        {
            dataGridView1.DefaultCellStyle.ForeColor = letra;
            dataGridView1.DefaultCellStyle.BackColor = celdas;
        }
        public void ColoresDeFondosCeldasSeleccionadas(Color letra, Color celdas)
        {
            dataGridView1.DefaultCellStyle.SelectionForeColor = letra;
            dataGridView1.DefaultCellStyle.SelectionBackColor = celdas;
        }
        public void borrarGridView()
        {
            dataGridView1.DataSource = null;
            unaTabla.Clear();
        }
        public string Estado {
            get { return estado; }
        }
        public void tamaño(int ancho,int alto)
        {
            dataGridView1.Size = new System.Drawing.Size(ancho, alto);
        }
        
        
    }
}
