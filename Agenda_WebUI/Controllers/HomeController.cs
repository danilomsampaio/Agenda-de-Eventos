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
        private IServiceUsuario _serviceUsuario;

        public HomeController(
            IServiceCategoriaEvento serviceCategoriaEvento, 
            IServiceContato serviceContato,
            IServiceEvento serviceEvento,
            IServiceUsuario serviceUsuario)
        {
            _serviceCategoriaEvento = serviceCategoriaEvento;
            _serviceContato = serviceContato;
            _serviceEvento = serviceEvento;
            _serviceUsuario = serviceUsuario;
        }

        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.Categoria = _serviceCategoriaEvento.BuscaCategorias();
                ViewBag.Contato = _serviceContato.BuscaContatos();

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

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

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(agdUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                var v = _serviceUsuario.UsuarioLogin(usuario);
                if (v != null ||( usuario.ausEmail == "admin@admin.com" && usuario.ausSenha == "admin"))
                {
                    //permitir usuario admin
                    if (usuario.ausEmail == "admin@admin.com" && usuario.ausSenha == "admin")
                    {
                        v = new agdUsuario {
                            agdUsuarioID = 0,
                            ausEmail = "admin@admin.com",
                            ausSenha = "admin"
                        };
                    }
                    Session["usuarioLogadoID"] = v.agdUsuarioID.ToString();
                    Session["nomeUsuarioLogado"] = v.ausEmail.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(usuario);
        }
    }
}