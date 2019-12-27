using Agenda.Exemplo.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.RepositorioMock.EntidadeMock
{
    class ChamadaMock
    {
        public static Chamada chamadamock1 = new Chamada()
        {
            ChamadaId = 1,
            Contato = ContatoMock.contatoMock1
        };

        public static List<Chamada> listachamadas = new List<Chamada>
        {
            chamadamock1
        };
    }
    

}
