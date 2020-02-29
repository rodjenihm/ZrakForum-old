using System.Threading.Tasks;

namespace ZrakForum.Web.Services
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
        Task<bool> AuthenticateAsync(string username, string password);
    }
}