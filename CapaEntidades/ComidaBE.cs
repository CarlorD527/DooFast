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
        public string imagen { get; set; }
    }

    public class ComidaBEforList{
        
        
        public string nombreCategoria { get; set; }
        public int idComida { get; set; }
        public string nombreComida { get; set; }
        public double precio { get; set; }
        public double costo { get; set; }
        public string  imagen { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
    
    }
    public class ComidaBEforUpdate
    {
        public int idComida { get; set; }

        public int idCategoria { get; set; }
        public string nombreComida { get; set; }
        public double precio { get; set; }
        public double costo { get; set; }
        public string imagen { get; set; }

    }

}
