using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using MySql.Data.MySqlClient;


namespace CONSULTORIO_ALFA_V._1
{
    public class Conexion
    {

        private MySqlConnection sqlConexion;
        private MySqlCommand sqlComando;
        private MySqlDataReader sqlDr;
        private string estado;
        
        private List<string> listaRetorno;

        
        public Conexion()
        {
            try
            {

                sqlConexion = new MySqlConnection("Server=localhost;Database=consultoriomedico;User id=root;Password=1234;Convert Zero Datetime=true");                  
                sqlConexion.Open();
                estado = "ok";
                sqlConexion.Close();
                sqlDr = null;
                sqlComando = new MySqlCommand();
                listaRetorno = new List<string>();
            }
            catch (MySqlException ex)
            {
                estado = ex.Message;
                            
            }
        
        }
        //Instancias Instaladas
        public List<string> obtenerServidores()
        {
            SqlDataSourceEnumerator instancias = SqlDataSourceEnumerator.Instance;
            DataTable unaTabla = instancias.GetDataSources();
            for (int i = 0; i < unaTabla.Rows.Count; i++)
            {
                listaRetorno.Add((unaTabla.Rows[0][i]).ToString());
            }
            return listaRetorno;
 
        }
        public int Insertar(string sqlSentencia)
        {
            try
             {
                if (estado == "ok")
                {
                    int filasAfectadas = 0;
                    if (sqlConexion.State.ToString() == "Open")
                        sqlConexion.Close();
                    sqlConexion.Open();
                    sqlComando = new MySqlCommand(sqlSentencia, sqlConexion);
                    filasAfectadas = sqlComando.ExecuteNonQuery();
                    sqlConexion.Close();
                    estado = "ok";
                    return filasAfectadas;
                }
                else
                {
                    estado = "Problema con la conexión en " + estado;
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                sqlConexion.Close();
                estado = "Error al intentar guardar en "+ex.Message.ToString();
                return 0;
            }
            
        }
        
        public int ObtenerNumeroDeFilas(string sqlSentencia)
        {

            try
            {
                int numeroFilas = 0;
                sqlComando = new MySqlCommand(sqlSentencia,sqlConexion);
                sqlConexion.Open();
                numeroFilas = int.Parse(sqlComando.ExecuteScalar().ToString());
                estado = "ok";
                sqlConexion.Close();
                return numeroFilas;
                
            }
            catch (Exception error)
            {
                estado = error.Message.ToString();
                sqlConexion.Close();
                return 0;
            }
            
            return 0;
             
        }
        public string obtenerUnValor(string sqlSentencia)
        {
            try
            {
                if (estado == "ok")
                {
                    string retorno = "";
                    sqlComando = new MySqlCommand(sqlSentencia, sqlConexion);
                    if (sqlConexion.State.ToString() != "Open")
                        sqlConexion.Open();
                    retorno = (sqlComando.ExecuteScalar().ToString());
                    estado = "ok";
                    sqlConexion.Close();
                    return retorno;
                }
                else
                {
                    estado = "Problema con la conexión en " + estado;
                    return "";
                }

            }
            catch (MySqlException error)
            {
                estado = "Error al intentar cargar los datos en "+error.Message.ToString();
                sqlConexion.Close();
                return "";
            }
            
 
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        
        }

        public MySqlDataReader Consultas(string sqlConsulta)
        {
            try
            {
                if (sqlConexion.State.ToString()=="Open")
                    sqlConexion.Close();
                sqlComando = new MySqlCommand(sqlConsulta, sqlConexion);
                sqlConexion.Open();
                MySqlDataReader sqlDr = sqlComando.ExecuteReader();
            
                estado = "ok";
                return sqlDr;
                
            }
            catch (MySqlException ex)
            {
                estado = ex.Message.ToString();
                return null;
            }
        }
        public MySqlDataAdapter Consulta(string sqlSentencia)
        {

           /* SqlDataAdapter sqlDa = new SqlDataAdapter(sqlSentencia, sqlConexion);
            SqlCommandBuilder cB = new SqlCommandBuilder(sqlDa);
            return sqlDa;*/
            return null;
            
        }
        public void AbrirConexion()
        {
            sqlConexion.Open();
        }
        public void CerrarConexion()
        {
            sqlConexion.Close();
        }
        public bool ejecutarTransacciones(List<string>sentencias)
        {
            sqlConexion.Open();
            MySqlTransaction transaction;
            MySqlCommand transacciones = sqlConexion.CreateCommand();
            // Start a local transaction.
            
            transaction = sqlConexion.BeginTransaction();
            transacciones.Connection = sqlConexion;
            transacciones.Transaction = transaction;
            try
            {
                for (int i = 0; i < sentencias.Count; i++)
                {
                    transacciones.CommandText = sentencias[i];
                    transacciones.ExecuteNonQuery();
                }   
                transaction.Commit();
                estado = "ok";
                sqlConexion.Close();
                return true;
                
            }
            catch (Exception ex)
            {
                estado = "excepcion en commit tipo " + ex.GetType()+":Error "+ex.Message+"\n";

                // Attempt to roll back the transaction. 
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {   
                    estado = estado + " Exception rollback "+ex2.GetType()+"mensaje: "+ex2.Message;
                    
                }
                sqlConexion.Close();
                return false;
            }
            
        }
        
    }
}
