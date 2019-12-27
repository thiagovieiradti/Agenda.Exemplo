using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Dominio.Entidade
{
    class Chamada
    {
        public int ChamadaId { get; set; }
        public Contato Contato { get; set; }
    }
}
