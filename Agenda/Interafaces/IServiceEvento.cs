﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Model;

namespace Agenda.Interafaces
{
    public interface IServiceEvento
    {
        //metodo que busca todas os eventos já cadastradas no banco de dados
        IList<agdEvento> RetornaEventos();

        //metodo de criação de novos eventos, recebe um objeto evento e insere no banco de dados
        void CriarEvento(agdEvento agdEvento);
    }
}
