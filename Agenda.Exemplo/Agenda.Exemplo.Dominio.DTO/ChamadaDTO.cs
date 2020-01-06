using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Dominio.DTO
{
    public class ChamadaDTO
    {
        public int chamadaId { get; set; }
        public ContatoDTO contato { get; set; }
        public DateTime dataHora { get; set; }
    }
}
