using System.Web;
using System.Web.Http;

namespace OAuthWithAkka.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
//            GlobalConfiguration.Configure(AutofacConfig.RegisterContainer);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}