using Agenda.Exemplo.Aplicacao.Mapper;
using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Aplicacao
{
    public class ChamadaAplicacao : IChamadaAplicacao
    {
        private readonly IChamadaRepositorio _chamadaRepositorio;

        public ChamadaAplicacao(IChamadaRepositorio chamadaRepositorio)
        {
            _chamadaRepositorio = chamadaRepositorio;
        }

        public int InserirChamada(ChamadaDTO chamada)
        {
            return _chamadaRepositorio.InserirChamada(chamada.CriarEntidade());
        }

        public ChamadaDTO ObterChamada()
        {
            throw new NotImplementedException();
        }

        public IList<ChamadaDTO> ObterChamadas(int? chamadaId)
        {
            return _chamadaRepositorio.ObterChamadas(chamadaId).CriarDTO();
        }

        public void RemoverChamada()
        {
            throw new NotImplementedException();
        }
    }
}
