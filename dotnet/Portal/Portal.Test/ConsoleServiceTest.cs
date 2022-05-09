using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Models;
using Portal.Services;
using Portal.ViewModels;

namespace Portal.Test
{
    [TestClass]
    public class ConsoleServiceTest
    {
        private IConsoleService consoleService;
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
            consoleService = new ConsoleService(config);
        }

        [TestMethod]
        public void TestConsole()
        {
            var x = new ConsoleViewModel();
            x.ActiveEndpointUrl = "/api/v6/Accounts";
            x.Jwt = "notAuthenticatedJwt";
            var param = new ConsoleParam();
            param.Key = "AccountNumber";
            param.Value = "00555";
            x.ActiveEndpointParameters = new List<ConsoleParam>();
            x.ActiveEndpointParameters.Add(param);


            var actual = consoleService.MakeConsoleCall(x);
            Assert.AreEqual(new[] {"Unauthorized. Check your Cheetah API access status"}.ToString(), actual.Result.ToString());
        }
        
        [TestMethod]
        public void TestConsole_Dynamic()
        {
            var x = new ConsoleViewModel();
            x.ActiveEndpointUrl = "/api/v6/Accounts/1";
            x.Jwt = "notAuthenticatedJwt";
            var param = new ConsoleParam();
            param.Key = "";
            param.Value = "";
            x.ActiveEndpointParameters = new List<ConsoleParam>();
            x.ActiveEndpointParameters.Add(param);

            var actual = consoleService.MakeConsoleCall_Dynamic(x);
            Assert.AreEqual("Unauthorized. Check your Cheetah API access.", actual.Result.ToString());
        }
    }
}
