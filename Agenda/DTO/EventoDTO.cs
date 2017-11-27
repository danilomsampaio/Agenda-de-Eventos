using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DTO
{
    public class EventoDTO
    {
        public int EventoID { get; set; }
        public string EventoNome { get; set; }
        public string CategoriaCor { get; set; }
        public string DataHoraEvento { get; set; }
    }
}
