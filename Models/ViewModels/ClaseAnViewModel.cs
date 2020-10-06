using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U2Actividad5_171G0250.Models;

namespace U2Actividad5_171G0250.Models.ViewModels
{
    public class ClaseAnViewModel
    {
        public Clase Clase { get; set; }
        public IEnumerable<Clase> otrita { get; set;  }
        public IEnumerable <Especies>[] clasesita { get; set; }
    }
}
