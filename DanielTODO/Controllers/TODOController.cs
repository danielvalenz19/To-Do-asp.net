using DanielTODO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DanielTODO.Controllers
{
    public class TODOController : Controller
    {
        private static List<Tarea> tareas= new List<Tarea>();
        private static int idActual = 1;    
        public IActionResult Index()
        {
            return View(tareas);
        }
        [HttpPost]
        public IActionResult AñadirTarea(string titulo) 
        { 
            if (!string.IsNullOrWhiteSpace(titulo))
            {
                tareas.Add(new Tarea { Id = idActual++, Titulo = titulo, EstaEcho = false });
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult AlternarTarea(int Id)
        {
            var tarea = tareas.Find(x=> x.Id == Id);    
            if (tarea == null)
            {
                tarea.EstaEcho= !tarea.EstaEcho;
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult EliminarTarea(int Id) 
        {
            tareas.RemoveAll(x=>x.Id == Id);
            return RedirectToAction("Index");
        }


    }
}
