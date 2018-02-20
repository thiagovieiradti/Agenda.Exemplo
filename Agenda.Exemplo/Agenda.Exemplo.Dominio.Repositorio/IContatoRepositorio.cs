using Agenda.Exemplo.Dominio.Entidade;
using System.Collections.Generic;

namespace Agenda.Exemplo.Dominio.Repositorio
{
    public interface IContatoRepositorio
    {
        int InserirContato(Contato contato);
        Contato ObterContato(int contatoId);
        IList<Contato> ObterContatos(int? grupoId, string nome);
        void EditarContato(Contato contato);
        void RemoverContato(int contatoId);
    }
}
