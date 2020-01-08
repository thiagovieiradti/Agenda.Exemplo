using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Dominio.Entidade
{
    public class Chamada
    {
        public int ChamadaId { get; set; }
        public Contato Contato { get; set; }
        public DateTime DataHora { get; set; }
    }
}
