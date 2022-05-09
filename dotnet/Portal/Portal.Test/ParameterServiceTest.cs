using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Models;
using Portal.Services;
using Portal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Test
{
    [TestClass]
    public class ParameterServiceTest
    {
        private CheetahDBContext ctx;
        private IParameterService parameterService;

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
            parameterService = new ParameterService(ctx);
        }

        [TestMethod]
        public void EditParameterDescriptionsTest1()
        {
            using var transaction = ctx.Database.BeginTransaction();
            try
            {
                var data = new EditParameterDescriptionViewModel();
                data.EditUser = "Test Admin 1";
                data.ParameterEditsDictionary = new Dictionary<string, string>();
                var param = new Param();
                param.Key = "1";
                param.Value = "Testing Editing Parameters 1";
                data.ParameterEdits = new List<Param>();
                data.ParameterEdits.Add(param);
                data.FillParamDictionary();

                parameterService.EditParameterDescription(data, param.Key);
                var expected = ctx.Parameters.Where(x => x.ParameterId == 1).First().Description;
                Assert.AreEqual(expected, "Testing Editing Parameters 1");
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
        public void EditParameterDescriptionsTest2()
        {
            using var transaction = ctx.Database.BeginTransaction();
            try
            {
                var data = new EditParameterDescriptionViewModel();
                data.EditUser = "Test Admin 2";
                data.ParameterEditsDictionary = new Dictionary<string, string>();
                var param = new Param();
                param.Key = "2";
                param.Value = "Testing Editing Parameters 2";
                data.ParameterEdits = new List<Param>();
                data.ParameterEdits.Add(param);
                data.FillParamDictionary();

                parameterService.EditParameterDescription(data, param.Key);
                var expected = ctx.Parameters.Where(x => x.ParameterId == 2).First().Description;
                Assert.AreEqual(expected, "Testing Editing Parameters 2");
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
