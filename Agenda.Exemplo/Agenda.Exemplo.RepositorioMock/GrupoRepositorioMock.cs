using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.RepositorioMock.EntidadeMock;
using System.Collections.Generic;

namespace Agenda.Exemplo.RepositorioMock
{
    public class GrupoRepositorioMock : IGrupoRepositorio
    {
        public void EditarGrupo(Grupo grupo)
        {
        }

        public int InserirGrupo(Grupo grupo)
        {
            return 1;
        }

        public Grupo ObterGrupo(int grupoId)
        {
            return GrupoMock.grupoMock1;
        }

        public IList<Grupo> ObterGrupos(string nome)
        {
            return GrupoMock.listaGrupo;
        }

        public void RemoverGrupo(int grupoId)
        {
        }
    }
}
