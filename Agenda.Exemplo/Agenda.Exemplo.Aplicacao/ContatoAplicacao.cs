using Agenda.Exemplo.Aplicacao.Mapper;
using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Dominio.Repositorio;
using System.Collections.Generic;

namespace Agenda.Exemplo.Aplicacao
{
    public class ContatoAplicacao : IContatoAplicacao
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoAplicacao(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public int InserirContato(ContatoDTO contato)
        {
            return _contatoRepositorio.InserirContato(contato.CriarEntidade());
        }

        public ContatoDTO ObterContato(int contatoId)
        {
            return _contatoRepositorio.ObterContato(contatoId).CriarDTO();
        }

        public IList<ContatoDTO> ObterContatos(int? grupoId, string nome)
        {
            return _contatoRepositorio.ObterContatos(grupoId, nome).CriarDTO();
        }
    }
}
