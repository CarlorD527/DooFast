using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapaEntidades
{
    public class CartaBE
    {

        public string nombreCarta{ get; set; }
        public int idRestaurante { get; set; }
    }

    public class CartaBEforList{


        public int idCarta { get; set; }
        public string nombreLocal { get; set; }
        public string nombreCarta { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }

    }
    public class CartaBEforUpdate
    {
        public int idCarta { get; set; }

        public int idRestaurante { get; set; }
        public string nombreCarta { get; set; }
 

    }

}
