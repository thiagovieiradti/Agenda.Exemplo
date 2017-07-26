using Agenda.Exemplo.Dominio.DTO;
using System.Collections.Generic;

namespace Agenda.Exemplo.Dominio.Aplicacao
{
    public interface IContatoAplicacao
    {
        int InserirContato(ContatoDTO contato);
        ContatoDTO ObterContato(int contatoId);
        IList<ContatoDTO> ObterContatos(int? grupoId, string nome);
        void EditarContato(ContatoDTO contato);
    }
}
