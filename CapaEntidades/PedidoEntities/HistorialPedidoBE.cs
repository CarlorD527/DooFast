using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.PedidoBe
{
    public class HistorialPedidoBE
    {
        public int idHistorial{ get; set; }
        public int idOrden { get; set; }
        public int idComida { get; set; }   
        public int cantidad { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public int dia { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string estado { get; set; }

    }
}
