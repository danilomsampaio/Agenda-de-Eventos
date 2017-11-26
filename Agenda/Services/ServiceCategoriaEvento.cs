using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Interafaces;
using Agenda.Model;

//implementa a interface IServiceCategoriaEvento, onde pode se encontrar maiores informacoes sobre os metodos


namespace Agenda.Services
{
    public class ServiceCategoriaEvento : IServiceCategoriaEvento
    {
        private AgendaProvaEvoluaEntities1 db = new AgendaProvaEvoluaEntities1();

        public IList<agdCategoriaEvento> BuscaCategorias()
        {
            return db.agdCategoriaEvento.ToList();
        }

        public void CriarCategoriaEvento(agdCategoriaEvento agdCategoriaEvento)
        {
            db.agdCategoriaEvento.Add(agdCategoriaEvento);
            db.SaveChanges();
        }
    }
}
