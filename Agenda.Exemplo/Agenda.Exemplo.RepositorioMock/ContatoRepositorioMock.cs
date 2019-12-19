using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
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
            return new Contato()
            {
                ContatoId = 1,
                Grupo = new Grupo()
                {
                    GrupoId = 1,
                    Nome = "Trabalho"
                },
                Nome = "Fulano"
            };
        }

        public IList<Contato> ObterContatos(int? grupoId, string nome)
        {
            return new List<Contato>()
            {
                new Contato()
                {
                    ContatoId = 1,
                    Grupo = new Grupo(){
                        GrupoId = 1,
                        Nome = "Trabalho"
                    },
                    Nome = "Fulano"
                }
            };
        }

        public void RemoverContato(int contatoId)
        {
            //TODO update Contato Mock
        }
    }
}
