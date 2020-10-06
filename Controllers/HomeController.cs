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
            //var clas = context.Clase.FirstOrDefault(x => x.Nombre.ToUpper() == nombre);


            //ClaseAnViewModel vm = new ClaseAnViewModel();
            //vm.Clase = clas;
            //Random r = new Random();
            //vm.otrita = context.Clase.Where(x => x.Id==clas.Id).OrderBy(x => r.Next(0, 5)).Take(1);
            //vm.clasesita = clas.Especies.OrderBy(x => x.IdClaseNavigation.Nombre)
            //        .GroupBy(x => x.IdClaseNavigation.Nombre).Select(x => x).ToArray();



            //var random = context.Clase.Select(x => x.Id).OrderBy(x => r.Next(0, 5)).Take(1);

            return View(clas);
        }
        [Route("Clasificacion/{id}")]
        public IActionResult Clasificacion(string id)
        {
            var nombre = id;
            animalesContext context = new animalesContext();
            //var clasif = context.Especies.Where(x => x.IdClaseNavigation.Nombre.ToUpper() == id)
            //    .OrderBy(x => x.Especie);

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
