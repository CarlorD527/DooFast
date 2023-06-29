using CapaAccesoDatos;
using CapaEntidades;
using CapaEntidades.SugerenciaBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SugerenciaBl
    {

        // CRUD DE Usuarios
        private readonly SugerenciaDal SugerenciaDALC = new SugerenciaDal();

        public bool Add(SugerenciaBE obj)
        {
            return SugerenciaDALC.Add(obj);
        }
        public List<SugerenciaBEforList> ListarSugerencias()
        {
            return SugerenciaDALC.Listar();
        }
        public SugerenciaBEforList ListarSugerencia(int idSugerencia)
        {
            return SugerenciaDALC.Listar(idSugerencia);
        }
        public bool Update (SugerenciaBEforUpdate obj)
        {
            return SugerenciaDALC.Update(obj);
        }
    }
}
