using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.RepositorioMock.EntidadeMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.RepositorioMock
{
    public class ChamadaRepositorioMock : IChamadaRepositorio
    {
        public int InserirChamada(Chamada chamada)
        {
            chamada.ChamadaId = ChamadaMock.listachamadas.Count + 1;
            ChamadaMock.listachamadas.Add(chamada);
            return chamada.ChamadaId;
        }

        public Chamada ObterChamada()
        {
            throw new NotImplementedException();
        }

        public IList<Chamada> ObterChamadas(int? chamadaId)
        {
            var listaChamadas = ChamadaMock.listachamadas;
            if (chamadaId.HasValue)
            {
                listaChamadas = listaChamadas.Where(c => c.ChamadaId == chamadaId).ToList();
            }
            return listaChamadas;
        }

        public void RemoverChamada()
        {
            throw new NotImplementedException();
        }
    }
}
