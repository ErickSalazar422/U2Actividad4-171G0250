using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U2Actividad5_171G0250.Models;

namespace U2Actividad5_171G0250.Services
{
    public class ClasificacionService
    {
      public List<Clase> Clase { get; set; }
        public ClasificacionService()
        {
           using( animalesContext context = new animalesContext())
            {
                Clase = context.Clase.OrderBy(x => x.Nombre).ToList();

            }
        }
    }
}
