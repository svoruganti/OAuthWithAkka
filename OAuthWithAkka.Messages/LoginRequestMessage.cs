namespace OAuthWithAkka.Messages
{
    public class LoginRequestMessage
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginRequestMessage(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class LoginResponseMessage
    {
        public string Token { get; }

        public LoginResponseMessage(string token)
        {
            Token = token;
        }
    }
}