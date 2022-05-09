using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Portal.Extensions;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.Services;

namespace Portal.Test
{
    [TestClass]
    public class ApiJsonTest
    {
        private CheetahDBContext ctx;
        private IApiJsonService service;
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
            var options = new DbContextOptionsBuilder<CheetahDBContext>();
            options.UseSqlServer(config.GetConnectionString("CheetahTestDatabase"));
            var context = new CheetahDBContext(options.Options);
            ctx = context;
            service = new ApiJsonService(config, ctx);
        }

        public ApiJson GetJsonData()
        {
            var config = GetConfiguration();
            var pathSection = config.GetSection("RootURL");
            var loginSection = config.GetSection("LoginInfo");
            var jsonUrl = pathSection["JsonUrl"];
            var loginJwt = loginSection["Jwt"];
            var settings = new JsonSerializerSettings();
            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;

            try
            {
                var jsonString = GetJsonString(jsonUrl, loginJwt).Result;
                var result = JsonConvert
                    .DeserializeObject<ApiJson>(jsonString, settings);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        private async Task<string> GetJsonString(string jsonUrl, string loginJwt)
        {
            var swagger_json = await jsonUrl.WithOAuthBearerToken(loginJwt).GetStringAsync();
            return swagger_json;
        }

        [TestMethod]
        public void TestGetApiCollections1()
        {
            var getData = service.GetApiJson();
            var data = getData;
            var collections = new List<Collection>();
            foreach (var item in data.paths)
            {
                var collection = item.GetCollectionFromApiJson();
                if (!collections.Any(x => x.CollectionName == collection.CollectionName))
                {
                    collections.Add(collection);
                }
            }
            var expected = collections.Count();
            Assert.AreEqual(expected, 26);
        }

        [TestMethod]
        public void TestDataLoadingAndSaving()
        {
            using var transaction = ctx.Database.BeginTransaction();
            var data = service.GetApiJson();
            try
            {
                service.SaveData(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                transaction.Rollback();
            }
        }
    }
}
