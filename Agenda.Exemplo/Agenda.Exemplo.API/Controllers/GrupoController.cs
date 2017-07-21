using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Agenda.Exemplo.API.Controllers
{
    [RoutePrefix("grupos")]
    public class GrupoController : ApiController
    {
        private readonly IGrupoAplicacao _grupoAplicacao;
        
        public GrupoController(IGrupoAplicacao grupoAplicacao)
        {
            _grupoAplicacao = grupoAplicacao;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IList<GrupoDTO>))]
        public IHttpActionResult ObterGrupos(string nome = "")
        {
            try
            {
                return Ok(_grupoAplicacao.ObterGrupos(nome));
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("{grupoId:int}")]
        [ResponseType(typeof(GrupoDTO))]
        public IHttpActionResult ObterGrupo(int grupoId)
        {
            try
            {
                return Ok(_grupoAplicacao.ObterGrupo(grupoId));
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
