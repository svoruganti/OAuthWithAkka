using Akka.Actor;

namespace OAuthWithAkka.Actors
{
    public class RequestActor : ReceiveActor
    {
        public RequestActor()
        {
            Receive<string>(s =>
            {
                Sender.Tell($"Hello {s}");
            });
        }
    }
}