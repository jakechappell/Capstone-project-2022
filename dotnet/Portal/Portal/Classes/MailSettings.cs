using Microsoft.Extensions.Configuration;
using System;

namespace Portal.Classes
{
    public class MailSettings
    {
        public string FromEmail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string ToEmail { get; set; }
        public bool Enabled { get; set; }

        public MailSettings()
        {

        }

        public MailSettings(IConfiguration config)
        {
            var section = config.GetSection("EmailSettings");
            FromEmail = section["FromEmail"];
            DisplayName = section["DisplayName"];
            Password = section["Password"];
            Host = section["Host"];
            Port = Convert.ToInt32(section["Port"]);
            ToEmail = section["ToEmail"];
            Enabled = Convert.ToBoolean(section["Enabled"]);
        }
    }
}
