using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.PedidoEntities
{
    public class HistorialBe
    {
        public int idHistorialPedido { get; set; }
        public string nombreComida { get; set; }
        public string nombreCategoria { get; set; }
        public int cantidad { get; set; }
        public string estado { get; set; }
        public DateTime fechaRegistro { get; set; }

    }
}
