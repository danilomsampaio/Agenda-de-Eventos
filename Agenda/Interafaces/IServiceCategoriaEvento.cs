using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Model;

namespace Agenda.Interafaces
{
    public interface IServiceCategoriaEvento
    {
        //metodo de criação de novas categorias, recebe um objeto categoria e insere no banco de dados
        void CriarCategoriaEvento(agdCategoriaEvento agdCategoriaEvento);

        //metodo que busca todas as categorias já cadastradas no banco de dados
        IList<agdCategoriaEvento> BuscaCategorias();
    }
}
