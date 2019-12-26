﻿using Agenda.Exemplo.Dominio.Entidade;
using System.Collections.Generic;

namespace Agenda.Exemplo.RepositorioMock.EntidadeMock
{
    public static class ContatoMock
    {
        public static Contato contatoMock1 = new Contato()
        {
            ContatoId = 1,
            Grupo = GrupoMock.grupoMock1,
            Nome = "Fulano",
            Telefone = 88888888
        };

        public static List<Contato> listaContato = new List<Contato>()
        {
            contatoMock1
        };
    }
}
