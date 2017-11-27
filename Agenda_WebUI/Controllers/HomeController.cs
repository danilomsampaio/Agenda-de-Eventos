using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agenda.Interafaces;
using Agenda.Model;
using Agenda.DTO;

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

            List<EventoDTO> listaEvento = new List<EventoDTO>();
            var lista = _serviceEvento.RetornaEventos();

            foreach (var item in lista)
            {
                listaEvento.Add(new EventoDTO
                {
                    EventoID = item.agdEventoID,
                    EventoNome = item.aevNome,
                    CategoriaCor = item.agdCategoriaEvento.aceCor,
                    DataHoraEvento = Convert.ToString(item.aevDataHora)
                });
            }



            return Json(new {
                lista = listaEvento
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void RemoveEventos(string itens)
        {
            string[] eventos = itens.Split(',');

            foreach (var id in eventos)
            {
                if(!string.IsNullOrEmpty(id))
                    _serviceEvento.RemoveEvento(Int32.Parse(id));
            }
        }
    }
}