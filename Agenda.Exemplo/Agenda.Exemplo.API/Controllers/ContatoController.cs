using System.Web.Http;

namespace Agenda.Exemplo.API.Controllers
{
    [RoutePrefix("api/contatos")]
    public class ContatoController : ApiController
    {
        [HttpGet]
        [Route("{contatoId:int}")]
        public IHttpActionResult ObterContato(int contatoId)
        {
            return Ok();
        }
    }
}
