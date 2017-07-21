using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Dominio.Entidade;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Exemplo.Aplicacao.Mapper
{
    public static class GrupoMapper
    {
        public static GrupoDTO CriarDTO(this Grupo entidade)
        {
            return new GrupoDTO()
            {
                id = entidade.Id,
                nome = entidade.Nome
            };
        }

        public static IList<GrupoDTO> CriarDTO(this IList<Grupo> entidade)
        {
            return entidade.ToList().ConvertAll(e => e.CriarDTO());
        }
    }
}
