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
        public List<AuthBeList> AutenticarUsuario(AuthBe obj)
        {


            obj.contrasenia = DalUtil.GetSHA256(obj.contrasenia);

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_AutenticarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = obj.correo;
                    cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = obj.contrasenia;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    List<AuthBeList> authlst = new List<AuthBeList>();

                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            AuthBeList authbe = new AuthBeList();

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

                        List<AuthBeList> authlstVacia = new List<AuthBeList>();
                        return authlstVacia;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                List<AuthBeList> authlstVacia = new List<AuthBeList>();
                return authlstVacia;
            }
        }
        public void ObtenerCamposDt(DataTable dt, ref AuthBeList authbe, int i)
        {
            authbe.rol= Convert.ToString(dt.Rows[i]["nombreRol"]);
        }
    }
}
