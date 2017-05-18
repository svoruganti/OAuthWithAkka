using System.Web.Http;
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
        [HttpGet, Route]
        public IHttpActionResult Get()
        {
            return Ok(_requestActorHandler.GetToken());
        }
    }
}