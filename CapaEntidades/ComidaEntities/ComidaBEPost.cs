using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapaEntidades
{
    public class ComidaBEPost
    {

        public string nombreComida { get; set; }
        public double precio { get; set; }
        public double costo { get; set; }
        public int idCategoria { get; set; }
        public IFormFile imagen { get; set; }
    }
}
