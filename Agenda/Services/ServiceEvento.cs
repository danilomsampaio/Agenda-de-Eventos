using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Interafaces;
using Agenda.Model;
using Agenda;

//implementa a interface IServiceEvento, onde pode se encontrar maiores informacoes sobre os metodos

namespace Agenda.Services
{
    public class ServiceEvento : IServiceEvento
    {
        private AgendaProvaEvoluaEntities1 db = new AgendaProvaEvoluaEntities1();

        public IList<agdEvento> RetornaEventos()
        {
           return db.agdEvento.ToList();
        }

        public void CriarEvento(agdEvento agdEvento)
        {
            db.agdEvento.Add(agdEvento);
            db.SaveChanges();
        }
    }
}
