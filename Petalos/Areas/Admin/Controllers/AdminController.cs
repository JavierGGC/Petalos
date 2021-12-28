using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petalos.Areas.Admin.Models;
using Petalos.Models;

namespace Petalos.Controllers
{ 

[Area("Admin")]
public class AdminController : Controller
{
    public AdminController(floresContext cx, IWebHostEnvironment env)
    {
        Env = env;
        Context = cx;
    }

    public IWebHostEnvironment Env { get; }
    public floresContext Context { get; }
    [Route("Admin")]
    [Route("Admin/Home")]
    [Route("Admin/Index")]
    public IActionResult Index()
    {
        var flores = Context.Datosflores.OrderBy(x => x.Idflor);
        return View(flores);
    }

    public IActionResult AgregarFlor()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AgregarFlor(Datosflores f)
    {
        if (string.IsNullOrWhiteSpace(f.Nombre))
        {
            ModelState.AddModelError("", "Escriba el nombre.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecientifico))
        {
            ModelState.AddModelError("", "Escriba el nombre cientifico.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecomun))
        {
            ModelState.AddModelError("", "Escriba el nombre comun.");
        }
        else if (string.IsNullOrWhiteSpace(f.Origen))
        {
            ModelState.AddModelError("", "Escriba el origen.");
        }
        else if (string.IsNullOrWhiteSpace(f.Descripcion))
        {
            ModelState.AddModelError("", "Escriba el nombre.");
        }
        else if (Context.Datosflores.Any(x => x.Nombrecientifico == f.Nombrecientifico))
        {
            ModelState.AddModelError("", "Ya existe una flor registrada con ese nombre cientifico.");
        }
        else
        {
            Context.Add(f);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(f);
    }
    public IActionResult AgregarImagenes(int id)
    {
        LasFloresViewModel vm = new();
        vm.datoFlor = Context.Datosflores.Include(x => x.Imagenesflores).FirstOrDefault(x => x.Idflor == id);
        return View(vm);
    }
    [HttpPost]
    public IActionResult AgregarImagenes(LasFloresViewModel flor, IFormFile archivo)
    {
        flor.datoFlor = Context.Datosflores.Include(x => x.Imagenesflores).FirstOrDefault(x => x.Nombre == flor.datoFlor.Nombre);

        if (archivo == null)
        {
            ModelState.AddModelError("", "Imagen no seleccionada.");
            return View(flor);
        }
        if (archivo != null)
        {
            if (archivo.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("", "Solo se aceptan imagenes tipo jpg.");
                return View(flor);
            }
            if (archivo.Length > 1024 * 1024 * 2)
            {
                ModelState.AddModelError("", "La imagen excede el tamano permitido de imagen.");
                return View(flor);
            }
            flor.imagenFlor.Nombreimagen = archivo.FileName;

            flor.imagenFlor.Idflor = flor.datoFlor.Idflor;
            Context.Add(flor.imagenFlor);
            Context.SaveChanges();
            var path = Env.WebRootPath + "/images/" + flor.imagenFlor.Nombreimagen;
            FileStream file = new FileStream(path, FileMode.Create);
            archivo.CopyTo(file);
            file.Close();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
    public IActionResult EditarFlor(int id)
    {
        var flor = Context.Imagenesflores.FirstOrDefault(x => x.Idflor == id);
        if (flor == null)
        {
            return RedirectToAction("Index");
        }
        return View(flor);
    }
    [HttpPost]
    public IActionResult EditarFlor(Datosflores f)
    {
        var flor = Context.Datosflores.FirstOrDefault(x => x.Idflor == f.Idflor);
        if (flor == null)
        {
            return RedirectToAction("Index");
        }
        if (string.IsNullOrWhiteSpace(f.Nombre))
        {
            ModelState.AddModelError("", "Escriba el nombre.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecientifico))
        {
            ModelState.AddModelError("", "Escriba el nombre cientifico.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecomun))
        {
            ModelState.AddModelError("", "Escriba el nombre comun.");
        }
        else if (string.IsNullOrWhiteSpace(f.Origen))
        {
            ModelState.AddModelError("", "Escriba el origen.");
        }
        else if (string.IsNullOrWhiteSpace(f.Descripcion))
        {
            ModelState.AddModelError("", "Escriba el nombre");
        }
        else if (Context.Datosflores.Any(x => x.Nombrecientifico.Contains(f.Nombrecientifico) && !x.Nombrecientifico.Contains(f.Nombrecientifico)))
        {
            ModelState.AddModelError("", "Ya existe una flor registrada con ese nombre.");
        }
        else
        {
            flor.Nombre = f.Nombre;
            flor.Nombrecientifico = f.Nombrecientifico;
            flor.Nombrecomun = f.Nombrecomun;
            flor.Origen = f.Origen;
            flor.Descripcion = f.Descripcion;
            Context.Update(flor);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult Eliminar(int id)
    {
        var flor = Context.Datosflores.FirstOrDefault(x => x.Idflor == id);
        if (flor == null)
        {
            return RedirectToAction("Index");
        }
        return View(flor);
    }
    [HttpPost]
    public IActionResult Eliminar(Datosflores f)
    {
        var flor = Context.Datosflores.Include(x => x.Imagenesflores).FirstOrDefault(x => x.Idflor == f.Idflor);
        var imgs = flor.Imagenesflores.OrderBy(x => x.Nombreimagen);
        if (flor == null)
        {
            ModelState.AddModelError("", "La flor no ha sido encontrada o ya fue eliminada.");
        }
        else
        {
            Context.Remove(flor);
            Context.SaveChanges();
            foreach (var i in imgs)
            {
                var path = Env.WebRootPath + "/images/" + i.Nombreimagen;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

            }
        }
        return RedirectToAction("Index");
    }
    public IActionResult Eliminalaimagen(int id)
    {
        var flor = Context.Imagenesflores.FirstOrDefault(x => x.Idimagen == id);
        if (flor == null)
        {
            return RedirectToAction("Index");
        }
        return View(flor);
    }
    [HttpPost]
    public IActionResult EliminalaImagen(Imagenesflores f)
    {
        var flor = Context.Imagenesflores.FirstOrDefault(x => x.Idimagen == f.Idimagen);
        if (f == null)
        {
            ModelState.AddModelError("", "La imagen no ha sido encontrada o ya fue eliminada.");
        }
        else
        {
            Context.Remove(flor);
            Context.SaveChanges();
            var path = Env.WebRootPath + "/images/" + flor.Nombreimagen;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Index");
        }
        return View(f);
    }
}
}