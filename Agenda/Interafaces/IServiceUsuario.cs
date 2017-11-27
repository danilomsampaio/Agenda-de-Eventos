using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Model;

namespace Agenda.Interafaces
{
    public interface IServiceUsuario
    {
        //insere o email e senha do usuario no momento do cadastro do contato
        //dependendo da opção escolhida
        //usuario do sistema? sim ou nao
        void InsereContatoUsuario(Nullable<int> contatoID, agdUsuario agdUsuario);

        agdUsuario UsuarioLogin(agdUsuario agdUsuario);
    }
}
