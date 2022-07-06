using CapaEntidades;
using CapaEntidades.UsuarioEntities;
using CapaNegocio;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DooFast.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
      
        // GET: api/Usuarios
        public List<UsuarioBEforList> Get()
        {
            UsuarioBl obj = new UsuarioBl();
            _ = new List<UsuarioBEforList>();

            List<UsuarioBEforList> lstUsuarios = obj.listarUsuarios();

            return lstUsuarios;
        }

        // GET: api/Usuarios
        public UsuarioBEforList Get(int id)
        {
            UsuarioBl obj = new UsuarioBl();
            _ = new List<UsuarioBEforList>();

            UsuarioBEforList Usuario = obj.listarUsuario(id);

            return Usuario;
        }

        // POST: api/Usuarios
        public string Post(UsuarioBe Usuario)
        {

            if (new UsuarioBl().Add(Usuario))
                return "Usuario registrado con exito!";
            else
                return "Algo salio mal, verificar el body del POST!!";
        }

        // PUT: api/Usuarios
        public string Put(UsuarioBEforUpdate Usuario)
        {
            if (new UsuarioBl().Update(Usuario))
                return "Usuario actualizado con exito!";
            else
                return "Algo salio mal, verificar el body del PUT!!";
        }

        // DELETE: api/Usuarios
        public string Delete(int id)
        {
            if (new UsuarioBl().Delete(id))
                return "Usuario eliminado con exito!";
            else
                return "Algo salio mal!!";
        }
    }
}
