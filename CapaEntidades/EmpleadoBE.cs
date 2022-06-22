using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EmpleadoBE
    {
        public int idEmpleado { get; set; }
        public string usuario { get; set; }

        public string contrasenia { get; set; }

        public Double salario { get; set; }
        public String nombre { get; set; }
        public String tipoEmpleado { get; set; }

        public int visible { get; set; }


    }
}
