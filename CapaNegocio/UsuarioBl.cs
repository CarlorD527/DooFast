using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UsuarioBl
    {

        // CRUD DE Usuarios
        private readonly UsuarioDal UsuarioDALC = new UsuarioDal();

        public bool Add(UsuarioBe obj)
        {
            return UsuarioDALC.Add(obj);
        }
        public List<UsuarioBEforList> listarUsuarios()
        {
            return UsuarioDALC.List();
        }
        public UsuarioBEforList listarUsuario(int idUsuario)
        {
            return UsuarioDALC.List(idUsuario);
        }
        public bool Update (UsuarioBEforUpdate obj)
        {
            return UsuarioDALC.Update(obj);
        }
        public bool UpdateLastLogin(int idUsuario)
        {
            return UsuarioDALC.UpdateLastLogin(idUsuario);
        }
        public bool Delete(int idUsuario)
        {
            return UsuarioDALC.Delete(idUsuario);
        }


        


    }
}
