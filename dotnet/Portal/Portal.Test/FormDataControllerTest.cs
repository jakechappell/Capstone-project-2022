using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Portal.Classes;

namespace Portal.Test
{
    [TestClass]
    public class FormDataControllerTest
    {
        public IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("testconfig.json")
                .Build();
            return config;
        }

        [TestMethod]
        public void TestGetEmailConfig()
        {
            var emailConfig = GetConfiguration();
            var mailSettings = new MailSettings(emailConfig);

            Assert.IsInstanceOfType(mailSettings, typeof(MailSettings));
            Assert.AreEqual(mailSettings.Port, 587);
            Assert.AreEqual(mailSettings.DisplayName, "Dev Portal");
            Assert.AreEqual(mailSettings.Enabled, false);
        }
    }
}
