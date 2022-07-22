using CapaEntidades.MesaEntities;
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
    public class MesaDal
    {

        private readonly String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        //Agregar mesa
        public bool Add(MesaBePost obj)
        {

            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_CrearMesa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.Add("@nroMesa", SqlDbType.Int).Value = obj.nroMesa;
                    cmd.Parameters.Add("@idRestaurante", SqlDbType.Int).Value = obj.idRestaurante;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return state;
        }


        //Listar Mesas
        public List<MesaBE> listarMesas()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_ListarMesas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<MesaBE> lstMesa = new List<MesaBE>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MesaBE mesa = new MesaBE();

                    ObtenerCamposDt(dt, ref mesa, i);

                    lstMesa.Add(mesa);
                }
            }
            if (lstMesa.Count > 0)
            {
                return lstMesa;
            }
            else
            {
                List<MesaBE> lstComidasVacia = new List<MesaBE>();
                return lstComidasVacia;
            }
        }

        //Borrar mesa
        public bool Delete(int idMesas)
        {
            bool state = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("usp_BorrarMesa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.Parameters.Add("@idMesa", SqlDbType.Int).Value = idMesas;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return state;
        }

        public void ObtenerCamposDt(DataTable dt, ref MesaBE mesa, int i)
        {

            mesa.idMesa = Convert.ToInt32(dt.Rows[i]["idMesa"]);
            mesa.estadoMesa = dt.Rows[i]["estadoMesa"].ToString();
            mesa.nroMesa = Convert.ToInt32(dt.Rows[i]["nroMesa"]);
            mesa.IdRestaurante = Convert.ToInt32(dt.Rows[i]["IdRestaurante"]);
        }

    }
}
