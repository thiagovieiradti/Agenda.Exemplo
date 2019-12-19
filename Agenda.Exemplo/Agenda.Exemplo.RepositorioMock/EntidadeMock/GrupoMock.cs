using Agenda.Exemplo.Dominio.Entidade;
using System.Collections.Generic;

namespace Agenda.Exemplo.RepositorioMock.EntidadeMock
{
    public static class GrupoMock
    {
        public static Grupo grupoMock1 = new Grupo()
        {
            GrupoId = 1,
            Nome = "Trabalho"
        };

        public static List<Grupo> listaGrupo = new List<Grupo>()
        {
            grupoMock1
        };
    }
}
