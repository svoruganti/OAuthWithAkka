using System.Threading.Tasks;
using System.Web.Http;
using OAuthWithAkka.Messages;
using OAuthWithAkka.Web.Handlers;

namespace OAuthWithAkka.Web.Controllers
{
    [RoutePrefix("actors")]
    public class ActorController : ApiController
    {
        private readonly IOAuthUserCoordinatorHandler _requestActorHandler;

        public ActorController(IOAuthUserCoordinatorHandler requestActorHandler)
        {
            _requestActorHandler = requestActorHandler;
        }
        // GET
        [HttpGet, Route("{userName}")]
        public async Task<IHttpActionResult> Get(string userName)
        {
            return Ok(await _requestActorHandler.GetToken(new LoginRequestMessage(userName, "password")));
        }
    }
}