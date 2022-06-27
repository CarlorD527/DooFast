using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

public class DalUtil
{
    public static readonly String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
    public static readonly int CommandTimeout = 700;

    public static DataTable LlenarTabla(string comando)
    {
        SqlDataAdapter da = new SqlDataAdapter(comando, cnxStr);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}

public class ComandoSqlDF
{
    public String Comando { get; set; }

    private List<ParametroSqlDF> parametros;
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

    public void AddSring(string nombre, string valor)
    {
        Add(SqlDbType.VarChar, nombre, valor);
    }

    public bool Ejecutar()
    {
        bool state = false;

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
            return null;
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
        parametros.ForEach(p => {
            cmd.Parameters.Add(p.nombre, p.tipo).Value = p.valor;
        });

        return cmd;
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
        return row[campo];
    }
    public int GetInt(string campo)
    {
        return Convert.ToInt32(Get(campo));
    }
    public string GetString(string campo)
    {
        return Get(campo).ToString();
    }
    public double GetDouble(string campo)
    {
        return Convert.ToDouble(Get(campo));
    }
    public DateTime GetDateTime(string campo)
    {
        return Convert.ToDateTime(Get(campo));
    }
}
