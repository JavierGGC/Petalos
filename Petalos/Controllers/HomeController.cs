using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petalos.Models;
using Petalos.Models.ViewModels;

namespace Petalos.Controllers
{
    public class HomeController : Controller
    {
        public floresContext Context { get; }

        public HomeController(floresContext cx)
        {
            Context = cx;
        }
        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            var flor = Context.Datosflores.OrderBy(x => x.Nombre);
            return View(flor);
        }
        [Route("Flor/{id}")]
        public IActionResult Flor(int id)
        {
            var flor = Context.Datosflores.Include(x => x.Imagenesflores).FirstOrDefault(x => x.Idflor == id);
            Random r = new();
            FloresViewModel vm = new();
            vm.Flores = Context.Datosflores.Include(x => x.Imagenesflores).FirstOrDefault(x => x.Idflor == id);
            vm.Masflores = Context.Datosflores.Where(x => x.Idflor != vm.Flores.Idflor).ToList().OrderBy(x => r.Next()).Take(4);

            if (vm == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }
    }
}