using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace CapaAccesoDatos

{
    public static class DalUtil
    {
        public static readonly String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        public static readonly int CommandTimeout = 700;

        public static DataTable LlenarTabla(string comando)
        {
            SqlDataAdapter da = new SqlDataAdapter(comando, cnxStr);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch(SqlException ex)
            {
                //En caso falle el proceso de ejecución se devuelve false
                Trace.WriteLine(ex);
                return new DataTable();
            }
            return dt;
        }

        public static string GetSHA256(string str)
        {


            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);

            }
            return sb.ToString();
        }
    }

    public class ComandoSqlDF
    {
        public String Comando { get; set; }

        private readonly List<ParametroSqlDF>  parametros;
        public ComandoSqlDF(string comando)
        {
            parametros = new List<ParametroSqlDF>();
            this.Comando = comando;
        }

        public void Add(SqlDbType tipo, string nombre, Object valor)
        {
            parametros.Add(new ParametroSqlDF(tipo, nombre, valor));
        }

        public void AddInt(string nombre, int valor)
        {
            Add(SqlDbType.Int, nombre, valor);
        }

        public void AddString(string nombre, string valor)
        {
            Add(SqlDbType.VarChar, nombre, valor);
        }

        public bool Ejecutar()
        {
            bool state = false;
            Debug.WriteLine("Ejecutando comando: [" + Comando + "] con argumentos: " + PrintParameters());

            try
            {
                //se crea una nueva conexion sql
                using (SqlConnection cn = new SqlConnection(DalUtil.cnxStr))
                {
                    //Se genera el comando y se añaden los parametros
                    SqlCommand cmd = GetCmd(cn);

                    //se ejecuta el comando
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();

                }
            }
            catch (Exception ex)
            {
                //En caso falle el proceso de ejecución se devuelve false
                Trace.WriteLine(ex);
                return false;
            }
            //Si la ejecución funciona satisfactoriamente se devuelve true
            return state;
        }

        public DataTable EjecutarTabla()
        {
            DataTable dt = new DataTable();
            Debug.WriteLine("Ejecutando comando tabla: [" + Comando + "] con argumentos: " + PrintParameters());
            try
            {
                using (SqlConnection cn = new SqlConnection(DalUtil.cnxStr))
                {
                    //Se genera el comando y se añaden los parametros
                    SqlCommand cmd = GetCmd(cn);

                    //Se obtiene la tabla resultante y se convierte a un tipo DataTable
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                //En caso haya un error se devuelve null
                Trace.WriteLine(ex);
                return new DataTable();
            }
            return dt;
        }

        private SqlCommand GetCmd(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand(Comando, cn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = DalUtil.CommandTimeout
            };

            //Se añaden los parametros seleccionados al comando
            parametros.ForEach(p =>
            {
                cmd.Parameters.Add(p.nombre, p.tipo).Value = p.valor;
            });

            return cmd;
        }

        private String PrintParameters()
        {
            StringBuilder sb = new StringBuilder("[");

            parametros.ForEach( par => {
                sb.Append("(");
                sb.Append(par.nombre + ", ");
                sb.Append(par.valor.ToString());
                sb.Append(")");
            });
            sb.Append("]");
            return sb.ToString();
        }

        private class ParametroSqlDF
        {
            public ParametroSqlDF(SqlDbType tipo, string nombre, Object valor)
            {
                this.tipo = tipo;
                this.nombre = nombre;
                this.valor = valor;
            }
            public SqlDbType tipo { get; }
            public string nombre { get; }
            public Object valor { get; }
        }
    }

    public class TablaValores
    {
        private readonly DataRow row;

        public TablaValores(DataRow row)
        {
            this.row = row;
        }

        public Object Get(string campo)
        {
            Object obj = row[campo];
            return (obj == DBNull.Value) ? null : obj;
        }
        public int GetInt(string campo)
        {
            try
            {
                return Convert.ToInt32(Get(campo));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return 0;
            }
        }
        public string GetString(string campo)
        {
            try
            {
                Object obj = Get(campo);
                return obj == null ? "" : Get(campo).ToString();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return "";
            }
            
        }
        public double GetDouble(string campo)
        {
            try
            {
                return Convert.ToDouble(Get(campo));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return 0;
            }
        }
        public DateTime GetDateTime(string campo)
        {
            try
            {
                return Convert.ToDateTime(Get(campo));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return DateTime.MinValue;
            }
        }

    }
}
