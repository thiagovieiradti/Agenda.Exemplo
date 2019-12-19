using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.RepositorioMock.EntidadeMock;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Exemplo.RepositorioMock
{
    public class GrupoRepositorioMock : IGrupoRepositorio
    {
        public void EditarGrupo(Grupo grupo)
        {
            GrupoMock.listaGrupo.RemoveAll(g => g.GrupoId == grupo.GrupoId);
            GrupoMock.listaGrupo.Add(grupo);
        }

        public int InserirGrupo(Grupo grupo)
        {
            grupo.GrupoId = GrupoMock.listaGrupo.Count + 1;
            GrupoMock.listaGrupo.Add(grupo);
            return grupo.GrupoId;
        }

        public Grupo ObterGrupo(int grupoId)
        {
            return GrupoMock.listaGrupo.First(g => g.GrupoId == grupoId);
        }

        public IList<Grupo> ObterGrupos(string nome)
        {
            var listaFiltrada = GrupoMock.listaGrupo;
            if (!string.IsNullOrEmpty(nome))
            {
                listaFiltrada = listaFiltrada.Where(g => g.Nome.Contains(nome)).ToList();
            }
            return listaFiltrada;
        }

        public void RemoverGrupo(int grupoId)
        {
            GrupoMock.listaGrupo.RemoveAll(g => g.GrupoId == grupoId);
        }
    }
}
