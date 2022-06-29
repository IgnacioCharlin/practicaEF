using BD.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ObrasDeArte.Models;
using ObrasDeArte.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ObrasDeArte.Controllers
{
    public class ObrasDeArteController : Controller
    {
        private readonly ILogger<ObrasDeArteController> _logger;
        private IObraDeArteService ObraDeArteService;

        public ObrasDeArteController(ILogger<ObrasDeArteController> logger,IObraDeArteService obraDeArteService)
        {
            this.ObraDeArteService = obraDeArteService;
            _logger = logger;
        }

        public ActionResult Index()
        {
            List<ObraDeArte> obrasDeArte = ObraDeArteService.ListarObras();
            return View(obrasDeArte);
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ObraDeArte obraDeArte)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                ObraDeArteService.AgregarObra(obraDeArte);
                return View("Index",ObraDeArteService.ListarObras());
            }
        }

        public ActionResult SigloXIX()
        {
            return View(ObraDeArteService.ObrasDeArteSigloXIX());
        }

        public ActionResult Eliminar(int Id)
        {
            ObraDeArteService.Eliminar(Id);
            return View("Index",ObraDeArteService.ListarObras());
        }

        public ActionResult Editar(int Id)
        {
            return View(ObraDeArteService.buscarPorId(Id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
