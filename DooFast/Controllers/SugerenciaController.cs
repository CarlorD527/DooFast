using CapaEntidades;
using CapaEntidades.SugerenciaBE;
using CapaEntidades.UsuarioEntities;
using CapaNegocio;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DooFast.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SugerenciaController : ApiController
    {
      
        // GET: api/Sugerencias
        public List<SugerenciaBEforList> Get()
        {
            SugerenciaBl obj = new SugerenciaBl();

            List<SugerenciaBEforList> lstSugerencias = obj.ListarSugerencias();

            return lstSugerencias;
        }

        // GET: api/Sugerencias
        public SugerenciaBEforList Get(int id)
        {
            SugerenciaBl obj = new SugerenciaBl();

            SugerenciaBEforList Sugerencia = obj.ListarSugerencia(id);

            return Sugerencia;
        }

        // POST: api/Sugerencias
        public string Post(SugerenciaBE Sugerencia)
        {

            if (new SugerenciaBl().Add(Sugerencia))
                return "Sugerencia registrada con exito!";
            else
                return "Algo salio mal, verificar el body del POST!!";
        }

        // PUT: api/Sugerencias
        public string Put(SugerenciaBEforUpdate Sugerencia)
        {
            if (new SugerenciaBl().Update(Sugerencia))
                return "Estado de la sugerencia actualizado con exito!";
            else
                return "Algo salio mal, verificar el body del PUT!!";
        }
    }
}
