using System;
using Akka.Actor;
using OAuthWithAkka.Messages;

namespace OAuthWithAkka.Actors
{
    public class OAuthUser : ReceiveActor
    {
        private string _token = String.Empty;
        public OAuthUser()
        {
            Authenticating();
        }

        private void Authenticating()
        {
            _token = DateTime.Now.Ticks.ToString();
            Become(Authencated);
        }

        private void Authencated()
        {
            Receive<LoginRequestMessage>(x => Sender.Tell(new LoginResponseMessage(_token)));
        }
    }
}