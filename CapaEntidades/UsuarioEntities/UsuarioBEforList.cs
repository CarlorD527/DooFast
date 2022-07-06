using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.UsuarioEntities
{

    public class UsuarioBEforList
    {
        public int idUsuario { get; set; }

        public string nombreLocal { get; set; }
        public string nombreRol { get; set; }
        public string usuario { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }
        public string nroCelular { get; set; }
        public string correoElectronico { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime ultimoLogin { get; set; }

    }
}
