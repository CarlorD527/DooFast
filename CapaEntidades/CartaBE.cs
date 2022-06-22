using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapaEntidades
{
    public class CartaBe
    {

        public string nombreCarta{ get; set; }
        public int idRestaurante { get; set; }
    }
    public class CartaBEforComidaInsert { 
    
        public int idCarta { get; set; }

        public int idComida { get; set; }
        
    }
 
    public class CartaBEforUpdate
    {
        public int idCarta { get; set; }

        public int idRestaurante { get; set; }
        public string nombreCarta { get; set; }
 

    }

}
