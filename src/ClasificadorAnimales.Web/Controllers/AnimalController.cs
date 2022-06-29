using ClasificadorAnimales.Data.EF;
using ClasificadorAnimales.Servicio.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClasificadorAnimales.Web.Controllers
{
    public class AnimalController : Controller
    {
        ITipoAnimalService _tipoAnimalService;
        IAnimalServices _animalServices;

        public AnimalController(ITipoAnimalService tipoAnimalService, IAnimalServices animalServices)
        {
            _tipoAnimalService = tipoAnimalService;
            _animalServices = animalServices;
        }

        // GET: AnimalController
        public ActionResult Alta()
        {
            ViewBag.TipoAnimal = _tipoAnimalService.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Alta(Animal animal)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(Request.Form["OtroTipo"]))
            {
                List<TipoAnimal> tipoAnimales = _tipoAnimalService.ObtenerTodos();
                ViewBag.TipoAnimales = tipoAnimales;
                return View(animal);
            }
            _animalServices.Insertar(animal);
            return RedirectToAction("Index");
        }

        public ActionResult ListarAnimales()
        {
            ViewBag.TipoAnimales = _tipoAnimalService.ObtenerTodos();
            return View(_animalServices.ObtenerTodos());
        }

        [HttpPost]
        public ActionResult ListarAnimales(int? IdTipoAnimal)
        {
            ViewBag.TipoAnimales = _tipoAnimalService.ObtenerTodos();
            if (IdTipoAnimal.HasValue)
            {
                return View(_animalServices.ObtenerPorTipo(IdTipoAnimal.Value));
            }
            return View(_animalServices.ObtenerTodos());
        }

        public ActionResult Eliminar(int IdTipoAnimal)
        {
            _animalServices.Eliminar(IdTipoAnimal);
            return RedirectToAction("ListarAnimales");
        }

        public ActionResult Modificar(int IdAnimal)
        {
            ViewBag.TipoAnimal = _tipoAnimalService.ObtenerTodos();
            Animal animal = _animalServices.AnimalPorId(IdAnimal);
            return View("ModificarAnimal",animal);
        }

        [HttpPost]
        public ActionResult Modificar(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return View("ModificarAnimal", animal);
            }
            _animalServices.ModificarAnimal(animal);
            return RedirectToAction("ListarAnimales");
        }
    }
}
