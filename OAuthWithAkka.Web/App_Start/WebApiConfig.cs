using System.Net.Http.Formatting;
using System.Web.Http;

namespace OAuthWithAkka.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            AutofacConfig.RegisterContainer(config);
            config.MapHttpAttributeRoutes();
        }
    }
}