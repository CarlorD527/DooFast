using CapaAccesoDatos;
using CapaEntidades;
using CapaEntidades.AuthEntities;
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
        public List<AuthBeList> listarRol(AuthBe auth)
        {
            List<AuthBeList> lst = authDALC.AutenticarUsuario(auth);

            return lst;
        }
    }
}
