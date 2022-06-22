using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EmpleadoBL
    {
        private EmpleadoDal empleadoDALC = new EmpleadoDal();

        public bool Add(EmpleadoBE obj)
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

        public List<EmpleadoBE> listarEmpleados()
        {

            try
            {
                List<EmpleadoBE> lstEmpleados = new List<EmpleadoBE>();
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
