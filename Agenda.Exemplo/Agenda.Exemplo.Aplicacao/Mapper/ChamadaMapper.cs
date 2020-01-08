using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Aplicacao.Mapper
{
    public static class ChamadaMapper
    {
        public static ChamadaDTO CriarDTO(this Chamada entidade)
        {
            return new ChamadaDTO()
            {
                chamadaId = entidade.ChamadaId,
                contato = entidade.Contato.CriarDTO(),
                dataHora = entidade.DataHora,
                data = entidade.Data,
                hora = entidade.Hora,
            };
        }

        public static IList<ChamadaDTO> CriarDTO(this  IList<Chamada> entidade)
        {
            return entidade.ToList().ConvertAll(e => e.CriarDTO());
        }

        public static Chamada CriarEntidade(this ChamadaDTO dto)
        {
            return new Chamada()
            {
                ChamadaId = dto.chamadaId,
                Contato = dto.contato.CriarEntidade(),
                DataHora = DateTime.Now,
                Data = DateTime.Now.ToShortDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
            };
        }
    }
}
