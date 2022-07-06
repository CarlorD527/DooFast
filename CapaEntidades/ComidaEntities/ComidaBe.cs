using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapaEntidades
{
    public class ComidaBe
    {

        public string nombreComida{ get; set; }
        public double precio { get; set; }
        public double costo { get; set; }
        public int idCategoria { get; set; }
    }
}
