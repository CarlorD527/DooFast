using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.PedidoBe
{
    public class PedidoBEforListCocina
    {
            public int idMesa { get; set; }
            public int idOrden { get; set; }
            public string nombreComida { get; set; }

            public string imagen { get; set; }
            public int cantidad { get; set; }

            public DateTime fechaCreacion { get; set; }

            public string estadoOrden { get; set; }
    }
}
