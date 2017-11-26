using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agenda.Model;
using Agenda.Services;
using Agenda.Interafaces;

namespace Agenda_WebUI.Controllers
{
    public class EventoController : Controller
    {
        private IServiceEvento _serviceEvento;

        public EventoController(IServiceEvento serviceEvento)
        {
            _serviceEvento = serviceEvento;
        }

        // GET: Evento
        public ActionResult Eventos()
        {
            var lista = _serviceEvento.RetornaEventos();
            return View(lista);
        }
    }
}