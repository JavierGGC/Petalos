using System.Collections.Generic;

namespace Petalos.Models.ViewModels
{
    public class FloresViewModel
    {
        public Datosflores Flores { get; set; }
        public IEnumerable<Datosflores> Masflores { get; set; }
    }
}
