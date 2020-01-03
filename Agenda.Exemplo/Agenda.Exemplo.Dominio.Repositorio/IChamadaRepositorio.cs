using Agenda.Exemplo.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agenda.Exemplo.Dominio.Repositorio
{
    public interface IChamadaRepositorio
    {
        int InserirChamada(Chamada chamada);
        Chamada ObterChamada();
        IList<Chamada> ObterChamadas(int? chamadaId);
        void RemoverChamada(int chamadaId);
    }

}
