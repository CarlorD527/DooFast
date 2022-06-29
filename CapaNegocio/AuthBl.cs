using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AuthBl
    {

        private readonly AuthDal authDALC = new AuthDal();
        public List<AuthBe> listarRol(string nombre , string contrasenia)
        {

            try
            {
                var lst = new List<AuthBe>();

                lst = authDALC.AutenticarUsuario(nombre, contrasenia);

                return lst;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
