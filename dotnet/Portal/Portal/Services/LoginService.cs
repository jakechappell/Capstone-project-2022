using Microsoft.Extensions.Configuration;
using Portal.ViewModels;
using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Portal.Models;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Flurl.Http.Content;

namespace Portal.Services
{
    public class LoginService : ILoginService
    {
        private CheetahDBContext context;
        public readonly IConfiguration config;
        public LoginService(IConfiguration _config, CheetahDBContext _context)
        {
            context = _context;
            config = _config;
        }
        
        public async Task<string> LoginUser(LoginViewModel model)
        {
            try
            {
                var section = config.GetSection("RootURL");
                var rootUrl = section["Url"];
                var response = await rootUrl.AppendPathSegment("/api/v6/Token")
                    .WithHeader("Content-Type", "application/json")
                    .WithHeader("x-api-key",
                        "example-api-key")
                    .WithBasicAuth(model.Username, model.Password).PostAsync().ReceiveJson<LoginResponse>();
                SaveUsernameAndToken(model.Username, ConvertToSha(model.Password), "");
                return response.Jwt;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("503"))
                {
                    var user = context.Sessions.Where(x => x.Username == model.Username).First();
                    if (user.Password == ConvertToSha(model.Password))
                    {
                        return "No calls";
                    }
                    return "Accutech down";
                }
                return "Not authenticated";
            }
        }

        public void SaveUsernameAndToken(string username, string password, string token)
        {
            if (!context.Sessions.Any(x => x.Username == username))
            {
                var sessionModel = new Session();
                sessionModel.Username = username;
                sessionModel.Token = token;
                sessionModel.Password = password;
                context.Sessions.Add(sessionModel);
                context.SaveChanges();
            }
            
        }

        public string ConvertToSha(string input)
        {
            StringBuilder sb = new StringBuilder();
            using (var hash = SHA256.Create())            
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(input));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
