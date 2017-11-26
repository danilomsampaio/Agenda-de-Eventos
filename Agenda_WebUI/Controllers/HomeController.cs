using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agenda.Interafaces;
using Agenda.Model;

namespace Agenda_WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IServiceContato _serviceContato;
        private IServiceCategoriaEvento _serviceCategoriaEvento;
        private IServiceEvento _serviceEvento;

        public HomeController(
            IServiceCategoriaEvento serviceCategoriaEvento, 
            IServiceContato serviceContato,
            IServiceEvento serviceEvento)
        {
            _serviceCategoriaEvento = serviceCategoriaEvento;
            _serviceContato = serviceContato;
            _serviceEvento = serviceEvento;
        }

        public ActionResult Index()
        {
            ViewBag.Categoria = _serviceCategoriaEvento.BuscaCategorias();
            ViewBag.Contato = _serviceContato.BuscaContatos();
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvento(agdEvento agdEvento, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                agdEvento.aevFoto = "../Images/" + foto.FileName;
                _serviceEvento.CriarEvento(agdEvento);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult RetornaEventosMes() {

            var lista = _serviceEvento.RetornaEventos();

            return Json({
                data: lista
            }, new JsonResult());
        }
    }
}