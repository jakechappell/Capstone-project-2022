using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Models;
using Portal.Services;
using Portal.ViewModels;
using System;
using System.Linq;

namespace Portal.Test
{
    [TestClass]
    public class EndpointServiceTest
    {
        private CheetahDBContext ctx;
        private IEndpointService endpointService;

        public IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("testconfig.json")
                .Build();
            return config;
        }

        [TestInitialize]
        public void Initalize()
        {
            var config = GetConfiguration();
            var options = new DbContextOptionsBuilder<CheetahDBContext>();
            options.UseSqlServer(config.GetConnectionString("CheetahTestDatabase"));
            var context = new CheetahDBContext(options.Options);
            ctx = context;
            endpointService = new EndpointService(ctx);
        }

        [TestMethod]
        public void GetEndpointsByIdTest1()
        {
            var expected = endpointService.GetEndpointById(1);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/Accounts");
        }
        
        [TestMethod]
        public void GetEndpointsByIdTest2()
        {
            var expected = endpointService.GetEndpointById(2);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/NameAndAddresses");
        }
        
        [TestMethod]
        public void GetEndpointsByIdTest3()
        {
            var expected = endpointService.GetEndpointById(3);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/NameAndAddresses");
        }
        
        [TestMethod]
        public void GetEndpointsByIdTest4()
        {
            var expected = endpointService.GetEndpointById(4);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/Modeling/InvestmentModel");
        }
        
        [TestMethod]
        public void GetEndpointsByIdTest5()
        {
            var expected = endpointService.GetEndpointById(5);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/Modeling/InvestmentModel");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetEndpointsByIdTestFail1()
        {
            var expected = endpointService.GetEndpointById(115);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/Accounts");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetEndpointsByIdTestFail2()
        {
            var expected = endpointService.GetEndpointById(116);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/NameAndAddresses");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetEndpointsByIdTestFail3()
        {
            var expected = endpointService.GetEndpointById(117);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/NameAndAddresses/{identityRecordId}");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetEndpointsByIdTestFail4()
        {
            var expected = endpointService.GetEndpointById(118);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/Modeling/InvestmentModel");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetEndpointsByIdTestFail5()
        {
            var expected = endpointService.GetEndpointById(119);
            Assert.AreEqual(expected.Urlsuffix, "/api/v6/Modeling/InvestmentModel");
        }

        [TestMethod]
        public void EditEndpointDescriptionsTest1()
        {
            using var transaction = ctx.Database.BeginTransaction();
            try
            {
                var data = new EditEndpointDescriptionViewModel { EndpointId = 1, Description = "Testing Endpoint Editing 1" };

                var result = endpointService.EditEndpointDescription(data);
                var expected = ctx.Endpoints.Where(x => x.EndpointId == 1).First().Description;
                Assert.AreEqual(expected, "Testing Endpoint Editing 1");
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
        
        [TestMethod]
        public void EditEndpointDescriptionsTest2()
        {
            using var transaction = ctx.Database.BeginTransaction();
            try
            {
                var data = new EditEndpointDescriptionViewModel { EndpointId = 2, Description = "Testing Endpoint Editing 2" };

                var result = endpointService.EditEndpointDescription(data);
                var expected = ctx.Endpoints.Where(x => x.EndpointId == 2).First().Description;
                Assert.AreEqual(expected, "Testing Endpoint Editing 2");
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
