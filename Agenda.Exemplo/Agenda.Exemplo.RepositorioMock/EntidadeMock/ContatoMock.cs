using Agenda.Exemplo.Dominio.Entidade;
using System.Collections.Generic;

namespace Agenda.Exemplo.RepositorioMock.EntidadeMock
{
    public static class ContatoMock
    {
        public static Contato contatoMock1 = new Contato()
        {
            ContatoId = 1,
            Grupo = new Grupo()
            {
                GrupoId = 1,
                Nome = "Trabalho"
            },
            Nome = "Fulano"
        };

        public static List<Contato> listaContato = new List<Contato>()
        {
            contatoMock1
        };
    }
}
