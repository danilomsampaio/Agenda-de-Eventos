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
    public class ManutencaoController : Controller
    {
        private IServiceContato _serviceContato;
        private IServiceCategoriaEvento _serviceCategoriaEvento;
        private IServiceUsuario _serviceUsuario;

        public ManutencaoController(
            IServiceContato serviceContato,
            IServiceCategoriaEvento serviceCategoriaEvento,
            IServiceUsuario serviceUsuario
            )

        {
            _serviceContato = serviceContato;
            _serviceCategoriaEvento = serviceCategoriaEvento;
            _serviceUsuario = serviceUsuario;
        }

        [HttpGet]
        public ActionResult CreateContato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContato(agdContato agdContato, HttpPostedFileBase foto, agdUsuario agdUsuario)
        {
            if (ModelState.IsValid)
            {
                agdContato.actFoto = "../Images/" + foto.FileName;
                _serviceContato.CadastraContato(agdContato);

                if (!String.IsNullOrEmpty(agdUsuario.ausSenha))
                {
                    agdUsuario.ausEmail = agdContato.actEmail;
                    _serviceUsuario.InsereContatoUsuario(_serviceContato.BuscaContatoUsuario(agdContato.actEmail).agdContatoID, agdUsuario);

                }

                return RedirectToAction("CreateContato");
            }
            return View(agdContato);
        }

        [HttpGet]
        public ActionResult CreateCategoriaEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategoriaEvento(agdCategoriaEvento agdCategoriaEvento)
        {
            if (ModelState.IsValid)
            {
                _serviceCategoriaEvento.CriarCategoriaEvento(agdCategoriaEvento);
                return RedirectToAction("CreateCategoriaEvento");
            }
            return View(agdCategoriaEvento);
        }
    }
}