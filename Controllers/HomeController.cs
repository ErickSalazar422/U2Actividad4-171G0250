using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Actividad5_171G0250.Models;
using U2Actividad5_171G0250.Models.ViewModels;

namespace U2Actividad5_171G0250.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           
            animalesContext context = new animalesContext();
          var clas = context.Clase.OrderBy(x=>x.Nombre);
           

            return View(clas);
        }
        [Route("Clasificacion/{id}")]
        public IActionResult Clasificacion(string id)
        {
            var nombre = id;
            animalesContext context = new animalesContext();
            

            var idesp = context.Especies.OrderBy(x => x.Id);
            var Clas = context.Clase.Include(x => x.Especies).ThenInclude(x => x.IdClaseNavigation).FirstOrDefault(x => x.Nombre.ToUpper() == nombre);
            if(Clas==null)
            {
                return RedirectToAction("Index");
            }
            else {
                ClasificacionViewModel vm = new ClasificacionViewModel();
                vm.nombreClase = Clas.Nombre;
                vm.Especies= Clas.Especies.OrderBy(x => x.IdClaseNavigation.Nombre)
                    .GroupBy(x => x.IdClaseNavigation.Nombre).Select(x => x).ToArray();
                return View(vm);
            }

        }

    }
}
