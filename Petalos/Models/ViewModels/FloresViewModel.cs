using System.Collections.Generic;

namespace Petalos.Models.ViewModels
{
    public class FloresViewModel
    {
        public string Nombreimagen { get; set; }
        public IEnumerable<Datosflores> Datosflores { get; set; }
    }
}
