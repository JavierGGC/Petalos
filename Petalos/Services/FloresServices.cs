using Petalos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Petalos.Services
{
    public class FloresServices
    {
        public List<Datosflores> datosflores { get; set; }

        public FloresServices(floresContext context)
        {
            datosflores = context.Datosflores
                .OrderBy(x => x.Nombre)
                .ToList();
        }

        
    }
}