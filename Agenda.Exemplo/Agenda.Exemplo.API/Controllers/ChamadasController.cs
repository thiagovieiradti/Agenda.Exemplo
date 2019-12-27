using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Agenda.Exemplo.API.Controllers
{
    [RoutePrefix("chamadas")]
    public class ChamadasController : ApiController
    {
        private readonly IChamadaAplicacao _chamadaAplicacao;

        public ChamadasController(IChamadaAplicacao chamadaAplicacao)
        {
            _chamadaAplicacao = chamadaAplicacao;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IList<ChamadaDTO>))]
        public IHttpActionResult ObterChamadas(int? grupoId = null)
        {
            try
            {
                return Ok(_chamadaAplicacao.ObterChamadas(grupoId));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(int))]
        public IHttpActionResult InserirChamada([FromBody] ChamadaDTO chamada)
        {
            try
            {
                return Ok(_chamadaAplicacao.InserirChamada(chamada));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}