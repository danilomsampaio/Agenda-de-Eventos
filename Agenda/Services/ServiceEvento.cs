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

        public IList<agdEvento> RetornaEventosPorData(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            return db.agdEvento
                .Where(x => x.aevDataHora >= dataHoraInicio && x.aevDataHora <= dataHoraFim)
                .ToList();
        }

        public void RemoveEvento(int id)
        {
            agdEvento agdEvento = db.agdEvento.Find(id);
            db.agdEvento.Remove(agdEvento);
            db.SaveChanges();
        }

        public string BuscaNomeEvento(int idEvento)
        {
            return db.agdEvento.Find(idEvento).aevNome; 
        }
    }
}
