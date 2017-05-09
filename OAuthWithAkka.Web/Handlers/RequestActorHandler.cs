using Akka.Actor;
using Akka.DI.Core;
using OAuthWithAkka.Actors;

namespace OAuthWithAkka.Web.Handlers
{
    public class RequestActorHandler : IRequestActorHandler
    {
        private readonly IActorRef _requestActor;

        public RequestActorHandler(ActorSystem actorSystem)
        {
            _requestActor = actorSystem.ActorOf(actorSystem.DI().Props<RequestActor>(), "requestActor");
        }
        public string GetMessage(string s)
        {
            return _requestActor.Ask<string>(s).Result;
        }
    }
}