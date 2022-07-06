using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.ComidaEntities
{
    public class ComidaBEforList
    {
        public string nombreCategoria { get; set; }
        public int idComida { get; set; }
        public string nombreComida { get; set; }
        public double precio { get; set; }
        public double costo { get; set; }
        public string imagen { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }

    }
}
