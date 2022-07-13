﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.PedidoBe
{
    public class PedidoBEforListPorMesa
    {
        public int idMesa { get; set; }

        public int idOrden { get; set; }
        public int idComida { get; set; }
        public string nombreCategoria { get; set; }

        public string nombreComida { get; set; }

        public double precio { get; set; }
        public double cantidad { get; set; }
        public string estadoOrden { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}