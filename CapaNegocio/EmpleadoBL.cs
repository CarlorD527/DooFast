using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EmpleadoBl
    {
        private EmpleadoDal empleadoDALC = new EmpleadoDal();

        public bool Add(EmpleadoBe obj)
        {
            bool state = false;
            try
            {
                state = empleadoDALC.Add(obj);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;
        }

        public List<EmpleadoBe> listarEmpleados()
        {

            try
            {
                List<EmpleadoBe> lstEmpleados = new List<EmpleadoBe>();
                lstEmpleados = empleadoDALC.listarEmpleados();

                return lstEmpleados;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
