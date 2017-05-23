using Akka.Actor;
using Akka.DI.Core;
using OAuthWithAkka.Messages;

namespace OAuthWithAkka.Actors
{
    public class OAuthUserCoordinator : ReceiveActor
    {
        public OAuthUserCoordinator()
        {
            Receives();
        }

        private void Receives()
        {
            Receive<LoginRequestMessage>(x =>
            {
                var actorName = $"oAuthUser_{x.UserName}";
                var actorSelection = Context.ActorSelection(Self, $"/{actorName}");
                var actorSelectionResponse = actorSelection.Ask<ActorIdentity>(new Identify(actorName));
                IActorRef actor = actorSelectionResponse.Result.Subject;
                if (actor == null){
                    var props = Context.DI().Props<OAuthUser>();
                    actor = Context.ActorOf(props, actorName);
                }
                var response = actor.Ask<LoginResponseMessage>(x);
                response.PipeTo(Sender);
            });
        }
    }
}
