using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.RepositorioMock.EntidadeMock;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Exemplo.RepositorioMock
{
    public class ContatoRepositorioMock : IContatoRepositorio
    {
        public void EditarContato(Contato contato)
        {
            AssociarGrupoPorId(contato);
            ContatoMock.listaContato.RemoveAll(c => c.ContatoId == contato.ContatoId);
            ContatoMock.listaContato.Add(contato);
        }

        public int InserirContato(Contato contato)
        {
            AssociarGrupoPorId(contato);
            contato.ContatoId = ContatoMock.listaContato.Count + 1;
            ContatoMock.listaContato.Add(contato);
            return contato.ContatoId;
        }

        private static void AssociarGrupoPorId(Contato contato)
        {
            contato.Grupo = GrupoMock.listaGrupo.First(g => g.GrupoId == contato.Grupo.GrupoId);
        }

        public Contato ObterContato(int contatoId)
        {
            return ContatoMock.listaContato.First(c => c.ContatoId == contatoId);
        }

        public IList<Contato> ObterContatos(int? grupoId, string nome)
        {
            var listaFiltrada = ContatoMock.listaContato;
            if (grupoId.HasValue)
            {
                listaFiltrada = listaFiltrada.Where(c => c.Grupo.GrupoId == grupoId).ToList();
            }
            if (!string.IsNullOrEmpty(nome))
            {
                listaFiltrada = listaFiltrada.Where(c => c.Nome.Contains(nome)).ToList();
            }
            return listaFiltrada;
        }

        public void RemoverContato(int contatoId)
        {
            ContatoMock.listaContato.RemoveAll(c => c.ContatoId == contatoId);
        }
    }
}
