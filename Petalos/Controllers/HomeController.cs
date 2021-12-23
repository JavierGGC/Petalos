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

        public HomeController(floresContext fc)
        {
            Context = fc;
        }
        public IActionResult Index()
        {
           

            return View();
        }
        [Route("/{Flor}")]
        public IActionResult Flor(string datosflores)
        {
            
            var df = Context.Datosflores
                .Include(x => x.Imagenesflores)
                .FirstOrDefault(x => x.Nombre == datosflores);

            if (df == null)
            {
                return RedirectToAction("Index");
            }

            
            return View(datosflores);

            
        }
    }
}