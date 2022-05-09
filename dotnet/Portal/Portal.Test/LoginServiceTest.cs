using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Models;
using Portal.Services;
using Portal.ViewModels;

namespace Portal.Test
{
    [TestClass]
    public class LoginServiceTest
    {
        private LoginService service;
        private CheetahDBContext context;
        public IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("testconfig.json")
                .Build();
            return config;
        }
        [TestInitialize]
        public void Initialize()
        {
            var config = GetConfiguration();
            var _service = new LoginService(config, context);
            service = _service;
        }

        [TestMethod]
        public void TestLogin1()
        {
            var x = new LoginViewModel();
            x.Username = "Example1";
            x.Password = "UserNotAuthenticated";
            var actual = service.LoginUser(x).Result;
            Assert.AreEqual("Not authenticated", actual);
        }
        
        [TestMethod]
        public void TestLogin2()
        {
            var x = new LoginViewModel();
            x.Username = "Example2";
            x.Password = "UserNotAuthenticated";
            var actual = service.LoginUser(x).Result;
            Assert.AreEqual("Not authenticated", actual);
        }

        [TestMethod]
        public void TestConvertToSha()
        {
            var actual = service.ConvertToSha("testing");
            StringBuilder sb = new StringBuilder();
            using (var hash = SHA256.Create())            
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes("testing"));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            var expected = sb.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
