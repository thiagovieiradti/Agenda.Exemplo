using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Dominio.Entidade
{
    class Chamada
    {
        public int ChamdaId { get; set; }
        public Contato contato { get; set; }
    }
}
