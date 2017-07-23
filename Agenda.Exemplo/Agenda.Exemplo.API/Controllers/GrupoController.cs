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

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(int))]
        public IHttpActionResult InserirGrupo([FromBody] GrupoDTO grupo)
        {
            try
            {
                return Ok(_grupoAplicacao.InserirGrupo(grupo));
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult EditarGrupo([FromBody] GrupoDTO grupo)
        {
            try
            {
                _grupoAplicacao.EditarGrupo(grupo);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [Route("{grupoId:int}")]
        public IHttpActionResult RemoverGrupo(int grupoId)
        {
            try
            {
                _grupoAplicacao.RemoverGrupo(grupoId);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
