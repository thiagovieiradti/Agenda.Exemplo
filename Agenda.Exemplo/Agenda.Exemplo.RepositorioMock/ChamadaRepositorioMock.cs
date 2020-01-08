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

        public Chamada ObterChamada(int chamadaId)
        {
            return ChamadaMock.listachamadas.First(c => c.ChamadaId == chamadaId) ;
        }

        public IList<Chamada> ObterChamadas(int? grupoId, string nome, string data)
        {
            var listaChamadas = ChamadaMock.listachamadas;
            if (grupoId.HasValue)
            {
                listaChamadas = listaChamadas.Where(c => c.Contato.Grupo.GrupoId == grupoId).ToList();
            }
            if (!string.IsNullOrEmpty(nome))
            {
                listaChamadas = listaChamadas.Where(c => c.Contato.Nome.ToLower().Contains(nome.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(data))
            {
                listaChamadas = listaChamadas.Where(c => c.Data.Contains(data)).ToList();
            }
            return listaChamadas;
        }

        public void RemoverChamada(int chamadaId)
        {
            ChamadaMock.listachamadas.RemoveAll(c => c.ChamadaId == chamadaId);
        }
    }
}
