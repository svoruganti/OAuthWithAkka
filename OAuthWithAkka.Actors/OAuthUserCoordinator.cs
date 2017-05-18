using System;
using Akka.Actor;
using Akka.DI.Core;
using OAuthWithAkka.Messages;

namespace OAuthWithAkka.Actors
{
    public class OAuthUserCoordinator : ReceiveActor
    {
        private readonly ActorSystem _actorSystem;

        public OAuthUserCoordinator(ActorSystem actorSystem)
        {
            _actorSystem = actorSystem;
            Receives();
        }

        private void Receives()
        {
            Receive<LoginRequestMessage>(async x =>
            {
                var actorName = $"oAuthUser_{x.UserName}";
                var actor = _actorSystem.ActorSelection($"../{actorName}");
                try
                {
                    var a = await actor.ResolveOne(TimeSpan.FromSeconds(5));
                    var response = a.Ask<LoginResponseMessage>(x);
                    response.PipeTo(Sender);
                }
                catch (ActorNotFoundException e)
                {
                    var props = Context.DI().Props<OAuthUser>();
                    var a = Context.ActorOf(props, actorName);
                    var response = a.Ask<LoginResponseMessage>(x);
                    response.PipeTo(Sender);
                }
            });
        }
    }
}