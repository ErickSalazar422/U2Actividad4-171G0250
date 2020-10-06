using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U2Actividad5_171G0250.Models.ViewModels
{
    public class ClasificacionViewModel
    {
        public string nombreClase { get; set; }
        public IEnumerable<Especies>[] Especies { get; set; }
    }
}
