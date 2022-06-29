using futbol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servicio.DB;
using Servicio.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace futbol.Controllers
{
    public class FutbolController : Controller
    {
        private IJugadorService _JugadorService;
        private IEquipoService _EquipoService;

        public FutbolController(IJugadorService jugadorService,IEquipoService equipoService)
        {
           this._JugadorService =  jugadorService;
            this._EquipoService = equipoService;
        }

        public IActionResult Index()
        {
            ViewBag.equipos = _EquipoService.listarEquipos();
            return View(_JugadorService.ObtenerTodos());
        }

        [HttpPost]
        public IActionResult Filtrar(int? IdEquipo)
        {
            ViewBag.equipos = _EquipoService.listarEquipos();
            if (IdEquipo.HasValue)
            {
                return View("Index",_JugadorService.ObtenerJugadoresPorEquipo(IdEquipo.Value));
            }
            return View("Index",_JugadorService.ObtenerTodos());
        }

        public ActionResult Agregar()
        {
            ViewBag.equipos = _EquipoService.listarEquipos();
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _JugadorService.Agregar(jugador);
                ViewBag.equipos = _EquipoService.listarEquipos();
                return View("Index",_JugadorService.ObtenerTodos());
            }
            return View();
        }

        public ActionResult Eliminar (int IdJugador)
        {
            _JugadorService.Eliminar(IdJugador);
            ViewBag.equipos = _EquipoService.listarEquipos();
            return View("Index", _JugadorService.ObtenerTodos());
        }

    }
}
