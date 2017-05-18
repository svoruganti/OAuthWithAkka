using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.Core;
using OAuthWithAkka.Actors;
using OAuthWithAkka.Messages;

namespace OAuthWithAkka.Web.Handlers
{
    public class OAuthUserCoordinatorHandler : IOAuthUserCoordinatorHandler
    {
        private readonly IActorRef _coordinator;
        public OAuthUserCoordinatorHandler(ActorSystem actorSystem)
        {
            _coordinator = actorSystem.ActorOf(actorSystem.DI().Props<OAuthUserCoordinator>(), "oAuthUserCoordinator");
        }
        public  Task<LoginResponseMessage> GetToken()
        {
            var response = _coordinator.Ask<LoginResponseMessage>(new LoginRequestMessage("testuser@test.com", "testpassword"));
            return response;
        }
    }
}