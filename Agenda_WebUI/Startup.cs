using Microsoft.Owin;
using Owin;
using Agenda.Services;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartupAttribute(typeof(Agenda_WebUI.Startup))]
namespace Agenda_WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
