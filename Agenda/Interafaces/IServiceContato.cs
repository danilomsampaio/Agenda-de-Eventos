using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Model;

namespace Agenda.Interafaces
{
    public interface IServiceContato
    {
        //metodo de criação de novos contatos, recebe um objeto contato e insere no banco de dados
        void CadastraContato(agdContato agdContato);

        //metodo que busca o ID do contato inserido
        //para que o mesmo possa ser usando para que o seu campo usuarioID seja atualizado no momento de sua inserção
        //dependendo da escolha, se o contato vai ser ou não um usuario do sistema
        agdContato BuscaContatoUsuario(string email);

        //metodo que busca todas os contatos já cadastradas no banco de dados
        IList<agdContato> BuscaContatos();
    }
}
