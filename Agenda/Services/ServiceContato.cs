using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Interafaces;
using Agenda.Model;

//implementa a interface IServiceContato, onde pode se encontrar maiores informacoes sobre os metodos


namespace Agenda.Services
{
    public class ServiceContato : IServiceContato
    {
        private AgendaProvaEvoluaEntities1 db = new AgendaProvaEvoluaEntities1();

        public IList<agdContato> BuscaContatos()
        {
            return db.agdContato.ToList();
        }

        public agdContato BuscaContatoUsuario(string email)
        {
            agdContato contato = db.agdContato
                .Where(x => x.actEmail == email).FirstOrDefault();

            return contato;
        }

        public void CadastraContato(agdContato agdContato)
        {
            db.agdContato.Add(agdContato);
            db.SaveChanges();
        }
    }
}
