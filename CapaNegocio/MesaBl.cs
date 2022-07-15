using CapaAccesoDatos;
using CapaEntidades.MesaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MesaBl
    {

        // CRUD DE MESA
        private readonly  MesaDal MesaDALC = new MesaDal();

        public bool Add()
        {
            return MesaDALC.Add();
        }

        public List<MesaBE> listarMesas()
        {

            List<MesaBE> lstMesas = MesaDALC.listarMesas();
        
            return lstMesas;
        }
     
        public bool Delete(int idMesa)
        {
            return MesaDALC.Delete(idMesa);
        }

    }
}
