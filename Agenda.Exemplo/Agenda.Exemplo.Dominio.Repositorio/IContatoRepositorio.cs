using Agenda.Exemplo.Dominio.Entidade;

namespace Agenda.Exemplo.Dominio.Repositorio
{
    public interface IContatoRepositorio
    {
        int InserirContato(Contato contato);
        Contato ObterContato(int contatoId);
    }
}
