using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ComidaDal
    {

        
        // Crear comida 
        public bool Add(ComidaBe obj) {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_CrearComida");
            //Se añaden los parametros
            cmd.AddString("@nombreComida", obj.nombreComida);
            cmd.Add(SqlDbType.Money, "@precio", obj.precio);
            cmd.AddString("@imagen", obj.imagen);
            cmd.Add(SqlDbType.Money, "@costo", obj.costo);
            cmd.AddInt("@idCategoria", obj.idCategoria);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();


            /*
            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_CrearComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.Add("@nombreComida", SqlDbType.VarChar).Value = obj.nombreComida;
                    cmd.Parameters.Add("@precio", SqlDbType.Money).Value = obj.precio;
                    cmd.Parameters.Add("@costo", SqlDbType.Money).Value = obj.costo;
                    cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = obj.idCategoria;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return state;*/
        }

        //Listar comidas
        public List<ComidaBEforList> listarComidas()
        {
            List<ComidaBEforList> lstComidasCarta = new List<ComidaBEforList>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_listarComidas");
            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaComidas = cmd.EjecutarTabla();
            for (int i = 0; i < tablaComidas.Rows.Count; i++)
            {
                lstComidasCarta.Add(
                    ComidaDal.ObtenerCamposComida(
                        new TablaValores(tablaComidas.Rows[i])
                    )
                );
            }
            return lstComidasCarta;

            /*
            SqlDataAdapter da = new SqlDataAdapter("usp_listarComidas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ComidaBEforList> lstComidas = new List<ComidaBEforList>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComidaBEforList comida = new ComidaBEforList();

                    ObtenerCamposDt(dt, ref comida, i);

                    lstComidas.Add(comida);
                }
            }
            if (lstComidas.Count > 0)
            {
                return lstComidas;
            }
            else
            {
                List<ComidaBEforList> lstComidasVacia = new List<ComidaBEforList>();
                return lstComidasVacia;
            }*/
        }

        //Obtener una comida
        public List<ComidaBEforList> listarComida(int idComida)
        {

            List<ComidaBEforList> lstComidasCarta = new List<ComidaBEforList>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_listarComidas");
            //Se añaden los parametros
            cmd.AddInt("@idComida", idComida);
            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaComidas = cmd.EjecutarTabla();
            for (int i = 0; i < tablaComidas.Rows.Count; i++)
            {
                lstComidasCarta.Add(
                    ComidaDal.ObtenerCamposComida(
                        new TablaValores(tablaComidas.Rows[i])
                    )
                );
            }
            return lstComidasCarta;

            /*
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_ObtenerComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.Add("@idComida", SqlDbType.Int).Value = idComida;
 
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    List<ComidaBEforList> lstComidas = new List<ComidaBEforList>();

                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ComidaBEforList comida = new ComidaBEforList();

                            ObtenerCamposDt(dt, ref comida, i);

                            lstComidas.Add(comida);
                        }
                    }
                    if (lstComidas.Count > 0)
                    {
                        return lstComidas;
                    }
                    else
                    {

                        List<ComidaBEforList> lstComidasVacia = new List<ComidaBEforList>();
                        return lstComidasVacia;
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }*/
        }

        //Actualizar comida
        public bool Update(ComidaBEforUpdate obj)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarComida");
            //Se añaden los parametros
            cmd.AddInt("@idComida", obj.idComida);
            cmd.AddInt("@idCategoria", obj.idCategoria);
            cmd.AddString("@nombreComida", obj.nombreComida);
            cmd.Add(SqlDbType.Money, "@precio", obj.precio);
            cmd.Add(SqlDbType.Money, "@costo", obj.costo);
            cmd.AddString("@imagen", obj.imagen);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();


            /*
            bool state = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("usp_ActualizarComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.Parameters.Add("@idComida", SqlDbType.Int).Value = obj.idComida;
                    cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = obj.idCategoria;
                    cmd.Parameters.Add("@nombreComida", SqlDbType.VarChar).Value = obj.nombreComida;
                    cmd.Parameters.Add("@precio", SqlDbType.VarChar).Value = obj.precio;
                    cmd.Parameters.Add("@costo", SqlDbType.VarChar).Value = obj.costo;
                    cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = obj.imagen;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return state;*/
        }

        //Borrado LOGICO de comida
        public bool Delete(int idComida)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_EliminarComida");
            //Se añaden los parametros
            cmd.AddInt("@idComida", idComida);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();

            /*
            bool state = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.Parameters.Add("@idComida", SqlDbType.Int).Value = idComida;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return state;*/
        }


        /*public void ObtenerCamposDt(DataTable dt, ref ComidaBEforList comida, int i)
        {

            comida.idComida = Convert.ToInt32(dt.Rows[i]["idComida"]);
            comida.nombreComida = dt.Rows[i]["nombreComida"].ToString();
            comida.nombreCategoria = dt.Rows[i]["nombreCategoria"].ToString();
            comida.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
            comida.costo = Convert.ToDouble(dt.Rows[i]["costo"]);
            comida.imagen = dt.Rows[i]["imagen"].ToString();
            comida.fechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"]);
            comida.estado = dt.Rows[i]["estado"].ToString();

        }*/

        //Obtener campos para listarlos en las funciones relacionadas a comida
        public static ComidaBEforList ObtenerCamposComida(TablaValores tv)
        {
            ComidaBEforList comida = new ComidaBEforList
            {
                idComida = tv.GetInt("idComida"),
                nombreComida = tv.GetString("nombreComida"),
                nombreCategoria = tv.GetString("nombreCategoria"),
                precio = tv.GetDouble("precio"),
                costo = tv.GetDouble("costo"),
                imagen = tv.GetString("imagen"),
                fechaCreacion = tv.GetDateTime("fechaCreacion"),
                estado = tv.GetString("estado")
            };
            return comida;
        }

    }
}
