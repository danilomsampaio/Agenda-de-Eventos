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

        [HttpGet]
        public ActionResult Eventos(string dataHoraInicio, string dataHoraFim)
        {
            if (String.IsNullOrEmpty(dataHoraInicio) || String.IsNullOrEmpty(dataHoraFim))
            {
                var lista = _serviceEvento.RetornaEventos();
                return View(lista);
            }
           
            else
            {
                DateTime dthInicio = Convert.ToDateTime(dataHoraInicio);
                DateTime dthFim = Convert.ToDateTime(dataHoraFim);
                var lista = _serviceEvento.RetornaEventosPorData(dthInicio, dthFim);
                return View(lista);
            }
        }
    }
}