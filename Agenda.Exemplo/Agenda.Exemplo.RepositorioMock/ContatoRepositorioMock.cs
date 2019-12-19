using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.RepositorioMock.EntidadeMock;
using System.Collections.Generic;

namespace Agenda.Exemplo.RepositorioMock
{
    public class ContatoRepositorioMock : IContatoRepositorio
    {
        public void EditarContato(Contato contato)
        {
            //TODO update Contato Mock
        }

        public int InserirContato(Contato contato)
        {
            return 1;
            //TODO update Contato Mock
        }

        public Contato ObterContato(int contatoId)
        {
            return ContatoMock.contatoMock1;
        }

        public IList<Contato> ObterContatos(int? grupoId, string nome)
        {
            return ContatoMock.listaContato;
        }

        public void RemoverContato(int contatoId)
        {
            //TODO update Contato Mock
        }
    }
}
