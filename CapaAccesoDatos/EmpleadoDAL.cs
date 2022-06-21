using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace CapaAccesoDatos
{
    public class EmpleadoDal
    {
        private String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        public bool Add(EmpleadoBE obj)
        {
            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("AgregarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@tipoEmpleado", obj.tipoEmpleado);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@contraseña", obj.contrasenia);
                    cmd.Parameters.AddWithValue("@salario", obj.salario);
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

            return state;
        }


        public List<EmpleadoBE> listarEmpleados() {

            SqlDataAdapter da = new SqlDataAdapter("ListarEmpleados", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<EmpleadoBE> lstEmpleados = new List<EmpleadoBE>();
            if (dt.Rows.Count > 0) {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmpleadoBE emp = new EmpleadoBE();
                    emp.idEmpleado = Convert.ToInt32(dt.Rows[i]["idEmpleado"]);
                    emp.nombre = dt.Rows[i]["Nombre"].ToString();
                    emp.tipoEmpleado = dt.Rows[i]["TipoEmpleado"].ToString();
                    emp.usuario = dt.Rows[i]["usuario"].ToString();
                    emp.contrasenia = dt.Rows[i]["contraseña"].ToString();
                    emp.salario = Convert.ToDouble(dt.Rows[i]["salario"]);
                    emp.visible = Convert.ToInt32(dt.Rows[i]["visible"]);

                    lstEmpleados.Add(emp);
                }
            }
            if (lstEmpleados.Count > 0)
            {
                return lstEmpleados;
            }
            else {
                List<EmpleadoBE> lstEmpleadosVacia = new List<EmpleadoBE>();
                return lstEmpleadosVacia;
            }
        }
    }
}
