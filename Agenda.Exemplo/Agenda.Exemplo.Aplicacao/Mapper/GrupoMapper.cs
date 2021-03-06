﻿using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Dominio.Entidade;
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
                grupoId = entidade.GrupoId,
                nome = entidade.Nome
            };
        }

        public static IList<GrupoDTO> CriarDTO(this IList<Grupo> entidade)
        {
            return entidade.ToList().ConvertAll(e => e.CriarDTO());
        }

        public static Grupo CriarEntidade(this GrupoDTO dto)
        {
            return new Grupo()
            {
                GrupoId = dto.grupoId,
                Nome = dto.nome
            };
        }
    }
}
