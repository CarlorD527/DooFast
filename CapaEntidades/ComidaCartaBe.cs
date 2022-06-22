using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    class ComidaCartaBe
    {
       public class CartaBEforList{


        public int idCarta { get; set; }
        public string nombreLocal { get; set; }
        public string nombreCarta { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }

    }

        public class CartaBEforComidaInsert
        {

            public int idCarta { get; set; }

            public int idComida { get; set; }

        }


    }
}
