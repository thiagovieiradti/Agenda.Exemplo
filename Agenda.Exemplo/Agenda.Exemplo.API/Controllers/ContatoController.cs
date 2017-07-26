using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Agenda.Exemplo.API.Controllers
{
    [RoutePrefix("contatos")]
    public class ContatoController : ApiController
    {

        private readonly IContatoAplicacao _contatoAplicacao;

        public ContatoController(IContatoAplicacao contatoAplicacao)
        {
            _contatoAplicacao = contatoAplicacao;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IList<ContatoDTO>))]
        public IHttpActionResult ObterContatos(int? grupoId = null, string nome = "")
        {
            try
            {
                return Ok(_contatoAplicacao.ObterContatos(grupoId, nome));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("{contatoId:int}")]
        [ResponseType(typeof(ContatoDTO))]
        public IHttpActionResult ObterContato(int contatoId)
        {
            try
            {
                return Ok(_contatoAplicacao.ObterContato(contatoId));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(int))]
        public IHttpActionResult InserirContato([FromBody] ContatoDTO contato)
        {
            try
            {
                return Ok(_contatoAplicacao.InserirContato(contato));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(int))]
        public IHttpActionResult EditarContato([FromBody] ContatoDTO contato)
        {
            try
            {
                _contatoAplicacao.EditarContato(contato);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
