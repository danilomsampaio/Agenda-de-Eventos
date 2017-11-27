using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Agenda_WebUI.Controllers;
using Agenda.Services;
using Agenda.Interafaces;
using Microsoft.AspNet.Identity;
using Agenda_WebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Agenda_WebUI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IServiceEvento, ServiceEvento>();
            container.RegisterType<IServiceContato, ServiceContato>();
            container.RegisterType<IServiceUsuario, ServiceUsuario>();
            container.RegisterType<IServiceConvite, ServiceConvite>();
            container.RegisterType<IServiceCategoriaEvento, ServiceCategoriaEvento>();
            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            // e.g. container.RegisterType<ITestService, TestService>();            

            return container;
        }
    }
}