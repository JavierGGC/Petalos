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
        var fls = Context.Datosflores.OrderBy(x => x.Idflor);
        return View(fls);
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
            ModelState.AddModelError("", "Es necesario un nombre.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecientifico))
        {
            ModelState.AddModelError("", "Es necesario un nombre científico.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecomun))
        {
            ModelState.AddModelError("", "Es necesario el nombre común.");
        }
        else if (string.IsNullOrWhiteSpace(f.Origen))
        {
            ModelState.AddModelError("", "Es necesio escribir el origen.");
        }
        else if (string.IsNullOrWhiteSpace(f.Descripcion))
        {
            ModelState.AddModelError("", "Es necesario un nombre.");
        }
        else if (Context.Datosflores.Any(x => x.Nombrecientifico == f.Nombrecientifico))
        {
            ModelState.AddModelError("", "Este no es admitido, ya que ya hay una flor registrada con este nombre");
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
            ModelState.AddModelError("", "La imagen aún no se a seleccionado.");
            return View(flor);
        }
        if (archivo != null)
        {
            if (archivo.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("", "La imagen tiene que ser del tipo jpg.");
                return View(flor);
            }
            if (archivo.Length > 1024 * 1024 * 2)
            {
                ModelState.AddModelError("", "Esta imagen sobrepasa el tamaño permitido.");
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
        var flor = Context.Datosflores.FirstOrDefault(x => x.Idflor == id);
        if (flor == null)
        {
            return RedirectToAction("Index");
        }
        return View(flor);
    }
    [HttpPost]
    public IActionResult EditarFlor(Datosflores f)
    {
        var fls = Context.Datosflores.FirstOrDefault(x => x.Idflor == f.Idflor);
        if (fls == null)
        {
            return RedirectToAction("Index");
        }
        if (string.IsNullOrWhiteSpace(f.Nombre))
        {
            ModelState.AddModelError("", "Es necesario un nombre.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecientifico))
        {
            ModelState.AddModelError("", "Es necesario un nombre científico.");
        }
        else if (string.IsNullOrWhiteSpace(f.Nombrecomun))
        {
            ModelState.AddModelError("", "Es necesario el nombre común.");
        }
        else if (string.IsNullOrWhiteSpace(f.Origen))
        {
            ModelState.AddModelError("", "Es necesario escribir el origen.");
        }
        else if (string.IsNullOrWhiteSpace(f.Descripcion))
        {
            ModelState.AddModelError("", "Es necesario un nombre");
        }
        else if (Context.Datosflores.Any(x => x.Nombrecientifico.Contains(f.Nombrecientifico) && !x.Nombrecientifico.Contains(f.Nombrecientifico)))
        {
            ModelState.AddModelError("", "Este no es admitido,ya que hay una flor regisrada con este nombre");
        }
        else
        {
            fls.Nombre = f.Nombre;
            fls.Nombrecientifico = f.Nombrecientifico;
            fls.Nombrecomun = f.Nombrecomun;
            fls.Origen = f.Origen;
            fls.Descripcion = f.Descripcion;
            Context.Update(fls);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult Eliminar(int id)
    {
        var fls = Context.Datosflores.FirstOrDefault(x => x.Idflor == id);
        if (fls == null)
        {
            return RedirectToAction("Index");
        }
        return View(fls);
    }
    [HttpPost]
    public IActionResult Eliminar(Datosflores f)
    {
        var fls = Context.Datosflores.Include(x => x.Imagenesflores).FirstOrDefault(x => x.Idflor == f.Idflor);
        var imgs = fls.Imagenesflores.OrderBy(x => x.Nombreimagen);
        if (fls == null)
        {
            ModelState.AddModelError("", "No se a encontrado esta flor, puede que haya sido eliminada");
        }
        else
        {
            Context.Remove(fls);
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
        var fls = Context.Imagenesflores.FirstOrDefault(x => x.Idimagen == id);
        if (fls == null)
        {
            return RedirectToAction("Index");
        }
        return View(fls);
    }
    [HttpPost]
    public IActionResult EliminalaImagen(Imagenesflores f)
    {
        var fls = Context.Imagenesflores.FirstOrDefault(x => x.Idimagen == f.Idimagen);
        if (f == null)
        {
            ModelState.AddModelError("", "No se a encontrado esta flor, puede que haya sido eliminada");
        }
        else
        {
            Context.Remove(fls);
            Context.SaveChanges();
            var path = Env.WebRootPath + "/images/" + fls.Nombreimagen;
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