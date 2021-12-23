using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Petalos.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarFlor()
        {
            return View();
        }


        public IActionResult AgregarImagenes()
        {
            return View();
        }

        public IActionResult EditarFlor()
        {
            return View();
        }

    }

    
}