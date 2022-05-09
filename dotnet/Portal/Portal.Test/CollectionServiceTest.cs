using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Models;
using Portal.Services;

namespace Portal.Test
{
    [TestClass]
    public class CollectionServiceTest
    {
        private CheetahDBContext ctx;
        private ICollectionService collectionService;
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
            collectionService = new CollectionService(ctx);
        }

        
        [TestMethod]
        public void GetAllCollectionsTest()
        {
            var expected = collectionService.GetAllCollections();
            Assert.AreEqual(expected.Count, 26);
        }

        [TestMethod]
        public void GetAllSidebarLinksTest()
        {
            var expect = collectionService.GetAllSidebarLinks();
            Assert.AreEqual(expect.Count, 26);
        }

        [TestMethod]
        public void GetAreasByIdTest1()
        {
            var expected = collectionService.GetCollectionsById(1);
            Assert.AreEqual(expected.CollectionName, "Account");
        }
        
        [TestMethod]
        public void GetAreasByIdTest2()
        {
            var expected = collectionService.GetCollectionsById(2);
            Assert.AreEqual(expected.CollectionName, "TradeBlock");
        }
        
        [TestMethod]
        public void GetAreasByIdTest3()
        {
            var expected = collectionService.GetCollectionsById(3);
            Assert.AreEqual(expected.CollectionName, "Trade");
        }
        
        [TestMethod]
        public void GetAreasByIdTest4()
        {
            var expected = collectionService.GetCollectionsById(4);
            Assert.AreEqual(expected.CollectionName, "Token");
        }
        
        [TestMethod]
        public void GetAreasByIdTest5()
        {
            var expected = collectionService.GetCollectionsById(5);
            Assert.AreEqual(expected.CollectionName, "Task");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetAreasByIdTestFail1()
        {
            var expected = collectionService.GetCollectionsById(30);
            Assert.AreEqual(expected.CollectionName, "Token");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetAreasByIdTestFail2()
        {
            var expected = collectionService.GetCollectionsById(31);
            Assert.AreEqual(expected.CollectionName, "Task");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetAreasByIdTestFail3()
        {
            var expected = collectionService.GetCollectionsById(32);
            Assert.AreEqual(expected.CollectionName, "NameAndAddress");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetAreasByIdTestFail4()
        {
            var expected = collectionService.GetCollectionsById(33);
            Assert.AreEqual(expected.CollectionName, "Modeling");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void GetAreasByIdTestFail5()
        {
            var expected = collectionService.GetCollectionsById(34);
            Assert.AreEqual(expected.CollectionName, "Lookup");
        }
    }
}
