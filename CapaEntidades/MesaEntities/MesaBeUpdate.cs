﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.MesaEntities
{
    public class MesaBeUpdate
    {
        public string estadoMesa { get; set; }
        public int nroMesa { get; set; }
        public int nroAsientos { get; set; }
        public int IdRestaurante { get; set; }
    }
}