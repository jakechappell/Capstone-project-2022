using Portal.ViewModels;
using System.Threading.Tasks;

namespace Portal.Services
{
    public interface ILoginService
    {
        // Task<bool> SendLoginInfo(LoginViewModel model);
        Task<string> LoginUser(LoginViewModel model);
        public string ConvertToSha(string input);
        void SaveUsernameAndToken(string username, string password, string token);
    }
}
