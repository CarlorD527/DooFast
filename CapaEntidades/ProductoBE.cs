using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ProductoBE
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public double precio { get; set; }
        public double costo { get; set; }
        public string imagen { get; set; }
        public string nombreCategoria { get; set; }
    }
}
