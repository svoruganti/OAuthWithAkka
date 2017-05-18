using System.Threading.Tasks;
using OAuthWithAkka.Messages;

namespace OAuthWithAkka.Web.Handlers
{
    public interface IOAuthUserCoordinatorHandler
    {
        Task<LoginResponseMessage> GetToken();
    }
}