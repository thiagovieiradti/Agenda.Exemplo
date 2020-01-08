using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Repositorio
{
    public class ChamadaRepositorio : IChamadaRepositorio
    {
        public int InserirChamada(Chamada chamada)
        {
            throw new NotImplementedException();
        }

        public Chamada ObterChamada(int chamadaId)
        {
            throw new NotImplementedException();
        }

        public IList<Chamada> ObterChamadas(int? chamadaId, string nome)
        {
            throw new NotImplementedException();
        }

        public void RemoverChamada(int chamadaId)
        {
            throw new NotImplementedException();
        }
    }
}
