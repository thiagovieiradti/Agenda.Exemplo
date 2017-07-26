using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Dominio.Entidade;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Exemplo.Aplicacao.Mapper
{
    public static class ContatoMapper
    {
        public static ContatoDTO CriarDTO(this Contato entidade)
        {
            return new ContatoDTO()
            {
                contatoId = entidade.ContatoId,
                nome = entidade.Nome,
                grupo = entidade.Grupo.CriarDTO()
            };
        }

        public static IList<ContatoDTO> CriarDTO(this IList<Contato> entidade)
        {
            return entidade.ToList().ConvertAll(e => e.CriarDTO());
        }

        public static Contato CriarEntidade(this ContatoDTO dto)
        {
            return new Contato()
            {
                ContatoId = dto.contatoId,
                Nome = dto.nome,
                Grupo = dto.grupo.CriarEntidade()
            };
        }
    }
}
