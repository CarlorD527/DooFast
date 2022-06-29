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
    public class AuthDal
    {

        private readonly String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        //Listar comidas
        public List<AuthBe> AutenticarUsuario(string usuario , string contrasenia)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_AutenticarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = contrasenia;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    List<AuthBe> authlst = new List<AuthBe>();

                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            AuthBe authbe = new AuthBe();

                            ObtenerCamposDt(dt, ref authbe, i);

                            authlst.Add(authbe);
                        }
                    }
                    if (authlst.Count > 0)
                    {
                        return authlst;
                    }
                    else
                    {

                        List<AuthBe> authlstVacia = new List<AuthBe>();
                        return authlstVacia;
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void ObtenerCamposDt(DataTable dt, ref AuthBe authbe, int i)
        {
            authbe.rol= Convert.ToString(dt.Rows[i]["nombreRol"]);
        }
    }
}
