using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapaEntidades
{
    public class UsuarioBe
    {

        public string usuario{ get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }
        public string nroCelular { get; set; }
        public string correoElectronico { get; set; }
        public int idRestaurante { get; set; }
        public int idRol { get; set; }
    }


}
