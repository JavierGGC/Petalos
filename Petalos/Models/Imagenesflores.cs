using System;
using System.Collections.Generic;

namespace Petalos.Models
{
    public partial class Imagenesflores
    {
        public uint Idimagen { get; set; }
        public string Nombreimagen { get; set; }
        public uint Idflor { get; set; }

        public Datosflores IdflorNavigation { get; set; }
    }
}
