using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Interafaces;
using Agenda.Model;

//implementa a interface IServiceUsuario, onde pode se encontrar maiores informacoes sobre os metodos

namespace Agenda.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private AgendaProvaEvoluaEntities1 db = new AgendaProvaEvoluaEntities1();

        public void InsereContatoUsuario(int? contatoID, agdUsuario agdUsuario)
        {
            db.sp_insereUsuario(contatoID, agdUsuario.ausEmail, agdUsuario.ausSenha);
            db.SaveChanges();
        }

        public agdUsuario UsuarioLogin(agdUsuario agdUsuario)
        {
            return db.agdUsuario.Where(a => a.ausEmail.Equals(agdUsuario.ausEmail) && a.ausSenha.Equals(agdUsuario.ausSenha)).FirstOrDefault();
        }
    }
}

