using DanielTODO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DanielTODO.Controllers
{
    public class TODOController : Controller
    {
        private static List<Tarea> tareas = new List<Tarea>();
        private static int idActual = 1;

        public IActionResult Index()
        {
            var modelo = new TareasViewModel
            {
                TareasIncompletas = tareas.Where(t => !t.EstaEcho).ToList(),
                TareasCompletadas = tareas.Where(t => t.EstaEcho).ToList()
            };

            return View(modelo);
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
        public IActionResult AlternarTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(x => x.Id == id);
            if (tarea != null)
            {
                tarea.EstaEcho = !tarea.EstaEcho;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminarTarea(int id)
        {
            tareas.RemoveAll(x => x.Id == id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarTarea(int id, string nuevoTitulo)
        {
            var tarea = tareas.FirstOrDefault(x => x.Id == id);
            if (tarea != null && !string.IsNullOrWhiteSpace(nuevoTitulo))
            {
                tarea.Titulo = nuevoTitulo;
            }
            return RedirectToAction("Index");
        }
    }
}
