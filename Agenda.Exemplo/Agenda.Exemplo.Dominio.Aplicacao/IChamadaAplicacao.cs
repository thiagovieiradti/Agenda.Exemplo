using Agenda.Exemplo.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Dominio.Aplicacao
{
    public interface IChamadaAplicacao
    {
        int InserirChamada(ChamadaDTO chamada);
        ChamadaDTO ObterChamada();
        IList<ChamadaDTO> ObterChamadas(int? chamadaId);
        void RemoverChamada(int chamadaId);
    }
}
